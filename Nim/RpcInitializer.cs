using Nim;
using System;
using System.Windows.Forms;

public static class RpcInitializer
{
    public static void Initialize(MultiplayerHandler multiplayerHandler, GameForm gameForm)
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
}
