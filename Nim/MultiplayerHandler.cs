using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading;
using Network;
using System.Windows.Forms;

public class MultiplayerHandler
{
    public NetworkManager _networkManager { get; private set; }
    public TextBox _inputIpTextbox { get; private set; }
    public TextBox _inputPortTextbox { get; private set; }
    public Label _connectedLabel { get; private set; }

    private Queue<Action> _rpcBuffer;

    //Public
    public Queue<byte> _valueBuffer;

    private bool _autoReadStream = false;
    private bool _AutoReadStream
    {
        get
        {
            return _autoReadStream;
        }

        set
        {
            _autoReadStream = value;
            if (value)
            {
                Thread readerThread = new Thread(AutoRead);
                readerThread.Start();
            }
        }
    }


    //Public
    public List<Action> _rpcList;
    public bool _isHost = false;
    


    public MultiplayerHandler(NetworkManager networkManager, Label ipLabel, TextBox targetIp, TextBox targetPort, Label connectedLabel)
    {
        ipLabel.Text = "ip: " + networkManager.LocalIPAddress.ToString();
        _networkManager = networkManager;
        _inputIpTextbox = targetIp;
        _inputPortTextbox = targetPort;
        _connectedLabel = connectedLabel;

        _rpcList = new List<Action>();
        _rpcBuffer = new Queue<Action>();
        _valueBuffer = new Queue<byte>();
    }

    /// <summary>
    /// Connect to the server of the ip and port given 
    /// in the constructor
    /// </summary>
    public void Connect()
    {
        string ip = _inputIpTextbox.Text.Length > 0 ? _inputPortTextbox.Text : "127.0.0.1"; //Connect to ip, if none was entered, use a standart one  

        bool connection = _networkManager.Connect(_inputIpTextbox.Text, int.Parse(_inputPortTextbox.Text));
        if (!connection)
        {
            _connectedLabel.Text = "Failed!";
            return;
        }


        _AutoReadStream = true; //Checks for rpc calls and new values on the network
        _isHost = false;

        SendRpc(0); //Tell the host that client connected
    }
    
    /// <summary>
    /// Host server on the port given on the constructor
    /// </summary>
    public void Host()
    {
        Thread t = new Thread(() =>
        {
            _networkManager.Host(int.Parse(_inputPortTextbox.Text)); //Wait for connection

            _AutoReadStream = true; //Checks for rpc calls and new values on the network
            _isHost = true;

            SendRpc(0); //Tell client that a connection happened
        });
        t.Start();
    }



    /// <summary>
    /// Reads the stream and stores it's values
    /// 
    /// Values from 0 - 128 go to the valueBuffer, 
    /// Values above 128 are treated as rpc calls, 
    /// 129 calls the rpc 0.
    /// Those rpc calls get saved to the rpc buffer to be
    /// executed later
    /// </summary>
    void AutoRead()
    {
        while (_autoReadStream)
        {
            try
            {
                //Read value
                int result = _networkManager.TcpClient.GetStream().ReadByte();

                if (result > 128)
                {
                    lock (_rpcBuffer)
                    {
                        _rpcBuffer.Enqueue(_rpcList[result - 129]);
                        ExecuteRpcBuffer();
                    }
                }
                else
                {
                    lock (_valueBuffer)
                    {
                        _valueBuffer.Enqueue((byte)result);
                    }
                }

                //Wait for new values
                if (result == -1)
                    Thread.Sleep(50);
            }
            catch (Exception ex)
            {
                _autoReadStream = false;
            }
        }
    }

    /// <summary>
    /// Sends a value to the client, wich writes it to the value buffer
    /// </summary>
    public void SendValue(byte val)
    {
        try
        {
             _networkManager.TcpClient.GetStream().WriteByte(val);
        }
        catch (Exception ex)
        {
            Close();
        }
    }

    /// <summary>
    /// Calls the method index from _rpcList
    /// </summary>
    public void SendRpc(byte index)
    {
        try
        {
            _networkManager.TcpClient.GetStream().WriteByte((byte)(129 + index));
        }
        catch (Exception ex)
        {
            Close();
        }
    }

    /// <summary>
    /// Closes the connection
    /// </summary>
    public void Close()
    {
        _networkManager.TcpClient.Close();
    }

    /// <summary>
    /// Executes all rpcs that got called from clients
    /// on the host
    /// </summary>
    public void ExecuteRpcBuffer()
    {
        lock (_rpcBuffer)
        {
            for (int i = 0; i < _rpcBuffer.Count; i++)
            {
                Action rpc = _rpcBuffer.Dequeue();
                rpc.Invoke();
            }
        }
    }
}
