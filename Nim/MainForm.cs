using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nim
{
    public partial class MainForm : Form
    {
        //Private 

        bool _dragging; //Is the mouse pressed on the border?
        bool _maximized; //Is the window Maximized?
        bool _scaling; //Is the window being scaled?

        Point _startPoint = new Point(0, 0);

        GameForm _gameForm;



        //Public
        public static GameForm.LastConnection s_lastConnection;
        public static string s_lastIp = "";
        public static int s_lastPort = 0;   



        public MainForm()
        {
            //Fix scaling issue on unusual displays where part of the form is cut of
            this.AutoScaleMode = AutoScaleMode.Dpi;

            //Prevent flickering when resizing
            this.DoubleBuffered = true;

            InitializeComponent();

            //Limit size to avoid scaling issues
            this.MinimumSize = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.None;

            //Load leaderborard texts
            LeaderboardHandler.UpdateLeaderboard(Leaderboard);
        }


        /// <summary>
        /// Creates a new Nim-Game and 
        /// enbeds it into the form
        /// </summary>
        void EmbedGame(Action closeEvent)
        {
            GameForm form1 = new GameForm(closeEvent);
            form1.Visible = true;
            form1.TopLevel = false;
            form1.FormBorderStyle = FormBorderStyle.None;
            form1.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(form1);

            _gameForm = form1;
        }

        /// <summary>
        /// Starts the game, then hides itself until
        /// the game ends
        /// </summary>
        private void StartBtn_Click(object sender, EventArgs e)
        {
            EmbedGame(() =>
            {
                ((Control)sender).Visible = true;
                this.LoseCounterPanel.Visible = true;

                //Load leaderborard texts
                LeaderboardHandler.UpdateLeaderboard(Leaderboard);
            });
            
            ((Control)sender).Visible = false;
            this.LoseCounterPanel.Visible = false;
        }


        /// <summary>
        /// The following 3 functions handle
        /// Dragging the window around
        /// </summary>
        private void Border_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _startPoint = new Point(e.X, e.Y);
        }

        private void Border_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._startPoint.X, p.Y - this._startPoint.Y);
            }
        }

        /// <summary>
        /// Close Button
        /// </summary>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            _gameForm?.EndGame();
            Environment.Exit(0);
        }

        /// <summary>
        /// Maximize window
        /// </summary>
        private void MaximizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = _maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            _maximized = !_maximized;
        }

        /// <summary>
        /// Minimize window
        /// </summary>
        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// The following 3 functions handle scaling the window on the left side
        /// </summary>
        Point _lastScalePoint;
        private void Scale_Left_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = true;
        }

        private void Scale_Left_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = false;
        }

        private void Scale_Left_MouseMove(object sender, MouseEventArgs e)
        {
            if (_scaling)
            {
                //Where the window should end
                int diff = (e.Location.X - _lastScalePoint.X);
                int x = (this.Location.X + diff);

                //Calculate wanted size
                Size target = new Size((this.Width - diff), this.Height);

                //Prevent pushing the window around when minimum size is reached
                if (target.Width < this.MinimumSize.Width)
                    return;

                //Rescale and move the window at the same time to create
                //The illusion that it is scaled from the left side
                this.Location = new Point(x, this.Location.Y);
                this.Size = target;

                //Refresh to prevent artifacts
                this.Refresh();
            }
        }


        /// <summary>
        /// The following 3 functions handle
        /// Scaling the window form the right side
        /// </summary>
        private void Scale_Right_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = true;
        }

        private void Scale_Right_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = false;
        }

        private void Scale_Right_MouseMove(object sender, MouseEventArgs e)
        {
            if (_scaling)
            {
                //Where the window should end
                int diff = (e.Location.X - _lastScalePoint.X);

                //Resize the right side
                this.Size = new Size(this.Width + diff, this.Height);

                //Refresh to prevent artifacts
                this.Refresh();
            }
        }

        /// <summary>
        /// The following 3 functions handle
        /// Scaling the window form the Bottom
        /// </summary>
        private void Scale_Bottom_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = true;
        }

        private void Scale_Bottom_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = false;
        }

        private void Scale_Bottom_MouseMove(object sender, MouseEventArgs e)
        {
            if (_scaling)
            {
                //where the window should end
                int diff = (e.Location.Y - _lastScalePoint.Y);

                //Rescale
                this.Size = new Size(this.Width, this.Height + diff);

                //Refresh to prevent artifacts
                this.Refresh();
            }
        }

        /// <summary>
        /// The following 3 functions handle
        /// Scaling the window form the top
        /// </summary>
        private void Scale_Up_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = true;
        }

        private void Scale_Up_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = false;
        }

        private void Scale_Up_MouseMove(object sender, MouseEventArgs e)
        {
            if (_scaling)
            {
                //Where the window should end
                int diff = (e.Location.Y - _lastScalePoint.Y);
                int y = (this.Location.Y + diff);

                //Calculate wanted size
                Size target = new Size(this.Width , this.Height - diff);

                //Prevent pushing the window around when minimum size is reached
                if (target.Height < this.MinimumSize.Height)
                    return;

                //Rescale and move the window at the same time to create
                //The illusion that it is scaled from the top
                this.Location = new Point(this.Location.X, y);
                this.Size = target;

                //Refresh to prevent artifacts
                this.Refresh();
            }
        }


        /// <summary>
        /// The following 3 functions handle
        /// Scaling the window form the Bottom Right
        /// </summary>
        private void BottomLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = true;
        }

        private void BottomLeft_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = false;
        }

        private void BottomLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (_scaling)
            {
                //Where the window should end
                int diff = (e.Location.X - _lastScalePoint.X);

                //Resize the right side
                this.Size = new Size(this.Width + diff, this.Height);

                //where the window should end
                diff = (e.Location.Y - _lastScalePoint.Y);

                //Rescale
                this.Size = new Size(this.Width, this.Height + diff);

                //Refresh to prevent artifacts
                this.Refresh();
            }
        }

        /// <summary>
        /// The following 3 functions handle
        /// Scaling the window form the Bottom Left
        /// </summary>
        private void BottomLeft_Scale_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = true;
        }

        private void BottomLeft_Scale_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = false;
        }

        private void BottomLeft_Scale_MouseMove(object sender, MouseEventArgs e)
        {
            if (_scaling)
            {
                //where the window should end
                int diff = (e.Location.Y - _lastScalePoint.Y);

                //Rescale
                this.Size = new Size(this.Width, this.Height + diff);


                //Where the window should end
                diff = (e.Location.X - _lastScalePoint.X);
                int x = (this.Location.X + diff);

                //Calculate wanted size
                Size target = new Size((this.Width - diff), this.Height);

                //Prevent pushing the window around when minimum size is reached
                if (target.Width < this.MinimumSize.Width)
                    return;

                //Rescale and move the window at the same time to create
                //The illusion that it is scaled from the left side
                this.Location = new Point(x, this.Location.Y);
                this.Size = target;

                //Refresh to prevent artifacts
                this.Refresh();
            }
        }

        /// <summary>
        /// The following 3 functions handle
        /// Scaling the window form the Top left
        /// </summary>
        private void ScaleTopLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = true;
        }

        private void ScaleTopLeft_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = false;
        }

        private void ScaleTopLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (_scaling)
            {
                //Where the window should end
                int diff = (e.Location.Y - _lastScalePoint.Y);
                int y = (this.Location.Y + diff);

                //Calculate wanted size
                Size target = new Size(this.Width, this.Height - diff);

                //Prevent pushing the window around when minimum size is reached
                if (target.Height < this.MinimumSize.Height)
                    goto xScaling;

                //Rescale and move the window at the same time to create
                //The illusion that it is scaled from the top
                this.Location = new Point(this.Location.X, y);
                this.Size = target;


            xScaling:;
                //Where the window should end
                diff = (e.Location.X - _lastScalePoint.X);
                int x = (this.Location.X + diff);

                //Calculate wanted size
                target = new Size((this.Width - diff), this.Height);

                //Prevent pushing the window around when minimum size is reached
                if (target.Width < this.MinimumSize.Width)
                {
                    //Refresh to prevent artifacts
                    this.Refresh();
                    return;
                }

                //Rescale and move the window at the same time to create
                //The illusion that it is scaled from the left side
                this.Location = new Point(x, this.Location.Y);
                this.Size = target;

                //Refresh to prevent artifacts
                this.Refresh();
            }

        }

        /// <summary>
        /// The following 3 functions handle
        /// Scaling the window form the Top Right
        /// </summary>
        private void TopLeft_Scaling_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = true;
        }

        private void TopLeft_Scaling_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_maximized) //Prevent scaling bugs
                _scaling = false;
        }

        private void TopLeft_Scaling_MouseMove(object sender, MouseEventArgs e)
        {
            if (_scaling)
            {
                //Where the window should end
                int diff = (e.Location.Y - _lastScalePoint.Y);
                int y = (this.Location.Y + diff);

                //Calculate wanted size
                Size target = new Size(this.Width, this.Height - diff);

                //Prevent pushing the window around when minimum size is reached
                if (target.Height < this.MinimumSize.Height)
                    goto xScaling;

                //Rescale and move the window at the same time to create
                //The illusion that it is scaled from the top
                this.Location = new Point(this.Location.X, y);
                this.Size = target;

            xScaling:;

                //Where the window should end
                diff = (e.Location.X - _lastScalePoint.X);

                //Resize the right side
                this.Size = new Size(this.Width + diff, this.Height);

                //Refresh to prevent artifacts
                this.Refresh();
            }
        }
    }
}
