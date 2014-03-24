namespace ProjectY
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
            this.pboxStream = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.cboxWebcams = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.pboxTest = new System.Windows.Forms.PictureBox();
            this.pBoxTest2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxStream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTest2)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxStream
            // 
            this.pboxStream.Location = new System.Drawing.Point(12, 12);
            this.pboxStream.Name = "pboxStream";
            this.pboxStream.Size = new System.Drawing.Size(683, 339);
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
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(174, 357);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // pboxTest
            // 
            this.pboxTest.Location = new System.Drawing.Point(701, 12);
            this.pboxTest.Name = "pboxTest";
            this.pboxTest.Size = new System.Drawing.Size(200, 200);
            this.pboxTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxTest.TabIndex = 5;
            this.pboxTest.TabStop = false;
            // 
            // pBoxTest2
            // 
            this.pBoxTest2.Location = new System.Drawing.Point(701, 218);
            this.pBoxTest2.Name = "pBoxTest2";
            this.pBoxTest2.Size = new System.Drawing.Size(200, 200);
            this.pBoxTest2.TabIndex = 6;
            this.pBoxTest2.TabStop = false;
            this.pBoxTest2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 437);
            this.Controls.Add(this.pBoxTest2);
            this.Controls.Add(this.pboxTest);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.cboxWebcams);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pboxStream);
            this.Name = "Window";
            this.Text = "Project Y";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pboxStream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTest2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxStream;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ComboBox cboxWebcams;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.PictureBox pboxTest;
        private System.Windows.Forms.PictureBox pBoxTest2;
    }
}

