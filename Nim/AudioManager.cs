using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Media.SoundPlayer;

namespace Nim
{
    public class AudioManager
    {
        private static SoundPlayer _soundPlayer;

        /// <summary>
        /// Loads the audio file form the audio folder
        /// with the input name
        /// The file must be a .wav file.
        /// This overrides the last loaded file
        /// </summary>
        /// <param name="name"></param>
        public static void Load(string name)
        {

            _soundPlayer = new SoundPlayer(GetAudioPath(name));
            _soundPlayer.Load();
        }

        /// <summary>
        /// Plays the audio file last loaded with 
        /// Load()
        /// </summary>
        public static void Play()
        {
            if (_soundPlayer == null)
                return;

            _soundPlayer.Play();
        }

        /// <summary>
        /// Gets an image from the Audio folder
        /// </summary>
        public static string GetAudioPath(string name)
        {
            //Get Path
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"Audio/" + name);
            string sFilePath = Path.GetFullPath(sFile);

            //return the path
            return sFilePath;
        }
    }
}
