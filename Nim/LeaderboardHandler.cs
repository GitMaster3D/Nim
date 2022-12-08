using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nim
{
    public static class LeaderboardHandler
    {

        private static int _botLoses = 0;

        public static int s_botLoses
        {
            get
            {
                return _botLoses;
            }

            set
            {
                _botLoses = value;

                //Save leaderbord to Leaderbord.save
                SaveLeaderboardStats();
            }
        }

        private static int[] s_playerLoses = new int[4];

        public static void SetPlayerLoses(int[] input)
        {
            s_playerLoses = input;

            //Save leaderbord to Leaderbord.save
            SaveLeaderboardStats();
        }

        public static int[] GetPlayerLoses()
        {
            return s_playerLoses;
        }

        /// <summary>
        /// Loads leaderbord from the leaderbord.save file and displays
        /// the values on the leaderbord label
        /// </summary>
        public static void UpdateLeaderboard(Label leaderboard)
        {
            LoadLeaderbordStats();
            leaderboard.Text = $"The bot has lost {s_botLoses} times \n" +
                               $"Player1 has lost {s_playerLoses[0]} times \n" +
                               $"Player2 has lost {s_playerLoses[1]} times \n" +
                               $"Player3 has lost {s_playerLoses[2]} times \n" +
                               $"Player4 has lost {s_playerLoses[3]} times \n";
        }

        /// <summary>
        /// Save Leaderboard values to Leaderboard.save
        /// </summary>
        static void SaveLeaderboardStats()
        {
            string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"/leaderbord.save";

            using (FileStream fs = File.Open(dirParameter, FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter streamWriter = new StreamWriter(fs);
                
                //Write player lose stats
                foreach (var save in s_playerLoses)
                {
                    streamWriter.WriteLine(save);
                }

                //Write bot lost stats
                streamWriter.WriteLine(s_botLoses);

                //End filestream
                streamWriter.Flush();
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }

        /// <summary>
        /// Loads leaderbord stats to the static leaderbord
        /// variables, returns fales it loading failed
        /// </summary>
        static bool LoadLeaderbordStats()
        {
            string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"/leaderbord.save";

            try
            {
                using (FileStream fs = File.Open(dirParameter, FileMode.Open, FileAccess.Read))
                {
                    StreamReader streamReader = new StreamReader(fs);

                    //read playerLose stats
                    for (int i = 0; i < s_playerLoses.Length; i++)
                    {
                        s_playerLoses[i] = int.Parse(streamReader.ReadLine());
                    }

                    //read bot lose stats
                    _botLoses = int.Parse(streamReader.ReadLine());

                    //end filestream
                    streamReader.Close();
                    streamReader.Dispose();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
