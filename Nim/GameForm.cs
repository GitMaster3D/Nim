﻿using Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nim
{
    public partial class GameForm : Form
    {

        //Public
        public GameManager _gameManager;
        public OnlineGame _onlineGame;
        public GameVisualsManager _gameVisualsManager;
        public OnlineGameVisualsManager _onlineGameVisualsManager;
        public bool _started = false;
        public NimBot.Difficulty _difficulty = NimBot.Difficulty.Medium; //Difficulty is medium if no difficulty was selected
        public bool _multiplayer;
        public bool _botmatch;
        public MultiplayerHandler _multiplayerHandler;

        //Control elements
        public Panel _mainGamePanel;
        public Label _matchesLabel;
        public Label _reamainingPicksLabel;
        public Panel _loosePannel;
        public Label _looseLabel;
        public Label _currentPlayerLabel;
        public Panel _controlsPanel;
        public Panel _startPanel;

        //Events
        public Action _closeEvent;


        /// <summary>
        /// Initializes All needed variables for the game
        /// Toggles Visibility of certain elements
        /// </summary>
        public GameForm(Action closeEvent)
        {
            InitializeComponent();

            //Prevent flickering
            this.DoubleBuffered = true;

            //Form elements
            _mainGamePanel = MainGamePanel;
            _matchesLabel = Matches;
            _reamainingPicksLabel = RemainingPicks;
            _looseLabel = LooseLabel;
            _loosePannel = LoosePanel;
            _currentPlayerLabel = CurrentPlayerLabel;
            _controlsPanel = MainControls;
            _startPanel = StartPannel;

            //Disable unneeded panels
            _loosePannel.Visible = false;
            _controlsPanel.Visible = false;

            //Disable unneeded checkboxes
            EasyMode.Visible = false;
            MediumMode.Visible = false;
            HardMode.Visible = false;
            HardestMode.Visible = false;

            //Set event
            _closeEvent = closeEvent;


            //Show instruction background before the game starts
            this._mainGamePanel.BackgroundImage = GameVisualsManager.GetImage("Instructions.png");


            //Multiplayer
            NetworkManager networkManager = new NetworkManager();
            MultiplayerHandler multiplayerHanler = new MultiplayerHandler(networkManager, IpLabel, ConnectIpTextbox, PortTextbox, ConnectedLabel);
            _multiplayerHandler = multiplayerHanler;
            MultiplayerOptionsPanel.Visible = false; //Multiplayer stars as off
            RpcInitializer.InitializeConnectionRpc(multiplayerHanler, this); //Load rpcs needed to start the game


            //Load last port and ip connected to
            ConnectData data = LoadLastConnectionData();
            MainForm.s_lastIp = data.Ip;
            MainForm.s_lastPort = data.Port;

        }



        /// <summary>
        /// Clicked to take 1 match,
        /// up to 3 matches can be taken per turn
        /// </summary>
        private void PickBtn_Click(object sender, EventArgs e)
        {
            if (_started && !_multiplayer)
                _gameManager.TakeOne();
            else if (_started)
                _onlineGame.TakeOne();
        }



        /// <summary>
        /// Click to pass the turn to the opponent
        /// </summary>
        private void PassTurnBtn_Click(object sender, EventArgs e)
        {
            if (_started && !_multiplayer)
                _gameManager.NextTurn();
            else if (_started)
                _onlineGame.NextTurn();
        }




        /// <summary>
        /// Starts the game
        /// </summary>
        private void StartBtn_Click(object sender, EventArgs e)
        {
            //Get match amount
            int matches;
            int.TryParse(MatchesTextbox.Text, out matches);

            //Default match count
            if (MatchesTextbox.Text == "")
                matches = 15;



            //Get player amount
            int players = 1;
            if (!BotmatchCheckbox.Checked)
                int.TryParse(PlayerCountTextbox.Text, out players);

            //Default player count
            if (!BotmatchCheckbox.Checked && PlayerCountTextbox.Text == "")
                players = 2;



            //Start multiplayer game if multiplayer is selected and options are correct
            if (_multiplayer && matches >= 15 && matches < 128 && _multiplayerHandler._isHost)
            {
                //Show game controls for client
                _multiplayerHandler.SendValue((byte)matches);
                _multiplayerHandler.SendRpc(1);
                

                //Show game controls
                _controlsPanel.Visible = true;
                StartPannel.Visible = false;


                //Handle the game logic
                GameStarter starter = new GameStarter();
                _onlineGame = new OnlineGame(matches, this, starter, _multiplayerHandler);
                _onlineGameVisualsManager = new OnlineGameVisualsManager(_onlineGame, this, starter);


                _started = true;


                return;
            }


            //Start the game if the start options are correct
            if ((players >= 2 && players <= 4 && matches >= 15 && matches < 128 && !_multiplayer) || (BotmatchCheckbox.Checked && matches >= 10 && matches < 128 && !_multiplayer))
            {
                StartPannel.Visible = false;

                //Show game controls
                _controlsPanel.Visible = true;


                //Handle the game logic
                GameStarter starter = new GameStarter();
                _gameManager = new GameManager(matches, players, _botmatch, _difficulty, this, starter);
                _gameVisualsManager = new GameVisualsManager(_gameManager, this, starter);

                EndgameBtn.Visible = true;

                //game started
                _started = true;
            }
        }



        /// <summary>
        /// Toggles Between Botmatch and PlayerMatch
        /// </summary>
        private void BotmatchCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //Make player inputfield visible / invisible when needed
            PlayerCountTextbox.Visible = !BotmatchCheckbox.Checked;
            PlayerCountLabel.Visible = !BotmatchCheckbox.Checked;

            _botmatch = BotmatchCheckbox.Checked;

            //Enable difficulty checkboxes when they are needed
            EasyMode.Visible = BotmatchCheckbox.Checked;
            MediumMode.Visible = BotmatchCheckbox.Checked;
            HardMode.Visible = BotmatchCheckbox.Checked;
            HardestMode.Visible = BotmatchCheckbox.Checked;
        }






        CheckBox _lastChecked; //Last checked difficulty box
        /// <summary>
        /// Change Difficulty of the bot to EASY
        /// </summary>
        private void EasyMode_CheckedChanged(object sender, EventArgs e)
        {
            //Make only one box checkable
            CheckBox activeCheckBox = sender as CheckBox;

            if (activeCheckBox != _lastChecked && _lastChecked != null)
                _lastChecked.Checked = false;

            _lastChecked = activeCheckBox.Checked ? activeCheckBox : null;

            //Set difficulty
            _difficulty = NimBot.Difficulty.Easy;
        }



        /// <summary>
        /// Change Difficulty of the bot to MEDIUM
        /// </summary>
        private void MediumMode_CheckedChanged(object sender, EventArgs e)
        {
            //Make only one box checkable
            CheckBox activeCheckBox = sender as CheckBox;

            if (activeCheckBox != _lastChecked && _lastChecked != null)
                _lastChecked.Checked = false;

            _lastChecked = activeCheckBox.Checked ? activeCheckBox : null;

            //Set difficulty
            _difficulty = NimBot.Difficulty.Medium;
        }



        /// <summary>
        /// Change Difficulty of the bot to HARD
        /// </summary>
        private void HardMode_CheckedChanged(object sender, EventArgs e)
        {
            //Make only one box checkable
            CheckBox activeCheckBox = sender as CheckBox;

            if (activeCheckBox != _lastChecked && _lastChecked != null)
                _lastChecked.Checked = false;

            _lastChecked = activeCheckBox.Checked ? activeCheckBox : null;

            //Set difficulty
            _difficulty = NimBot.Difficulty.Hard;
        }



        /// <summary>
        /// Change Difficulty of the bot to HARDEST
        /// </summary>
        private void ImpossibleMode_CheckedChanged(object sender, EventArgs e)
        {
            //Make only one box checkable
            CheckBox activeCheckBox = sender as CheckBox;

            if (activeCheckBox != _lastChecked && _lastChecked != null)
                _lastChecked.Checked = false;

            _lastChecked = activeCheckBox.Checked ? activeCheckBox : null;

            //Set difficulty
            _difficulty = NimBot.Difficulty.Hardest;
        }



        /// <summary>
        /// Closes the game, wich results in the
        /// Mainform shown again
        /// </summary>
        private void RestartBtn_Click(object sender, EventArgs e)
        {
            _closeEvent?.Invoke();
            this.Close();
        }



        /// <summary>
        /// Closes the game, wich results in the
        /// Mainform shown again
        /// </summary>
        private void EndgameBtn_Click(object sender, EventArgs e)
        {
            EndGame();
        }



        /// <summary>
        /// Ends the game, the player ending the game looses
        /// </summary>
        public void EndGame()
        {
            if (_multiplayer)
            {
                if (_onlineGame != null && _onlineGame._matches > 0)
                {
                    _onlineGame._currentPlayer = _onlineGame._player;

                    //Send surrender message
                    _multiplayerHandler.SendValue((byte)_onlineGame._currentPlayer);
                    _multiplayerHandler.SendRpc(2);

                    _onlineGame.Lose();
                }
            }
            else
            {
                if (_gameManager != null && _gameManager._matches > 0)
                {
                    _gameManager.Lose();
                }
            }
        }



        /// <summary>
        /// Connects to entered ip and entered port
        /// </summary>
        private void Connectbtn_Click(object sender, EventArgs e)
        {
            _multiplayerHandler.Connect();

            MainForm.s_lastIp = this.ConnectIpTextbox.Text;
            int port = 0;
            int.TryParse(this.PortTextbox.Text, out port);
            MainForm.s_lastPort = port;

            //Saves connect data
            SaveLastConnection(this.ConnectIpTextbox.Text, port);
        }



        /// <summary>
        /// Hosts a server on the entered port
        /// </summary>
        private void Hostbtn_Click(object sender, EventArgs e)
        {
            _multiplayerHandler.Host();

            MainForm.s_lastIp = this.ConnectIpTextbox.Text;

            int port = 0;
            int.TryParse(this.PortTextbox.Text, out port);
            MainForm.s_lastPort = port;

            //Saves connect data
            SaveLastConnection(this.ConnectIpTextbox.Text, port);
        }



        /// <summary>
        /// Toggles between online and 
        /// offline mode
        /// </summary>
        private void MultiplayerCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _multiplayer = ((CheckBox)sender).Checked;
            MultiplayerOptionsPanel.Visible = _multiplayer;

            //Hide unsupported options
            BotmatchCheckbox.Checked = false;
            BotmatchCheckbox.Visible = !_multiplayer;
            PlayerCountTextbox.Visible = !_multiplayer;
            PlayerCountLabel.Visible = !_multiplayer;
        }



        /// <summary>
        /// Connects / Hosts with the last inputs
        /// </summary>
        private void LastConnectionBtn_Click(object sender, EventArgs e)
        {
            this.PortTextbox.Text = MainForm.s_lastPort.ToString();
            this.ConnectIpTextbox.Text = MainForm.s_lastIp;
        }



        /// <summary>
        /// Saves last Connection (ip and port) to file 
        /// for later recovery
        /// </summary>
        public void SaveLastConnection(string Ip, int port)
        {
            string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"/LastConnection.save";

            using (FileStream fs = File.Open(dirParameter, FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter streamWriter = new StreamWriter(fs);

                //Write
                streamWriter.WriteLine(Ip);
                streamWriter.WriteLine(port);

                //End filestream
                streamWriter.Flush();
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }



        /// <summary>
        /// Loads last used Ip and port from file
        /// </summary>
        public ConnectData LoadLastConnectionData()
        {
            ConnectData data = new ConnectData();

            string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"/LastConnection.save";

            try
            {
                using (FileStream fs = File.Open(dirParameter, FileMode.Open, FileAccess.Read))
                {
                    StreamReader streamReader = new StreamReader(fs);

                    data.Ip = streamReader.ReadLine();
                    data.Port = int.Parse(streamReader.ReadLine());

                    //end filestream
                    streamReader.Close();
                    streamReader.Dispose();
                }

                return data;
            }
            catch (Exception ex)
            {
                data.Port = 0;
                data.Ip = "";
                return data;
            }
        }

        public struct ConnectData
        {
            public int Port;
            public string Ip;
        }
    }
}