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
        private void InitializeComponent()
        {
            this.pBoxAltered = new System.Windows.Forms.PictureBox();
            this.pBoxOriginal = new System.Windows.Forms.PictureBox();
            this.btnOnOff = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.cBoxCam = new System.Windows.Forms.ComboBox();
            this.tbMinValueEx = new System.Windows.Forms.TrackBar();
            this.tbMaxValueEx = new System.Windows.Forms.TrackBar();
            this.lblMaxValueEx = new System.Windows.Forms.Label();
            this.lblMinValueEx = new System.Windows.Forms.Label();
            this.cBoxChoice = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAltered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinValueEx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxValueEx)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxAltered
            // 
            this.pBoxAltered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxAltered.Location = new System.Drawing.Point(12, 12);
            this.pBoxAltered.Name = "pBoxAltered";
            this.pBoxAltered.Size = new System.Drawing.Size(593, 407);
            this.pBoxAltered.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxAltered.TabIndex = 0;
            this.pBoxAltered.TabStop = false;
            // 
            // pBoxOriginal
            // 
            this.pBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxOriginal.Location = new System.Drawing.Point(611, 12);
            this.pBoxOriginal.Name = "pBoxOriginal";
            this.pBoxOriginal.Size = new System.Drawing.Size(132, 110);
            this.pBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxOriginal.TabIndex = 1;
            this.pBoxOriginal.TabStop = false;
            // 
            // btnOnOff
            // 
            this.btnOnOff.Location = new System.Drawing.Point(611, 155);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(212, 26);
            this.btnOnOff.TabIndex = 2;
            this.btnOnOff.Text = "On/Off";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.btnOnOff_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(611, 187);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(212, 26);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // cBoxCam
            // 
            this.cBoxCam.FormattingEnabled = true;
            this.cBoxCam.Location = new System.Drawing.Point(611, 128);
            this.cBoxCam.Name = "cBoxCam";
            this.cBoxCam.Size = new System.Drawing.Size(212, 21);
            this.cBoxCam.TabIndex = 4;
            // 
            // tbMinValueEx
            // 
            this.tbMinValueEx.Location = new System.Drawing.Point(611, 261);
            this.tbMinValueEx.Maximum = 499;
            this.tbMinValueEx.Minimum = 10;
            this.tbMinValueEx.Name = "tbMinValueEx";
            this.tbMinValueEx.Size = new System.Drawing.Size(212, 45);
            this.tbMinValueEx.TabIndex = 7;
            this.tbMinValueEx.Value = 10;
            this.tbMinValueEx.Scroll += new System.EventHandler(this.tbMinValueEx_Scroll);
            // 
            // tbMaxValueEx
            // 
            this.tbMaxValueEx.Location = new System.Drawing.Point(611, 327);
            this.tbMaxValueEx.Maximum = 500;
            this.tbMaxValueEx.Minimum = 11;
            this.tbMaxValueEx.Name = "tbMaxValueEx";
            this.tbMaxValueEx.Size = new System.Drawing.Size(212, 45);
            this.tbMaxValueEx.TabIndex = 8;
            this.tbMaxValueEx.Value = 500;
            this.tbMaxValueEx.Scroll += new System.EventHandler(this.tbMaxValueEx_Scroll);
            // 
            // lblMaxValueEx
            // 
            this.lblMaxValueEx.AutoSize = true;
            this.lblMaxValueEx.Location = new System.Drawing.Point(624, 311);
            this.lblMaxValueEx.Name = "lblMaxValueEx";
            this.lblMaxValueEx.Size = new System.Drawing.Size(124, 13);
            this.lblMaxValueEx.TabIndex = 13;
            this.lblMaxValueEx.Text = "Maximum value extractor: " + tbMaxValueEx.Value;
            // 
            // lblMinValueEx
            // 
            this.lblMinValueEx.AutoSize = true;
            this.lblMinValueEx.Location = new System.Drawing.Point(624, 245);
            this.lblMinValueEx.Name = "lblMinValueEx";
            this.lblMinValueEx.Size = new System.Drawing.Size(121, 13);
            this.lblMinValueEx.TabIndex = 14;
            this.lblMinValueEx.Text = "Minimum value extractor: " + tbMinValueEx.Value;
            // 
            // cBoxChoice
            // 
            this.cBoxChoice.FormattingEnabled = true;
            this.cBoxChoice.Items.AddRange(new object[] {
            "Greyscale Filter",
            "Otsu Filter",
            "Draw 2D",
            "Draw 3D"});
            this.cBoxChoice.Location = new System.Drawing.Point(611, 219);
            this.cBoxChoice.Name = "cBoxChoice";
            this.cBoxChoice.Size = new System.Drawing.Size(212, 21);
            this.cBoxChoice.TabIndex = 15;
            this.cBoxChoice.SelectedIndexChanged += new System.EventHandler(this.cBox_SelectedIndexChanged);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 430);
            this.Controls.Add(this.cBoxChoice);
            this.Controls.Add(this.lblMinValueEx);
            this.Controls.Add(this.lblMaxValueEx);
            this.Controls.Add(this.tbMaxValueEx);
            this.Controls.Add(this.tbMinValueEx);
            this.Controls.Add(this.cBoxCam);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnOnOff);
            this.Controls.Add(this.pBoxOriginal);
            this.Controls.Add(this.pBoxAltered);
            this.Name = "Window";
            this.Text = "ProjectX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAltered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinValueEx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxValueEx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxAltered;
        private System.Windows.Forms.PictureBox pBoxOriginal;
        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ComboBox cBoxCam;
        private System.Windows.Forms.TrackBar tbMinValueEx;
        private System.Windows.Forms.TrackBar tbMaxValueEx;
        private System.Windows.Forms.Label lblMaxValueEx;
        private System.Windows.Forms.Label lblMinValueEx;
        private System.Windows.Forms.ComboBox cBoxChoice;

    }
}