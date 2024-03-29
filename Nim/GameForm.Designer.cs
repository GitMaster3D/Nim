﻿namespace Nim
{
    partial class GameForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.PickBtn = new System.Windows.Forms.Button();
            this.StartPannel = new System.Windows.Forms.Panel();
            this.MultiplayerCheckbox = new System.Windows.Forms.CheckBox();
            this.MultiplayerOptionsPanel = new System.Windows.Forms.Panel();
            this.LastConnectionBtn = new System.Windows.Forms.Button();
            this.ConnectedLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.IpInputLabel = new System.Windows.Forms.Label();
            this.IpLabel = new System.Windows.Forms.Label();
            this.ConnectIpTextbox = new System.Windows.Forms.TextBox();
            this.Hostbtn = new System.Windows.Forms.Button();
            this.Connectbtn = new System.Windows.Forms.Button();
            this.PortTextbox = new System.Windows.Forms.TextBox();
            this.HardestMode = new System.Windows.Forms.CheckBox();
            this.HardMode = new System.Windows.Forms.CheckBox();
            this.MediumMode = new System.Windows.Forms.CheckBox();
            this.EasyMode = new System.Windows.Forms.CheckBox();
            this.BotmatchCheckbox = new System.Windows.Forms.CheckBox();
            this.PlayerCountLabel = new System.Windows.Forms.Label();
            this.PlayerCountTextbox = new System.Windows.Forms.TextBox();
            this.MatchCountLabel = new System.Windows.Forms.Label();
            this.MatchesTextbox = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.MainControls = new System.Windows.Forms.Panel();
            this.EndgameBtn = new System.Windows.Forms.Button();
            this.CurrentPlayerLabel = new System.Windows.Forms.Label();
            this.PassTurnBtn = new System.Windows.Forms.Button();
            this.RemainingPicks = new System.Windows.Forms.Label();
            this.MainGamePanel = new System.Windows.Forms.Panel();
            this.LoosePanel = new System.Windows.Forms.Panel();
            this.RestartBtn = new System.Windows.Forms.Button();
            this.LooseLabel = new System.Windows.Forms.Label();
            this.Matches = new System.Windows.Forms.Label();
            this.StartPannel.SuspendLayout();
            this.MultiplayerOptionsPanel.SuspendLayout();
            this.MainControls.SuspendLayout();
            this.MainGamePanel.SuspendLayout();
            this.LoosePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PickBtn
            // 
            this.PickBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PickBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PickBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PickBtn.Location = new System.Drawing.Point(3, 0);
            this.PickBtn.Name = "PickBtn";
            this.PickBtn.Size = new System.Drawing.Size(132, 96);
            this.PickBtn.TabIndex = 0;
            this.PickBtn.Text = "Pick";
            this.PickBtn.UseVisualStyleBackColor = true;
            this.PickBtn.Click += new System.EventHandler(this.PickBtn_Click);
            // 
            // StartPannel
            // 
            this.StartPannel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartPannel.Controls.Add(this.MultiplayerCheckbox);
            this.StartPannel.Controls.Add(this.MultiplayerOptionsPanel);
            this.StartPannel.Controls.Add(this.HardestMode);
            this.StartPannel.Controls.Add(this.HardMode);
            this.StartPannel.Controls.Add(this.MediumMode);
            this.StartPannel.Controls.Add(this.EasyMode);
            this.StartPannel.Controls.Add(this.BotmatchCheckbox);
            this.StartPannel.Controls.Add(this.PlayerCountLabel);
            this.StartPannel.Controls.Add(this.PlayerCountTextbox);
            this.StartPannel.Controls.Add(this.MatchCountLabel);
            this.StartPannel.Controls.Add(this.MatchesTextbox);
            this.StartPannel.Controls.Add(this.StartBtn);
            this.StartPannel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartPannel.Location = new System.Drawing.Point(0, 582);
            this.StartPannel.Name = "StartPannel";
            this.StartPannel.Size = new System.Drawing.Size(1305, 114);
            this.StartPannel.TabIndex = 4;
            // 
            // MultiplayerCheckbox
            // 
            this.MultiplayerCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MultiplayerCheckbox.AutoSize = true;
            this.MultiplayerCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiplayerCheckbox.ForeColor = System.Drawing.SystemColors.Control;
            this.MultiplayerCheckbox.Location = new System.Drawing.Point(15, 68);
            this.MultiplayerCheckbox.Name = "MultiplayerCheckbox";
            this.MultiplayerCheckbox.Size = new System.Drawing.Size(175, 36);
            this.MultiplayerCheckbox.TabIndex = 17;
            this.MultiplayerCheckbox.Text = "Multiplayer";
            this.MultiplayerCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MultiplayerCheckbox.UseVisualStyleBackColor = true;
            this.MultiplayerCheckbox.CheckedChanged += new System.EventHandler(this.MultiplayerCheckbox_CheckedChanged);
            // 
            // MultiplayerOptionsPanel
            // 
            this.MultiplayerOptionsPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MultiplayerOptionsPanel.Controls.Add(this.LastConnectionBtn);
            this.MultiplayerOptionsPanel.Controls.Add(this.ConnectedLabel);
            this.MultiplayerOptionsPanel.Controls.Add(this.PortLabel);
            this.MultiplayerOptionsPanel.Controls.Add(this.IpInputLabel);
            this.MultiplayerOptionsPanel.Controls.Add(this.IpLabel);
            this.MultiplayerOptionsPanel.Controls.Add(this.ConnectIpTextbox);
            this.MultiplayerOptionsPanel.Controls.Add(this.Hostbtn);
            this.MultiplayerOptionsPanel.Controls.Add(this.Connectbtn);
            this.MultiplayerOptionsPanel.Controls.Add(this.PortTextbox);
            this.MultiplayerOptionsPanel.Location = new System.Drawing.Point(334, 15);
            this.MultiplayerOptionsPanel.Name = "MultiplayerOptionsPanel";
            this.MultiplayerOptionsPanel.Size = new System.Drawing.Size(406, 96);
            this.MultiplayerOptionsPanel.TabIndex = 16;
            // 
            // LastConnectionBtn
            // 
            this.LastConnectionBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LastConnectionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LastConnectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastConnectionBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.LastConnectionBtn.Location = new System.Drawing.Point(324, 19);
            this.LastConnectionBtn.Name = "LastConnectionBtn";
            this.LastConnectionBtn.Size = new System.Drawing.Size(79, 31);
            this.LastConnectionBtn.TabIndex = 19;
            this.LastConnectionBtn.Text = "Last";
            this.LastConnectionBtn.UseVisualStyleBackColor = true;
            this.LastConnectionBtn.Click += new System.EventHandler(this.LastConnectionBtn_Click);
            // 
            // ConnectedLabel
            // 
            this.ConnectedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectedLabel.AutoSize = true;
            this.ConnectedLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ConnectedLabel.Location = new System.Drawing.Point(328, 56);
            this.ConnectedLabel.Name = "ConnectedLabel";
            this.ConnectedLabel.Size = new System.Drawing.Size(0, 16);
            this.ConnectedLabel.TabIndex = 18;
            // 
            // PortLabel
            // 
            this.PortLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PortLabel.AutoSize = true;
            this.PortLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PortLabel.Location = new System.Drawing.Point(3, 53);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(34, 16);
            this.PortLabel.TabIndex = 17;
            this.PortLabel.Text = "Port:";
            // 
            // IpInputLabel
            // 
            this.IpInputLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IpInputLabel.AutoSize = true;
            this.IpInputLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.IpInputLabel.Location = new System.Drawing.Point(3, 29);
            this.IpInputLabel.Name = "IpInputLabel";
            this.IpInputLabel.Size = new System.Drawing.Size(73, 16);
            this.IpInputLabel.TabIndex = 16;
            this.IpInputLabel.Text = "Connect Ip:";
            // 
            // IpLabel
            // 
            this.IpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.IpLabel.AutoSize = true;
            this.IpLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.IpLabel.Location = new System.Drawing.Point(79, 8);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(22, 16);
            this.IpLabel.TabIndex = 10;
            this.IpLabel.Text = "IP:";
            // 
            // ConnectIpTextbox
            // 
            this.ConnectIpTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConnectIpTextbox.Location = new System.Drawing.Point(91, 27);
            this.ConnectIpTextbox.Name = "ConnectIpTextbox";
            this.ConnectIpTextbox.Size = new System.Drawing.Size(133, 22);
            this.ConnectIpTextbox.TabIndex = 11;
            // 
            // Hostbtn
            // 
            this.Hostbtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Hostbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hostbtn.ForeColor = System.Drawing.SystemColors.Control;
            this.Hostbtn.Location = new System.Drawing.Point(240, 53);
            this.Hostbtn.Name = "Hostbtn";
            this.Hostbtn.Size = new System.Drawing.Size(82, 30);
            this.Hostbtn.TabIndex = 14;
            this.Hostbtn.Text = "Host";
            this.Hostbtn.UseVisualStyleBackColor = true;
            this.Hostbtn.Click += new System.EventHandler(this.Hostbtn_Click);
            // 
            // Connectbtn
            // 
            this.Connectbtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Connectbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Connectbtn.ForeColor = System.Drawing.SystemColors.Control;
            this.Connectbtn.Location = new System.Drawing.Point(240, 20);
            this.Connectbtn.Name = "Connectbtn";
            this.Connectbtn.Size = new System.Drawing.Size(82, 31);
            this.Connectbtn.TabIndex = 12;
            this.Connectbtn.Text = "Connect";
            this.Connectbtn.UseVisualStyleBackColor = true;
            this.Connectbtn.Click += new System.EventHandler(this.Connectbtn_Click);
            // 
            // PortTextbox
            // 
            this.PortTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PortTextbox.Location = new System.Drawing.Point(91, 53);
            this.PortTextbox.Name = "PortTextbox";
            this.PortTextbox.Size = new System.Drawing.Size(97, 22);
            this.PortTextbox.TabIndex = 13;
            // 
            // HardestMode
            // 
            this.HardestMode.AutoSize = true;
            this.HardestMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardestMode.ForeColor = System.Drawing.SystemColors.Control;
            this.HardestMode.Location = new System.Drawing.Point(208, 87);
            this.HardestMode.Name = "HardestMode";
            this.HardestMode.Size = new System.Drawing.Size(102, 29);
            this.HardestMode.TabIndex = 9;
            this.HardestMode.Text = "Hardest";
            this.HardestMode.UseVisualStyleBackColor = true;
            this.HardestMode.CheckedChanged += new System.EventHandler(this.ImpossibleMode_CheckedChanged);
            // 
            // HardMode
            // 
            this.HardMode.AutoSize = true;
            this.HardMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardMode.ForeColor = System.Drawing.SystemColors.Control;
            this.HardMode.Location = new System.Drawing.Point(208, 61);
            this.HardMode.Name = "HardMode";
            this.HardMode.Size = new System.Drawing.Size(76, 29);
            this.HardMode.TabIndex = 8;
            this.HardMode.Text = "Hard";
            this.HardMode.UseVisualStyleBackColor = true;
            this.HardMode.CheckedChanged += new System.EventHandler(this.HardMode_CheckedChanged);
            // 
            // MediumMode
            // 
            this.MediumMode.AutoSize = true;
            this.MediumMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MediumMode.ForeColor = System.Drawing.SystemColors.Control;
            this.MediumMode.Location = new System.Drawing.Point(208, 35);
            this.MediumMode.Name = "MediumMode";
            this.MediumMode.Size = new System.Drawing.Size(104, 29);
            this.MediumMode.TabIndex = 7;
            this.MediumMode.Text = "Medium";
            this.MediumMode.UseVisualStyleBackColor = true;
            this.MediumMode.CheckedChanged += new System.EventHandler(this.MediumMode_CheckedChanged);
            // 
            // EasyMode
            // 
            this.EasyMode.AutoSize = true;
            this.EasyMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyMode.ForeColor = System.Drawing.SystemColors.Control;
            this.EasyMode.Location = new System.Drawing.Point(208, 6);
            this.EasyMode.Name = "EasyMode";
            this.EasyMode.Size = new System.Drawing.Size(78, 29);
            this.EasyMode.TabIndex = 6;
            this.EasyMode.Text = "Easy";
            this.EasyMode.UseVisualStyleBackColor = true;
            this.EasyMode.CheckedChanged += new System.EventHandler(this.EasyMode_CheckedChanged);
            // 
            // BotmatchCheckbox
            // 
            this.BotmatchCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BotmatchCheckbox.AutoSize = true;
            this.BotmatchCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotmatchCheckbox.ForeColor = System.Drawing.SystemColors.Control;
            this.BotmatchCheckbox.Location = new System.Drawing.Point(12, 24);
            this.BotmatchCheckbox.Name = "BotmatchCheckbox";
            this.BotmatchCheckbox.Size = new System.Drawing.Size(156, 36);
            this.BotmatchCheckbox.TabIndex = 5;
            this.BotmatchCheckbox.Text = "Botmatch";
            this.BotmatchCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BotmatchCheckbox.UseVisualStyleBackColor = true;
            this.BotmatchCheckbox.CheckedChanged += new System.EventHandler(this.BotmatchCheckbox_CheckedChanged);
            // 
            // PlayerCountLabel
            // 
            this.PlayerCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PlayerCountLabel.AutoSize = true;
            this.PlayerCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerCountLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PlayerCountLabel.Location = new System.Drawing.Point(830, 30);
            this.PlayerCountLabel.Name = "PlayerCountLabel";
            this.PlayerCountLabel.Size = new System.Drawing.Size(159, 25);
            this.PlayerCountLabel.TabIndex = 4;
            this.PlayerCountLabel.Text = "Player Count 2-4";
            this.PlayerCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerCountTextbox
            // 
            this.PlayerCountTextbox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PlayerCountTextbox.Location = new System.Drawing.Point(835, 60);
            this.PlayerCountTextbox.Name = "PlayerCountTextbox";
            this.PlayerCountTextbox.Size = new System.Drawing.Size(166, 22);
            this.PlayerCountTextbox.TabIndex = 3;
            // 
            // MatchCountLabel
            // 
            this.MatchCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.MatchCountLabel.AutoSize = true;
            this.MatchCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatchCountLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MatchCountLabel.Location = new System.Drawing.Point(1002, 30);
            this.MatchCountLabel.Name = "MatchCountLabel";
            this.MatchCountLabel.Size = new System.Drawing.Size(164, 25);
            this.MatchCountLabel.TabIndex = 2;
            this.MatchCountLabel.Text = "Matches 15 - 128";
            this.MatchCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MatchesTextbox
            // 
            this.MatchesTextbox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.MatchesTextbox.Location = new System.Drawing.Point(1007, 60);
            this.MatchesTextbox.Name = "MatchesTextbox";
            this.MatchesTextbox.Size = new System.Drawing.Size(166, 22);
            this.MatchesTextbox.TabIndex = 1;
            // 
            // StartBtn
            // 
            this.StartBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.StartBtn.Location = new System.Drawing.Point(1184, 6);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(118, 105);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // MainControls
            // 
            this.MainControls.Controls.Add(this.EndgameBtn);
            this.MainControls.Controls.Add(this.CurrentPlayerLabel);
            this.MainControls.Controls.Add(this.PassTurnBtn);
            this.MainControls.Controls.Add(this.RemainingPicks);
            this.MainControls.Controls.Add(this.PickBtn);
            this.MainControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainControls.Location = new System.Drawing.Point(0, 486);
            this.MainControls.Name = "MainControls";
            this.MainControls.Size = new System.Drawing.Size(1305, 96);
            this.MainControls.TabIndex = 5;
            // 
            // EndgameBtn
            // 
            this.EndgameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EndgameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EndgameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndgameBtn.ForeColor = System.Drawing.Color.Red;
            this.EndgameBtn.Location = new System.Drawing.Point(603, 3);
            this.EndgameBtn.Name = "EndgameBtn";
            this.EndgameBtn.Size = new System.Drawing.Size(126, 87);
            this.EndgameBtn.TabIndex = 10;
            this.EndgameBtn.Text = "Surrender";
            this.EndgameBtn.UseVisualStyleBackColor = true;
            this.EndgameBtn.Click += new System.EventHandler(this.EndgameBtn_Click);
            // 
            // CurrentPlayerLabel
            // 
            this.CurrentPlayerLabel.AutoSize = true;
            this.CurrentPlayerLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CurrentPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPlayerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CurrentPlayerLabel.Location = new System.Drawing.Point(1063, 0);
            this.CurrentPlayerLabel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CurrentPlayerLabel.Name = "CurrentPlayerLabel";
            this.CurrentPlayerLabel.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.CurrentPlayerLabel.Size = new System.Drawing.Size(110, 63);
            this.CurrentPlayerLabel.TabIndex = 3;
            this.CurrentPlayerLabel.Text = "Player";
            // 
            // PassTurnBtn
            // 
            this.PassTurnBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.PassTurnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PassTurnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassTurnBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PassTurnBtn.Location = new System.Drawing.Point(1173, 0);
            this.PassTurnBtn.Name = "PassTurnBtn";
            this.PassTurnBtn.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.PassTurnBtn.Size = new System.Drawing.Size(132, 96);
            this.PassTurnBtn.TabIndex = 2;
            this.PassTurnBtn.Text = "Pass Turn";
            this.PassTurnBtn.UseVisualStyleBackColor = true;
            this.PassTurnBtn.Click += new System.EventHandler(this.PassTurnBtn_Click);
            // 
            // RemainingPicks
            // 
            this.RemainingPicks.AutoSize = true;
            this.RemainingPicks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.RemainingPicks.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemainingPicks.ForeColor = System.Drawing.SystemColors.Control;
            this.RemainingPicks.Location = new System.Drawing.Point(141, 35);
            this.RemainingPicks.Name = "RemainingPicks";
            this.RemainingPicks.Size = new System.Drawing.Size(157, 36);
            this.RemainingPicks.TabIndex = 1;
            this.RemainingPicks.Text = "Remaining";
            // 
            // MainGamePanel
            // 
            this.MainGamePanel.AutoSize = true;
            this.MainGamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MainGamePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainGamePanel.Controls.Add(this.LoosePanel);
            this.MainGamePanel.Controls.Add(this.Matches);
            this.MainGamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGamePanel.Location = new System.Drawing.Point(0, 0);
            this.MainGamePanel.Name = "MainGamePanel";
            this.MainGamePanel.Size = new System.Drawing.Size(1305, 486);
            this.MainGamePanel.TabIndex = 6;
            // 
            // LoosePanel
            // 
            this.LoosePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoosePanel.BackColor = System.Drawing.Color.Maroon;
            this.LoosePanel.Controls.Add(this.RestartBtn);
            this.LoosePanel.Controls.Add(this.LooseLabel);
            this.LoosePanel.Location = new System.Drawing.Point(35, 151);
            this.LoosePanel.Name = "LoosePanel";
            this.LoosePanel.Size = new System.Drawing.Size(1209, 211);
            this.LoosePanel.TabIndex = 1;
            // 
            // RestartBtn
            // 
            this.RestartBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RestartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartBtn.Location = new System.Drawing.Point(559, 159);
            this.RestartBtn.Name = "RestartBtn";
            this.RestartBtn.Size = new System.Drawing.Size(135, 50);
            this.RestartBtn.TabIndex = 4;
            this.RestartBtn.Text = "Restart";
            this.RestartBtn.UseVisualStyleBackColor = true;
            this.RestartBtn.Click += new System.EventHandler(this.RestartBtn_Click);
            // 
            // LooseLabel
            // 
            this.LooseLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LooseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LooseLabel.Location = new System.Drawing.Point(0, 0);
            this.LooseLabel.Name = "LooseLabel";
            this.LooseLabel.Size = new System.Drawing.Size(1209, 211);
            this.LooseLabel.TabIndex = 0;
            this.LooseLabel.Text = "Player ? Lost";
            this.LooseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Matches
            // 
            this.Matches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Matches.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Matches.ForeColor = System.Drawing.SystemColors.Control;
            this.Matches.Location = new System.Drawing.Point(10, 10);
            this.Matches.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.Matches.Name = "Matches";
            this.Matches.Size = new System.Drawing.Size(241, 46);
            this.Matches.TabIndex = 0;
            this.Matches.Text = "Matches";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1305, 696);
            this.Controls.Add(this.MainGamePanel);
            this.Controls.Add(this.MainControls);
            this.Controls.Add(this.StartPannel);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.StartPannel.ResumeLayout(false);
            this.StartPannel.PerformLayout();
            this.MultiplayerOptionsPanel.ResumeLayout(false);
            this.MultiplayerOptionsPanel.PerformLayout();
            this.MainControls.ResumeLayout(false);
            this.MainControls.PerformLayout();
            this.MainGamePanel.ResumeLayout(false);
            this.LoosePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel StartPannel;
        private System.Windows.Forms.TextBox MatchesTextbox;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Panel MainControls;
        private System.Windows.Forms.Button PickBtn;
        private System.Windows.Forms.Label RemainingPicks;
        private System.Windows.Forms.Panel MainGamePanel;
        private System.Windows.Forms.Label Matches;
        private System.Windows.Forms.Button PassTurnBtn;
        private System.Windows.Forms.Panel LoosePanel;
        private System.Windows.Forms.Label LooseLabel;
        private System.Windows.Forms.Label CurrentPlayerLabel;
        private System.Windows.Forms.Label MatchCountLabel;
        private System.Windows.Forms.Label PlayerCountLabel;
        private System.Windows.Forms.TextBox PlayerCountTextbox;
        private System.Windows.Forms.CheckBox BotmatchCheckbox;
        private System.Windows.Forms.CheckBox HardestMode;
        private System.Windows.Forms.CheckBox HardMode;
        private System.Windows.Forms.CheckBox MediumMode;
        private System.Windows.Forms.CheckBox EasyMode;
        private System.Windows.Forms.Button RestartBtn;
        private System.Windows.Forms.Button EndgameBtn;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.TextBox ConnectIpTextbox;
        private System.Windows.Forms.Button Connectbtn;
        private System.Windows.Forms.TextBox PortTextbox;
        private System.Windows.Forms.Button Hostbtn;
        private System.Windows.Forms.Panel MultiplayerOptionsPanel;
        private System.Windows.Forms.Label IpInputLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.CheckBox MultiplayerCheckbox;
        private System.Windows.Forms.Label ConnectedLabel;
        private System.Windows.Forms.Button LastConnectionBtn;
    }
}

