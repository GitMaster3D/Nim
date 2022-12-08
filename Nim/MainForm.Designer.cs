namespace Nim
{
    partial class BottomRight_Scale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BottomRight_Scale));
            this.Border = new System.Windows.Forms.Panel();
            this.TopLeft_Scaling = new System.Windows.Forms.Panel();
            this.ScaleTopLeft = new System.Windows.Forms.Panel();
            this.Scale_Up = new System.Windows.Forms.Panel();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.MaximizeBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.StartBtn = new System.Windows.Forms.Button();
            this.BottomLeft = new System.Windows.Forms.Panel();
            this.Scale_Right = new System.Windows.Forms.Panel();
            this.Scale_Left = new System.Windows.Forms.Panel();
            this.Scale_Bottom = new System.Windows.Forms.Panel();
            this.BottomLeft_Scale = new System.Windows.Forms.Panel();
            this.LoseCounterPanel = new System.Windows.Forms.Panel();
            this.Leaderboard = new System.Windows.Forms.Label();
            this.Border.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.LoseCounterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Border
            // 
            this.Border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Border.Controls.Add(this.TopLeft_Scaling);
            this.Border.Controls.Add(this.ScaleTopLeft);
            this.Border.Controls.Add(this.Scale_Up);
            this.Border.Controls.Add(this.MinimizeBtn);
            this.Border.Controls.Add(this.MaximizeBtn);
            this.Border.Controls.Add(this.CloseBtn);
            this.Border.Dock = System.Windows.Forms.DockStyle.Top;
            this.Border.ForeColor = System.Drawing.SystemColors.Control;
            this.Border.Location = new System.Drawing.Point(0, 0);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(1605, 31);
            this.Border.TabIndex = 1;
            this.Border.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Border_MouseDown);
            this.Border.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Border_MouseMove);
            this.Border.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Border_MouseUp);
            // 
            // TopLeft_Scaling
            // 
            this.TopLeft_Scaling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TopLeft_Scaling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.TopLeft_Scaling.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.TopLeft_Scaling.Location = new System.Drawing.Point(1594, 0);
            this.TopLeft_Scaling.Name = "TopLeft_Scaling";
            this.TopLeft_Scaling.Size = new System.Drawing.Size(11, 13);
            this.TopLeft_Scaling.TabIndex = 1;
            this.TopLeft_Scaling.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopLeft_Scaling_MouseDown);
            this.TopLeft_Scaling.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopLeft_Scaling_MouseMove);
            this.TopLeft_Scaling.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopLeft_Scaling_MouseUp);
            // 
            // ScaleTopLeft
            // 
            this.ScaleTopLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ScaleTopLeft.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ScaleTopLeft.Location = new System.Drawing.Point(0, 0);
            this.ScaleTopLeft.Name = "ScaleTopLeft";
            this.ScaleTopLeft.Size = new System.Drawing.Size(10, 13);
            this.ScaleTopLeft.TabIndex = 1;
            this.ScaleTopLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScaleTopLeft_MouseDown);
            this.ScaleTopLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScaleTopLeft_MouseMove);
            this.ScaleTopLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScaleTopLeft_MouseUp);
            // 
            // Scale_Up
            // 
            this.Scale_Up.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Scale_Up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Scale_Up.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.Scale_Up.Location = new System.Drawing.Point(12, 0);
            this.Scale_Up.Name = "Scale_Up";
            this.Scale_Up.Size = new System.Drawing.Size(1376, 13);
            this.Scale_Up.TabIndex = 3;
            this.Scale_Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scale_Up_MouseDown);
            this.Scale_Up.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scale_Up_MouseMove);
            this.Scale_Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scale_Up_MouseUp);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeBtn.BackgroundImage = global::Nim.Properties.Resources.Minimize1;
            this.MinimizeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeBtn.Location = new System.Drawing.Point(1394, 0);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(75, 31);
            this.MinimizeBtn.TabIndex = 2;
            this.MinimizeBtn.UseVisualStyleBackColor = true;
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            // 
            // MaximizeBtn
            // 
            this.MaximizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeBtn.BackgroundImage = global::Nim.Properties.Resources.Maximize1;
            this.MaximizeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MaximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MaximizeBtn.Location = new System.Drawing.Point(1475, 0);
            this.MaximizeBtn.Name = "MaximizeBtn";
            this.MaximizeBtn.Size = new System.Drawing.Size(75, 31);
            this.MaximizeBtn.TabIndex = 1;
            this.MaximizeBtn.UseVisualStyleBackColor = true;
            this.MaximizeBtn.Click += new System.EventHandler(this.MaximizeBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.BackgroundImage = global::Nim.Properties.Resources.Close;
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseBtn.Location = new System.Drawing.Point(1556, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(37, 31);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.MainPanel.BackgroundImage = global::Nim.Properties.Resources.Match;
            this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MainPanel.Controls.Add(this.LoseCounterPanel);
            this.MainPanel.Controls.Add(this.StartBtn);
            this.MainPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainPanel.Location = new System.Drawing.Point(9, 30);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1587, 773);
            this.MainPanel.TabIndex = 0;
            // 
            // StartBtn
            // 
            this.StartBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.StartBtn.Location = new System.Drawing.Point(652, 655);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(281, 103);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // BottomLeft
            // 
            this.BottomLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BottomLeft.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.BottomLeft.Location = new System.Drawing.Point(1595, 802);
            this.BottomLeft.Name = "BottomLeft";
            this.BottomLeft.Size = new System.Drawing.Size(28, 32);
            this.BottomLeft.TabIndex = 0;
            this.BottomLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BottomLeft_MouseDown);
            this.BottomLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BottomLeft_MouseMove);
            this.BottomLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BottomLeft_MouseUp);
            // 
            // Scale_Right
            // 
            this.Scale_Right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Scale_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Scale_Right.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.Scale_Right.ForeColor = System.Drawing.SystemColors.Control;
            this.Scale_Right.Location = new System.Drawing.Point(1595, 31);
            this.Scale_Right.Name = "Scale_Right";
            this.Scale_Right.Size = new System.Drawing.Size(10, 772);
            this.Scale_Right.TabIndex = 1;
            this.Scale_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scale_Right_MouseDown);
            this.Scale_Right.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scale_Right_MouseMove);
            this.Scale_Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scale_Right_MouseUp);
            // 
            // Scale_Left
            // 
            this.Scale_Left.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Scale_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Scale_Left.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.Scale_Left.Location = new System.Drawing.Point(0, 31);
            this.Scale_Left.Name = "Scale_Left";
            this.Scale_Left.Size = new System.Drawing.Size(10, 772);
            this.Scale_Left.TabIndex = 1;
            this.Scale_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scale_Left_MouseDown);
            this.Scale_Left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scale_Left_MouseMove);
            this.Scale_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scale_Left_MouseUp);
            // 
            // Scale_Bottom
            // 
            this.Scale_Bottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Scale_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Scale_Bottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.Scale_Bottom.Location = new System.Drawing.Point(9, 802);
            this.Scale_Bottom.Name = "Scale_Bottom";
            this.Scale_Bottom.Size = new System.Drawing.Size(1587, 10);
            this.Scale_Bottom.TabIndex = 2;
            this.Scale_Bottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scale_Bottom_MouseDown);
            this.Scale_Bottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scale_Bottom_MouseMove);
            this.Scale_Bottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scale_Bottom_MouseUp);
            // 
            // BottomLeft_Scale
            // 
            this.BottomLeft_Scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BottomLeft_Scale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BottomLeft_Scale.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.BottomLeft_Scale.Location = new System.Drawing.Point(0, 802);
            this.BottomLeft_Scale.Name = "BottomLeft_Scale";
            this.BottomLeft_Scale.Size = new System.Drawing.Size(10, 10);
            this.BottomLeft_Scale.TabIndex = 1;
            this.BottomLeft_Scale.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BottomLeft_Scale_MouseDown);
            this.BottomLeft_Scale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BottomLeft_Scale_MouseMove);
            this.BottomLeft_Scale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BottomLeft_Scale_MouseUp);
            // 
            // LoseCounterPanel
            // 
            this.LoseCounterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoseCounterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LoseCounterPanel.Controls.Add(this.Leaderboard);
            this.LoseCounterPanel.Location = new System.Drawing.Point(1276, 17);
            this.LoseCounterPanel.Name = "LoseCounterPanel";
            this.LoseCounterPanel.Size = new System.Drawing.Size(287, 510);
            this.LoseCounterPanel.TabIndex = 1;
            // 
            // Leaderboard
            // 
            this.Leaderboard.AutoSize = true;
            this.Leaderboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Leaderboard.ForeColor = System.Drawing.SystemColors.Control;
            this.Leaderboard.Location = new System.Drawing.Point(15, 11);
            this.Leaderboard.Name = "Leaderboard";
            this.Leaderboard.Size = new System.Drawing.Size(63, 25);
            this.Leaderboard.TabIndex = 0;
            this.Leaderboard.Text = "Wins:";
            // 
            // BottomRight_Scale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1605, 812);
            this.Controls.Add(this.BottomLeft_Scale);
            this.Controls.Add(this.BottomLeft);
            this.Controls.Add(this.Scale_Bottom);
            this.Controls.Add(this.Scale_Left);
            this.Controls.Add(this.Scale_Right);
            this.Controls.Add(this.Border);
            this.Controls.Add(this.MainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BottomRight_Scale";
            this.Text = "Nim";
            this.Border.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.LoseCounterPanel.ResumeLayout(false);
            this.LoseCounterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Panel Border;
        private System.Windows.Forms.Button MinimizeBtn;
        private System.Windows.Forms.Button MaximizeBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Panel Scale_Right;
        private System.Windows.Forms.Panel Scale_Left;
        private System.Windows.Forms.Panel Scale_Bottom;
        private System.Windows.Forms.Panel Scale_Up;
        private System.Windows.Forms.Panel BottomLeft;
        private System.Windows.Forms.Panel BottomLeft_Scale;
        private System.Windows.Forms.Panel ScaleTopLeft;
        private System.Windows.Forms.Panel TopLeft_Scaling;
        private System.Windows.Forms.Panel LoseCounterPanel;
        private System.Windows.Forms.Label Leaderboard;
    }
}