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

        /// <summary>
        /// Plays a audio file form the audio folder
        /// with the given name (File type included)
        /// This only works with .wav files
        /// </summary>
        /// <param name="name"></param>
        public static void Play(string name)
        {
            SoundPlayer player = new SoundPlayer(GetAudioPath(name));
            player.Play();
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
