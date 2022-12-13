using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nim
{
    public class NimBot
    {
        GameManager _gameManager;
        Difficulty _difficulty;
        Random _rnd; //Cashe random to save process time

        public NimBot(Difficulty difficulty, GameManager gameManager)
        {
            _gameManager = gameManager;
            _difficulty = difficulty;
            _rnd = new Random();
        }



        /// <summary>
        /// Get the best possible amount of matches to remove
        /// </summary>
        int PerfectTurn()
        {
            int take = 0;
            int matches = _gameManager._matches;

            if (matches % 4 == 1)
            {
                // If the bot gets stuck on one of the good
                // Targets, the game is basically lost, except the player makes a mistake,
                // so it takes a random amount of matches
                take = _rnd.Next(1, 4);
            }
            else
            {
                // The good targets are 1, 5, 9 etc. (starting at one, increasing in steps of 4)
                // this calculation results in the takes needed for the next best target
                // If the bot gets to one of these values, it will win the game
                take = (matches + 3) % 4;
            }

            // If the match count is between 4 and 2 (both inclusive),
            // It Can take the remaining Matches and instantly win.
            if (matches <= 4)
            {
                take = matches - 1;
            }

            // Enshure that no illegal turn will be performed
            if (take > 0 && take < 4)
                return take;
            else
                return 1;
        }

        /// <summary>
        /// Bot performs the best possible turn,
        /// on lower difficultys, there is a chance
        /// that the bot does a mistake
        /// </summary>
        /// 
        /// <returns>
        /// The best amount of matches to take,
        /// if a mistake happens, the match amount
        /// is random from 1 - 3
        /// </returns>
        public int Turn()
        {
            // Check if the move failed using the fail
            // rates from the difficulty
            // if a fail happens, the move is random
            int fail = _rnd.Next(1, 102);

            //How many matches to take
            int move;

            if (fail > (int)_difficulty)
            {
                //Executes if the bot didn't make a mistake
                //The best bossible amount of matches to take will be returned
                move = PerfectTurn();
            }
            else
            {
                //Executes if the turn failed, matches to take will
                //Be randomized (1 - 3 matches)
                move = _rnd.Next(1, 4);
            }

            return move;
        }


        /// <summary>
        /// Difficulty mode for the nim bot,
        /// determins the fail rate (chance that the bot returns random matches from 1 - 3,
        /// instead of the best amount of matches)
        /// 
        /// Easy = 100% fail rate
        /// Medium = 60% fail rate
        /// Hard = 20% fail rate
        /// Hardest = 0% fail rate
        /// </summary>
        public enum Difficulty
        {
            Easy = 100, // 100% fail rate
            Medium = 60, // 60% fail rate
            Hard = 20, // 20% fail rate
            Hardest = 0 // 0% fail rate
        }
    }
}
