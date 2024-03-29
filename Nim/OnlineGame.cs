﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace Nim
{
    /// <summary>
    /// Handles a online multiplayer game of nim
    /// between 2 players
    /// </summary>
    public class OnlineGame
    {
        //Public:

        //Delegates
        public Action _turnChangeEvent; // called whenever a turn ends
        public Action _pickEvent; // called whenever a match is taken

        public int _matches; // with how many matches the game starts
        public int _maxPicks = 3; // how many matches can be picked per turn
        public int _remainingPicks; // how many matches can be picked in this turn

        public int _currentPlayer; // wich player's turn it currently is
        public int _totalPlayers = 2; //how many players in the game are
        public byte _player; //Wich player you are

        public GameForm _gameForm;
        public MultiplayerHandler _multiplayerHandler;

        //Const
        private const string _pickSoundName = "Cannon impact 9.wav"; //Cashe sound names to avoid allocating garbage
        private const string _turnChangeSoundName = "Magic Spell_Simple Swoosh_6.wav";
        private const string _loseSoundName = "Heheheha.wav";

        /// <summary>
        /// Initialize Needed Game variables
        /// </summary>
        /// 
        /// <param name="matches"></param>
        /// With how many matches the game starts
        /// 
        /// <param name="players"></param>
        /// How many players there are
        /// 
        /// <param name="botmatch"></param>
        /// If a bot is needed
        /// 
        /// <param name="difficulty"></param>
        /// How good that bot should be
        /// 
        /// <param name="gameForm"></param>
        /// The form of the game to toggle certain
        /// elements of the controls etc.
        public OnlineGame(int matches, GameForm gameForm, GameStarter starter, MultiplayerHandler multiplayerHandler)
        {
            Random rnd = new Random(); //Randomizer

            this._matches = matches;
            _remainingPicks = _maxPicks;


            _gameForm = gameForm;
            _multiplayerHandler = multiplayerHandler;

            //tell the startet that the game logic loaded
            starter._GameLoaded = true;

            //Load all needed rpc calls
            RpcInitializer.InitializeOnlinegame(multiplayerHandler, this, gameForm);

         

            //Play take match sound
            _pickEvent += () =>
            {
                AudioManager.Load(_pickSoundName);
                AudioManager.Play();
            };

            //Play turn chage sound
            _turnChangeEvent += () =>
            {
                AudioManager.Load(_turnChangeSoundName);
                AudioManager.Play();
                Thread.Sleep(300);
            };

            //Chose start player
            if (_multiplayerHandler._isHost)
            {
                _currentPlayer = rnd.Next(0, 2);
                _player = 0;

                //Tell client its player
                _multiplayerHandler.SendValue((byte)_currentPlayer);
                _multiplayerHandler.SendRpc(5);
            }
            else
            {
                _player = 1;
            }
        }



        /// <summary>
        ///  Tells the Game that 
        ///  the last turn ended
        /// </summary>
        public void NextTurn()
        {
            if (_remainingPicks < _maxPicks && _player == _currentPlayer)
            {
                _remainingPicks = 3;
                _currentPlayer = (_currentPlayer + 1) % _totalPlayers; //Cycle through players

                _turnChangeEvent?.Invoke();
                Thread.Sleep(300); //Wait for turn change sound to play

                //Send turn change event
                _multiplayerHandler.SendValue((byte)_currentPlayer);
                _multiplayerHandler.SendRpc(4);

                LooseCheck(); // ckeck if game ended
            }
        }



        /// <summary>
        /// Removes one match
        /// </summary>
        public void TakeOne()
        {
            if (_remainingPicks > 0 && _player == _currentPlayer)
            {
                --_matches;
                --_remainingPicks;


                _pickEvent?.Invoke();

                //Send pick event to client
                _multiplayerHandler.SendValue((byte)_matches);
                _multiplayerHandler.SendValue((byte)_remainingPicks);
                _multiplayerHandler.SendRpc(3);

                LooseCheck(); // ckeck if game ended
            }
        }



        /// <summary>
        /// Check if the current player
        /// has lost the game
        /// </summary>
        public void LooseCheck()
        {
            if (_matches <= 0)
            {
                Lose();
            }
        }


        /// <summary>
        /// Shows the lose screen, saves the loser 
        /// to the save file
        /// </summary>
        public void Lose()
        {
            if (_gameForm == null)
                return;

            //Show game end screen
            _gameForm._loosePannel.Visible = true;
            _gameForm._looseLabel.Text = ((Players)_currentPlayer).ToString() + " Lost the game";
            _gameForm._controlsPanel.Visible = false;


            //Save wich player lost
            int[] val = LeaderboardHandler.GetPlayerLoses();
            val[_currentPlayer]++;
            LeaderboardHandler.SetPlayerLoses(val);

            //Play Lose sound
            AudioManager.Load(_loseSoundName);
            AudioManager.Play();

            //End the connection
            _multiplayerHandler.Close();
        }



        public enum Players
        {
            Player1 = 0,
            Player2 = 1,
            Player3 = 2,
            Player4 = 3
        }

    }
}