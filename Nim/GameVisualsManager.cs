using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Automation;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Nim
{
    /// <summary>
    /// Handles the visual side of the game
    /// </summary>
    public class GameVisualsManager
    {
        private GameManager _gameManager;
        private List<Image> _backGrounds; // Backgrounds for each player

        /// <summary>
        /// Initialize visual stuff
        /// </summary>
        public GameVisualsManager(GameManager gameManager, GameForm form1, GameStarter starter)
        {
            _gameManager = gameManager;
            _backGrounds = new List<Image>();

             //Get Backgrounds
            _backGrounds.Add(GetImage("RedGradient.png"));
            _backGrounds.Add(GetImage("BlueGradient.png"));
            _backGrounds.Add(GetImage("GreenGradient.png"));
            _backGrounds.Add(GetImage("PurpleGradient.png"));


            //Updates the labels
            Action updateLabels = () =>
            {
                form1._matchesLabel.Text = $"Matches: {gameManager._matches.ToString()}" ;
                form1._reamainingPicksLabel.Text = $"Remaining Picks: {gameManager._remainingPicks.ToString()}";
                form1._currentPlayerLabel.Text = ((GameManager.Players)gameManager._currentPlayer).ToString();
                form1._mainGamePanel.BackgroundImage = _backGrounds[gameManager._currentPlayer];
                form1.Refresh(); // Refresh form for instant visible changes

            };

            //Update labels whenever needed
            updateLabels();
            _gameManager._pickEvent += updateLabels;
            _gameManager._turnChangeEvent += updateLabels;

            //Create Matches
            Stack<PictureBox> pictureBoxes = GenerateMatches(_gameManager._matches, 20, GetImage("Match.png"), form1._mainGamePanel);
            

            //Remove match when a match is picked
            Action removeMatches = () =>
            {
                PictureBox remove = pictureBoxes.Pop(); //Box that should be removed
                HorizontalMove(remove, remove.Location.X + 800, 300);

                form1._mainGamePanel.Controls.Remove(remove); //Remove from form
            };
            _gameManager._pickEvent += removeMatches;

            //Update labels when game starts
            starter._startEvent += updateLabels;

            //Tell the game that visuals have loaded
            starter._VisualsManagerLoaded = true;
        }   



        /// <summary>
        /// Gets an image from the Image folder
        /// </summary>
        public static Image GetImage(string name)
        {
            //Get Path of the image
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"Images/" + name);
            string sFilePath = Path.GetFullPath(sFile);

            //get and return the image
            return Image.FromFile(sFile);
        }


        /// <summary>
        /// Generates Matches for the game
        /// </summary>
        /// 
        /// <param name="amount"></param>
        /// How many matches should be generated
        /// 
        /// <param name="matchImage"></param>
        /// Wich image should be used for the matches
        /// 
        /// <param name="panel"></param>
        /// On wich panel should the matches be shown
        /// 
        /// <param name="offset"></param> 
        /// How far the matches are apart
        public Stack<PictureBox> GenerateMatches(int amount, int offset, Image matchImage, Panel panel)
        {
            Stack<PictureBox> matches = new Stack<PictureBox>();

            for (int i = 0; i < amount; i++)
            {
                //Create Box
                PictureBox pb = new PictureBox();

                //Set position
                pb.Location = new Point(50 + offset * i, 230);

                //Set size
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Size = new Size(12, 150);

                //Ancors
                pb.Anchor = AnchorStyles.Left;


                //Select Image
                pb.Image = matchImage;

                //Show image
                panel.Controls.Add(pb);

                //Save Match
                matches.Push(pb);
            }

            return matches;
        }

        /// <summary>
        /// Vertical slide animation
        /// </summary>
        public void VerticalMove(Control control, float vertical, float duration)
        {
            float yStart = control.Location.Y;
            float y;
            long elapsed = 0;

            Stopwatch sw = new Stopwatch(); 
            while (elapsed < duration)
            {
                sw.Start();

                y = NimMath.LerpUnclamped(yStart, vertical, elapsed);
                control.Location = new Point(control.Location.X, (int)y);

                sw.Stop();
                elapsed = sw.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// Horizontal slide animation
        /// </summary>
        public void HorizontalMove(Control control, float horizontal, float duration)
        {
            float xStart = control.Location.X;
            float x;
            long elapsed = 0;

            Stopwatch sw = new Stopwatch();
            while (elapsed < duration)
            {
                sw.Start();

                x = NimMath.LerpUnclamped(xStart, horizontal, elapsed);
                control.Location = new Point((int)x, control.Location.Y);

                sw.Stop();
                elapsed = sw.ElapsedMilliseconds;
            }
        }

    }
}