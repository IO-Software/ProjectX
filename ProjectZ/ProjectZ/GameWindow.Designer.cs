﻿using System;
using System.Collections;
using System.Windows.Forms;
namespace ProjectZ
{
    partial class GameWindow
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
            this.components = new System.ComponentModel.Container();
            this.pBoxGame = new System.Windows.Forms.PictureBox();
            this.firstIntroTimer = new System.Windows.Forms.Timer(this.components);
            this.secondIntroTimer = new System.Windows.Forms.Timer(this.components);
            this.thirdIntroTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenuTimer = new System.Windows.Forms.Timer(this.components);
            this.menuCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.lblPlay = new System.Windows.Forms.Label();
            this.lblHowToPlay = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.lblQuit = new System.Windows.Forms.Label();
            this.lblReturn = new System.Windows.Forms.Label();
            this.lblEasy = new System.Windows.Forms.Label();
            this.lblMedium = new System.Windows.Forms.Label();
            this.lblHard = new System.Windows.Forms.Label();
            this.lblDifficultyExplaination = new System.Windows.Forms.Label();
            this.lblHighScoreExplaination = new System.Windows.Forms.Label();
            this.videoStreamTimer = new System.Windows.Forms.Timer(this.components);
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblInGame = new System.Windows.Forms.Label();
            this.lblMainMenu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxGame)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxGame
            // 
            this.pBoxGame.Location = new System.Drawing.Point(-2, 0);
            this.pBoxGame.Name = "pBoxGame";
            this.pBoxGame.Size = new System.Drawing.Size(100, 50);
            this.pBoxGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxGame.TabIndex = 0;
            this.pBoxGame.TabStop = false;
            // 
            // firstIntroTimer
            // 
            this.firstIntroTimer.Tick += new System.EventHandler(this.firstIntroTick);
            // 
            // secondIntroTimer
            // 
            this.secondIntroTimer.Tick += new System.EventHandler(this.secondIntroTick);
            // 
            // thirdIntroTimer
            // 
            this.thirdIntroTimer.Tick += new System.EventHandler(this.thirdIntroTick);
            // 
            // mainMenuTimer
            // 
            this.mainMenuTimer.Tick += new System.EventHandler(this.mainMenuTick);
            // 
            // menuCheckTimer
            // 
            this.menuCheckTimer.Interval = 10;
            this.menuCheckTimer.Tick += new System.EventHandler(this.menuCheckTick);
            // 
            // lblPlay
            // 
            this.lblPlay.AutoSize = true;
            this.lblPlay.Location = new System.Drawing.Point(332, 109);
            this.lblPlay.Name = "lblPlay";
            this.lblPlay.Size = new System.Drawing.Size(37, 13);
            this.lblPlay.TabIndex = 6;
            this.lblPlay.Text = "lblPlay";
            // 
            // lblHowToPlay
            // 
            this.lblHowToPlay.AutoSize = true;
            this.lblHowToPlay.Location = new System.Drawing.Point(241, 154);
            this.lblHowToPlay.Name = "lblHowToPlay";
            this.lblHowToPlay.Size = new System.Drawing.Size(72, 13);
            this.lblHowToPlay.TabIndex = 7;
            this.lblHowToPlay.Text = "lblHowToPlay";
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Location = new System.Drawing.Point(218, 112);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(67, 13);
            this.lblHighScore.TabIndex = 8;
            this.lblHighScore.Text = "lblHighScore";
            // 
            // lblQuit
            // 
            this.lblQuit.AutoSize = true;
            this.lblQuit.Location = new System.Drawing.Point(168, 182);
            this.lblQuit.Name = "lblQuit";
            this.lblQuit.Size = new System.Drawing.Size(36, 13);
            this.lblQuit.TabIndex = 9;
            this.lblQuit.Text = "lblQuit";
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Location = new System.Drawing.Point(178, 129);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(49, 13);
            this.lblReturn.TabIndex = 10;
            this.lblReturn.Text = "lblReturn";
            // 
            // lblEasy
            // 
            this.lblEasy.AutoSize = true;
            this.lblEasy.Location = new System.Drawing.Point(223, 194);
            this.lblEasy.Name = "lblEasy";
            this.lblEasy.Size = new System.Drawing.Size(40, 13);
            this.lblEasy.TabIndex = 11;
            this.lblEasy.Text = "lblEasy";
            // 
            // lblMedium
            // 
            this.lblMedium.AutoSize = true;
            this.lblMedium.Location = new System.Drawing.Point(363, 138);
            this.lblMedium.Name = "lblMedium";
            this.lblMedium.Size = new System.Drawing.Size(54, 13);
            this.lblMedium.TabIndex = 12;
            this.lblMedium.Text = "lblMedium";
            // 
            // lblHard
            // 
            this.lblHard.AutoSize = true;
            this.lblHard.Location = new System.Drawing.Point(199, 141);
            this.lblHard.Name = "lblHard";
            this.lblHard.Size = new System.Drawing.Size(40, 13);
            this.lblHard.TabIndex = 13;
            this.lblHard.Text = "lblHard";
            // 
            // lblDifficultyExplaination
            // 
            this.lblDifficultyExplaination.AutoSize = true;
            this.lblDifficultyExplaination.Location = new System.Drawing.Point(273, 72);
            this.lblDifficultyExplaination.Name = "lblDifficultyExplaination";
            this.lblDifficultyExplaination.Size = new System.Drawing.Size(114, 13);
            this.lblDifficultyExplaination.TabIndex = 14;
            this.lblDifficultyExplaination.Text = "lblDifficultyExplaination";
            // 
            // lblHighScoreExplaination
            // 
            this.lblHighScoreExplaination.AutoSize = true;
            this.lblHighScoreExplaination.Location = new System.Drawing.Point(237, 149);
            this.lblHighScoreExplaination.Name = "lblHighScoreExplaination";
            this.lblHighScoreExplaination.Size = new System.Drawing.Size(124, 13);
            this.lblHighScoreExplaination.TabIndex = 15;
            this.lblHighScoreExplaination.Text = "lblHighScoreExplaination";
            // 
            // videoStreamTimer
            // 
            this.videoStreamTimer.Interval = 1;
            this.videoStreamTimer.Tick += new System.EventHandler(this.videoStreamTimer_Tick);
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // lblInGame
            // 
            this.lblInGame.AutoSize = true;
            this.lblInGame.Location = new System.Drawing.Point(440, 141);
            this.lblInGame.Name = "lblInGame";
            this.lblInGame.Size = new System.Drawing.Size(54, 13);
            this.lblInGame.TabIndex = 16;
            this.lblInGame.Text = "lblInGame";
            // 
            // lblMainMenu
            // 
            this.lblMainMenu.AutoSize = true;
            this.lblMainMenu.Location = new System.Drawing.Point(219, 169);
            this.lblMainMenu.Name = "lblMainMenu";
            this.lblMainMenu.Size = new System.Drawing.Size(67, 13);
            this.lblMainMenu.TabIndex = 17;
            this.lblMainMenu.Text = "lblMainMenu";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(577, 412);
            this.Controls.Add(this.lblMainMenu);
            this.Controls.Add(this.lblInGame);
            this.Controls.Add(this.lblHighScoreExplaination);
            this.Controls.Add(this.lblDifficultyExplaination);
            this.Controls.Add(this.lblHard);
            this.Controls.Add(this.lblMedium);
            this.Controls.Add(this.lblEasy);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.lblQuit);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.lblHowToPlay);
            this.Controls.Add(this.lblPlay);
            this.Controls.Add(this.pBoxGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ---------------- EVENT HANDLERS ---------------------------------------------------------------------------------
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (status == STATUSINTRO)
                {
                    firstIntroTimer.Enabled = false;
                    secondIntroTimer.Enabled = false;
                    thirdIntroTimer.Enabled = false;
                    mainMenuTimer.Enabled = true;
                }
                else if (status == STATUSHIGHSCORE || status == STATUSHOWTOPLAY || status == STATUSSELECTDIFFICULTY)
                {
                    status = STATUSMAINMENU;
                }
                else if (status == STATUSMAINGAME)
                {
                    status = STATUSPAUSE;
                    ball.pauseBall();
                    videoStreamTimer.Stop();
                    GameTimer.Stop();
                    menuCheckTimer.Start();
                    pBoxGame.Image = ChangeOpacity.change(webcam.getStreamImage(), (float)0.5);
                }
                else if (status == STATUSPAUSE)
                {
                    status = STATUSMAINGAME;
                    ball.resumeBall();
                    videoStreamTimer.Start();
                    GameTimer.Start();
                    menuCheckTimer.Stop();
                }
            }
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webcam.isRunning())
            {
                webcam.stop();
            }
        }

        private void leaveGame(object sender, EventArgs e)
        {
            Console.WriteLine("Application Exit");
            Application.Exit();
        }

        private void enterMainMenu(object sender, EventArgs e)
        {
            status = STATUSMAINMENU;
        }

        private void enterHighScoreMenu(object sender, EventArgs e)
        {
            status = STATUSHIGHSCORE;
        }

        private void enterHowToPlayMenu(object sender, EventArgs e)
        {
            status = STATUSHOWTOPLAY;
        }

        private void enterDifficultyMenu(object sender, EventArgs e)
        {
            status = STATUSSELECTDIFFICULTY;
        }

        private void returnClick(object sender, EventArgs e)
        {
            if (status != STATUSMAINMENU)
            {
                status = STATUSMAINMENU;
            }
        }

        private void easyClick(object sender, EventArgs e)
        {
            ball.setSpeedBall(easySpeed);
            startGame();
        }

        private void mediumClick(object sender, EventArgs e)
        {
            ball.setSpeedBall(mediumSpeed);
            startGame();
        }

        private void hardClick(object sender, EventArgs e)
        {
            ball.setSpeedBall(hardSpeed);
            startGame();
        }

        private void returnToMainMenu(object sender, EventArgs e)
        {
            GameTimer.Stop();
            videoStreamTimer.Stop();
            startMenu();
        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxGame;
        private System.Windows.Forms.Timer firstIntroTimer;
        private System.Windows.Forms.Timer secondIntroTimer;
        private System.Windows.Forms.Timer thirdIntroTimer;
        private System.Windows.Forms.Timer mainMenuTimer;
        private System.Windows.Forms.Timer menuCheckTimer;
        private System.Windows.Forms.Label lblPlay;
        private System.Windows.Forms.Label lblHowToPlay;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.Label lblQuit;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label lblEasy;
        private System.Windows.Forms.Label lblMedium;
        private System.Windows.Forms.Label lblHard;
        private System.Windows.Forms.Label lblDifficultyExplaination;
        private System.Windows.Forms.Label lblHighScoreExplaination;
        private System.Windows.Forms.Timer videoStreamTimer;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label lblInGame;
        private System.Windows.Forms.Label lblMainMenu;
    }
}