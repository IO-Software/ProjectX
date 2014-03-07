namespace ProjectX
{
    partial class Window
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
        private void InitializeComponent(float screenWidth, float screenHeight)
        {
            this.pBoxUp = new System.Windows.Forms.PictureBox();
            this.pBoxDown = new System.Windows.Forms.PictureBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnOnOff = new System.Windows.Forms.Button();
            this.cBoxCam = new System.Windows.Forms.ComboBox();

            ((System.ComponentModel.ISupportInitialize)(this.pBoxUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDown)).BeginInit();
            this.SuspendLayout();

            // 
            // btnOnOff
            // 
            this.btnOnOff.Location = new System.Drawing.Point(210, (int)(screenHeight - 55));
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(200, 30);
            this.btnOnOff.TabIndex = 0;
            this.btnOnOff.Text = "On/Off";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.btnOnOff_Click);

            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(5, (int)(screenHeight - 55));
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(200, 30);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);

            // 
            // pBoxUp
            // 
            this.pBoxUp.Location = new System.Drawing.Point(5, 5);
            this.pBoxUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxUp.Name = "pBoxUp";
            this.pBoxUp.BackColor = System.Drawing.SystemColors.Control;
            this.pBoxUp.Size = new System.Drawing.Size((int)(screenWidth/2), (int)((screenHeight * 0.90)/2));
            this.pBoxUp.TabIndex = 2;
            this.pBoxUp.TabStop = false;

            // 
            // pBoxDown
            // 
            this.pBoxDown.Location = new System.Drawing.Point(5, (int)((screenHeight * 0.90) / 2) - 5);
            this.pBoxDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxDown.Name = "pBoxDown";
            this.pBoxDown.BackColor = System.Drawing.SystemColors.Control;
            this.pBoxDown.Size = new System.Drawing.Size((int)(screenWidth/2), (int)((screenHeight * 0.90) / 2));
            this.pBoxDown.TabIndex = 3;
            this.pBoxDown.TabStop = false;

            // 
            // cBoxCam
            // 
            this.cBoxCam.FormattingEnabled = true;
            this.cBoxCam.Location = new System.Drawing.Point(450, (int)screenHeight - 50);
            this.cBoxCam.Name = "comboBox1";
            this.cBoxCam.Size = new System.Drawing.Size(400, 25);
            this.cBoxCam.TabIndex = 4;

            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size((int)screenWidth, (int)screenHeight);
            this.MinimizeBox = false;
            this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Controls.Add(this.pBoxDown);
            this.Controls.Add(this.pBoxUp);
            this.Controls.Add(btnOnOff);
            this.Controls.Add(btnQuit);
            this.Controls.Add(cBoxCam);
            this.Name = "Window";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxUp)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxUp;
        private System.Windows.Forms.PictureBox pBoxDown;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.ComboBox cBoxCam;

    }
}