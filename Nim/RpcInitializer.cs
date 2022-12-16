using Nim;
using System;
using System.Windows.Forms;

/// <summary>
/// Used to define and initialize Rpc calls, 
/// new rpc calls should always be added to the bottom of each function
/// </summary>
public static class RpcInitializer
{
    /// <summary>
    /// Rpcs needed to start the game
    /// </summary>
    public static void InitializeConnectionRpc(MultiplayerHandler multiplayerHandler, GameForm gameForm)
    {
        //////////////////////// Multiplayerhandler Rpcs //////////////////////////

        multiplayerHandler._rpcList.Add(() =>
        {
            MethodInvoker inv = delegate
            {
                multiplayerHandler._connectedLabel.Text = "Connected";
            };

            multiplayerHandler._inputIpTextbox.Invoke(inv);
        });




        //////////////////////// Game Form Rpcs //////////////////////////

        //Starts the game on the client
        Action startGame = () =>
        {
            MethodInvoker inv = delegate
            {
                //Get match amount
                int matches = gameForm._multiplayerHandler._valueBuffer.Dequeue();

                //Show game controls
                gameForm._controlsPanel.Visible = true;
                gameForm._startPanel.Visible = false;

                //Handle the game logic
                GameStarter starter = new GameStarter();
                gameForm._onlineGame = new OnlineGame(matches, gameForm, starter, multiplayerHandler);
                gameForm._onlineGameVisualsManager = new OnlineGameVisualsManager(gameForm._onlineGame, gameForm, starter);

                gameForm._started = true;
            };
            gameForm._controlsPanel.Invoke(inv);
        };
        multiplayerHandler._rpcList.Add(startGame);





        //Leaderbord
        multiplayerHandler._rpcList.Add(() =>
        {
            MethodInvoker inv = delegate
            {
                gameForm._onlineGame._currentPlayer = gameForm._multiplayerHandler._valueBuffer.Dequeue();

                gameForm._onlineGame.Lose();

            };
            gameForm.Invoke(inv);
        });
    }

    /// <summary>
    /// Rpcs needed to play but not to start the game
    /// </summary>
    public static void InitializeOnlinegame(MultiplayerHandler multiplayerHandler, OnlineGame onlineGame, GameForm gameForm)
    {
        //////////////////////// Onlinegame Rpcs //////////////////////////

        //Pick on client
        multiplayerHandler._rpcList.Add(() =>
        {
            MethodInvoker inv = delegate
            {
                onlineGame._matches = onlineGame._multiplayerHandler._valueBuffer.Dequeue(); //Get match count
                onlineGame._remainingPicks = onlineGame._multiplayerHandler._valueBuffer.Dequeue(); //Get picks count
                onlineGame._pickEvent?.Invoke();

                onlineGame.LooseCheck();
            };
            onlineGame._gameForm.Invoke(inv); //Run on ui thread
        });



        //Change turn on client
        multiplayerHandler._rpcList.Add(() =>
        {
            MethodInvoker inv = delegate
            {
                onlineGame._remainingPicks = 3;
                onlineGame._currentPlayer = onlineGame._multiplayerHandler._valueBuffer.Dequeue();
                onlineGame._turnChangeEvent?.Invoke();

                onlineGame.LooseCheck();
            };
            onlineGame._gameForm.Invoke(inv); //Run on ui thread
        });




        //Chose start player
        multiplayerHandler._rpcList.Add(() =>
        {
            MethodInvoker inv = delegate
            {
                onlineGame._currentPlayer = onlineGame._multiplayerHandler._valueBuffer.Dequeue();
                onlineGame._turnChangeEvent?.Invoke();
            };
            gameForm.Invoke(inv);
        });
    }
}
