using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nim
{
    /// <summary>
    /// Handles A Standart game of nim agains either
    /// a bot or local multiplayer from 2 - 4 players
    /// </summary>
    public class GameManager
    {
        //Public:

        //Delegates
        public Action _turnChangeEvent; // called whenever a turn ends
        public Action _pickEvent; // called whenever a match is taken

        public int _matches; // with how many matches the game starts
        public int _maxPicks = 3; // how many matches can be picked per turn
        public int _remainingPicks; // how many matches can be picked in this turn

        public int _currentPlayer; // wich player's turn it currently is
        public int _totalPlayers; //how many players in the game are


        //private
        private bool _botmatch;
        private NimBot _bot;
        private GameForm _form1;
        private int _lastTaken; // Last amount of matches taken by a player
        private int _lastMatchAmount; // Last amount of matches

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
        /// <param name="form1"></param>
        /// The form of the game to toggle certain
        /// elements of the controls etc.
        public GameManager(int matches, int players, bool botmatch, NimBot.Difficulty difficulty, GameForm form1, GameStarter starter)
        {
            Random rnd = new Random(); //Randomizer

            this._matches = matches;
            _remainingPicks = _maxPicks;
            _currentPlayer = rnd.Next(0, players); //Randomize start player
            _totalPlayers = players;
            _botmatch = botmatch;
            _form1 = form1;

            //create bot
            if (botmatch)
            {
                _bot = new NimBot(difficulty, this);

                //Bot may start the game
                starter._startEvent += () =>
                {

                    if (rnd.Next(0, 2) > 0)
                    {
                        //Short delay before bot makes his turn
                        Thread.Sleep(600);
                        BotTurn();
                    }

                };

            }

            //Play take match sound
            _pickEvent += () =>
            {
                AudioManager.Load(_pickSoundName);
                AudioManager.Play();
            };

            //tell the startet that the game logic loaded
            starter._GameLoaded = true;
        }



        /// <summary>
        ///  Tells the Game that 
        ///  the last turn ended
        /// </summary>
        public void NextTurn()
        {
            if (_remainingPicks < _maxPicks)
            {
                //Play turn change sound
                AudioManager.Load(_turnChangeSoundName);
                AudioManager.Play();
                Thread.Sleep(300);


                //Last taken matches
                _lastTaken = 3 - _remainingPicks;

                //Bot turn
                if (_botmatch)
                {
                    if (BotTurn())
                    {
                        return;
                    }
                }

                //Player turn
                LooseCheck(); // ckeck if game ended

                _remainingPicks = 3;
                _currentPlayer = (_currentPlayer + 1) % _totalPlayers; //Cycle through players

                _turnChangeEvent?.Invoke();
            }
        }



        /// <summary>
        /// Bot performs a turn and passes
        /// the turn back to the player
        /// returns true if the bot has
        /// lost the game
        /// </summary>
        public bool BotTurn()
        {

            //Bot is player 2
            _currentPlayer = 1;

            //Remove matches slowly for better visual experience
            int take = _bot.Turn();

            for (int i = 0; i < take; i++)
            {
                _lastMatchAmount = _matches;
                --_matches;
                _pickEvent?.Invoke();

                //Check if bot Lost
                if (BotLooseCheck())
                {
                    return true;
                }

                Thread.Sleep(100);
            }

            //Play turn change sound
            AudioManager.Load(_turnChangeSoundName);
            AudioManager.Play();
            Thread.Sleep(300);

            _currentPlayer = 0;
            _turnChangeEvent?.Invoke();

            return false;
        }



        /// <summary>
        /// Removes one match
        /// </summary>
        public void TakeOne()
        {
            if (_remainingPicks > 0)
            {
                --_matches;
                --_remainingPicks;


                _pickEvent?.Invoke();
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
        /// Call this to let the current player lose
        /// </summary>
        public void Lose()
        {
            //Show game end screen
            _form1._loosePannel.Visible = true;
            _form1._looseLabel.Text = ((Players)_currentPlayer).ToString() + " Lost the game";
            _form1._controlsPanel.Visible = false;

            //Save wich player lost
            int[] val = LeaderboardHandler.GetPlayerLoses();
            val[_currentPlayer]++;
            LeaderboardHandler.SetPlayerLoses(val);

            //Refresh before waiting to avoid lag before showing loose screen
            _form1.Refresh();

            //Load audio
            AudioManager.Load(_loseSoundName);

            //Wait for sounds to finish
            Thread.Sleep(150);

            //Play cool sound
            AudioManager.Play();
        }



        /// <summary>
        /// Specialized loose check for 
        /// bot
        /// </summary>
        public bool BotLooseCheck()
        {
            if (_matches <= 0)
            {
                //Show game end screen
                _form1._loosePannel.Visible = true;
                _form1._looseLabel.Text = "Bot Lost the game";
                _form1._controlsPanel.Visible = false;

                //save that player won against bot
                LeaderboardHandler.s_botLoses += 1;

                //Play Lose sound
                AudioManager.Load(_loseSoundName);
                AudioManager.Play();

                return true;
            }
            return false;
        }


        public enum Players
        {
            Player1= 0,
            Player2 = 1,
            Player3 = 2,
            Player4 = 3
        }

    }
}
