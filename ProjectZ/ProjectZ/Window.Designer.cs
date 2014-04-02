namespace ProjectZ
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pboxStream = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.cboxWebcams = new System.Windows.Forms.ComboBox();
            this.pboxTest = new System.Windows.Forms.PictureBox();
            this.videoStreamTimer = new System.Windows.Forms.Timer(this.components);
            this.pboxTest2 = new System.Windows.Forms.PictureBox();
            this.lblAmountOfBlobs = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxStream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTest2)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxStream
            // 
            this.pboxStream.Location = new System.Drawing.Point(12, 12);
            this.pboxStream.Name = "pboxStream";
            this.pboxStream.Size = new System.Drawing.Size(680, 340);
            this.pboxStream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxStream.TabIndex = 0;
            this.pboxStream.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 357);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(93, 357);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // cboxWebcams
            // 
            this.cboxWebcams.FormattingEnabled = true;
            this.cboxWebcams.Location = new System.Drawing.Point(379, 359);
            this.cboxWebcams.Name = "cboxWebcams";
            this.cboxWebcams.Size = new System.Drawing.Size(316, 21);
            this.cboxWebcams.TabIndex = 3;
            // 
            // pboxTest
            // 
            this.pboxTest.Location = new System.Drawing.Point(701, 12);
            this.pboxTest.Name = "pboxTest";
            this.pboxTest.Size = new System.Drawing.Size(248, 237);
            this.pboxTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxTest.TabIndex = 5;
            this.pboxTest.TabStop = false;
            // 
            // videoStreamTimer
            // 
            this.videoStreamTimer.Interval = 1;
            this.videoStreamTimer.Tick += new System.EventHandler(this.videoStreamTimer_Tick);
            // 
            // pboxTest2
            // 
            this.pboxTest2.Location = new System.Drawing.Point(701, 255);
            this.pboxTest2.Name = "pboxTest2";
            this.pboxTest2.Size = new System.Drawing.Size(248, 207);
            this.pboxTest2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxTest2.TabIndex = 6;
            this.pboxTest2.TabStop = false;
            // 
            // lblAmountOfBlobs
            // 
            this.lblAmountOfBlobs.AutoSize = true;
            this.lblAmountOfBlobs.Location = new System.Drawing.Point(12, 399);
            this.lblAmountOfBlobs.Name = "lblAmountOfBlobs";
            this.lblAmountOfBlobs.Size = new System.Drawing.Size(83, 13);
            this.lblAmountOfBlobs.TabIndex = 7;
            this.lblAmountOfBlobs.Text = "Amount of blobs";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(12, 422);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(71, 13);
            this.lblElapsedTime.TabIndex = 8;
            this.lblElapsedTime.Text = "Elapsed Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "label4";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 542);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.lblAmountOfBlobs);
            this.Controls.Add(this.pboxTest2);
            this.Controls.Add(this.pboxTest);
            this.Controls.Add(this.cboxWebcams);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pboxStream);
            this.Name = "Window";
            this.Text = "Project Y";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pboxStream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTest2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxStream;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ComboBox cboxWebcams;
        private System.Windows.Forms.PictureBox pboxTest;
        private System.Windows.Forms.Timer videoStreamTimer;
        private System.Windows.Forms.PictureBox pboxTest2;
        private System.Windows.Forms.Label lblAmountOfBlobs;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

