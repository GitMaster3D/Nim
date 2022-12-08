using Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nim
{
    public partial class GameForm : Form
    {
        //Private
        private GameManager _gameManager;
        private OnlineGame _onlineGame;
        private GameVisualsManager _gameVisualsManager;
        private OnlineGameVisualsManager _onlineGameVisualsManager;
        private bool _started = false;
        private NimBot.Difficulty _difficulty = NimBot.Difficulty.Medium; //Difficulty is medium if no difficulty was selected
        private bool _multiplayer;

        //Public
        public bool _botmatch;
        public MultiplayerHandler _multiplayerHandler;

        //Visible elements
        public Panel _mainGamePanel;
        public Label _matchesLabel;
        public Label _reamainingPicksLabel;
        public Panel _loosePannel;
        public Label _looseLabel;
        public Label _currentPlayerLabel;
        public Panel _controlsPanel;

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

            //Starts the game on the client
            Action startGame = () =>
            {
                MethodInvoker inv = delegate
                {
                    //Get match amount
                    int matches = _multiplayerHandler._valueBuffer.Dequeue();

                    //Show game controls
                    _controlsPanel.Visible = true;
                    StartPannel.Visible = false;

                    //Handle the game logic
                    GameStarter starter = new GameStarter();
                    _onlineGame = new OnlineGame(matches, this, starter, multiplayerHanler);
                    _onlineGameVisualsManager = new OnlineGameVisualsManager(_onlineGame, this, starter);

                    _started = true;
                };
                _controlsPanel.Invoke(inv);
            };
            multiplayerHanler._rpcList.Add(startGame);

            //Leaderbord
            multiplayerHanler._rpcList.Add(() =>
            {
                MethodInvoker inv = delegate
                {
                    _onlineGame._currentPlayer = _multiplayerHandler._valueBuffer.Dequeue();

                    _onlineGame.Lose();

                };
                this.Invoke(inv);
            });
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

            //Get player amount
            int players = 1;
            if (!BotmatchCheckbox.Checked)
                int.TryParse(PlayerCountTextbox.Text, out players);

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
                if (_onlineGame != null)
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
                if (_gameManager != null)
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
        }

        /// <summary>
        /// Hosts a server on the entered port
        /// </summary>
        private void Hostbtn_Click(object sender, EventArgs e)
        {
            _multiplayerHandler.Host();
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
    }
}
