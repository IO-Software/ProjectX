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
            this.cBoxGreyscale = new System.Windows.Forms.CheckBox();
            this.cBoxOtsu = new System.Windows.Forms.CheckBox();
            this.tbMinValueEx = new System.Windows.Forms.TrackBar();
            this.tbMaxValueEx = new System.Windows.Forms.TrackBar();
            this.cBoxDraw2D = new System.Windows.Forms.CheckBox();
            this.cBoxDraw3D = new System.Windows.Forms.CheckBox();
            this.cBoxUnknown1 = new System.Windows.Forms.CheckBox();
            this.cbOriginalImage = new System.Windows.Forms.CheckBox();
            this.lblMaxValueEx = new System.Windows.Forms.Label();
            this.lblMinValueEx = new System.Windows.Forms.Label();
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
            // cBoxGreyscale
            // 
            this.cBoxGreyscale.AutoSize = true;
            this.cBoxGreyscale.Location = new System.Drawing.Point(611, 219);
            this.cBoxGreyscale.Name = "cBoxGreyscale";
            this.cBoxGreyscale.Size = new System.Drawing.Size(73, 17);
            this.cBoxGreyscale.TabIndex = 5;
            this.cBoxGreyscale.Text = "Greyscale";
            this.cBoxGreyscale.UseVisualStyleBackColor = true;
            this.cBoxGreyscale.CheckedChanged += new System.EventHandler(this.cBoxGreyscale_CheckedChanged);
            // 
            // cBoxOtsu
            // 
            this.cBoxOtsu.AutoSize = true;
            this.cBoxOtsu.Location = new System.Drawing.Point(611, 242);
            this.cBoxOtsu.Name = "cBoxOtsu";
            this.cBoxOtsu.Size = new System.Drawing.Size(48, 17);
            this.cBoxOtsu.TabIndex = 6;
            this.cBoxOtsu.Text = "Otsu";
            this.cBoxOtsu.UseVisualStyleBackColor = true;
            this.cBoxOtsu.CheckedChanged += new System.EventHandler(this.cBoxOtsu_CheckedChanged);
            // 
            // tbMinValueEx
            // 
            this.tbMinValueEx.Location = new System.Drawing.Point(611, 310);
            this.tbMinValueEx.Name = "tbMinValueEx";
            this.tbMinValueEx.Size = new System.Drawing.Size(212, 45);
            this.tbMinValueEx.TabIndex = 7;
            // 
            // tbMaxValueEx
            // 
            this.tbMaxValueEx.Location = new System.Drawing.Point(611, 374);
            this.tbMaxValueEx.Name = "tbMaxValueEx";
            this.tbMaxValueEx.Size = new System.Drawing.Size(212, 45);
            this.tbMaxValueEx.TabIndex = 8;
            // 
            // cBoxDraw2D
            // 
            this.cBoxDraw2D.AutoSize = true;
            this.cBoxDraw2D.Location = new System.Drawing.Point(611, 265);
            this.cBoxDraw2D.Name = "cBoxDraw2D";
            this.cBoxDraw2D.Size = new System.Drawing.Size(68, 17);
            this.cBoxDraw2D.TabIndex = 9;
            this.cBoxDraw2D.Text = "Draw 2D";
            this.cBoxDraw2D.UseVisualStyleBackColor = true;
            this.cBoxDraw2D.CheckedChanged += new System.EventHandler(this.cBoxDraw2D_CheckedChanged);
            // 
            // cBoxDraw3D
            // 
            this.cBoxDraw3D.AutoSize = true;
            this.cBoxDraw3D.Location = new System.Drawing.Point(690, 219);
            this.cBoxDraw3D.Name = "cBoxDraw3D";
            this.cBoxDraw3D.Size = new System.Drawing.Size(68, 17);
            this.cBoxDraw3D.TabIndex = 10;
            this.cBoxDraw3D.Text = "Draw 3D";
            this.cBoxDraw3D.UseVisualStyleBackColor = true;
            this.cBoxDraw3D.CheckedChanged += new System.EventHandler(this.cBoxDraw3D_CheckedChanged);
            // 
            // cBoxUnknown1
            // 
            this.cBoxUnknown1.AutoSize = true;
            this.cBoxUnknown1.Location = new System.Drawing.Point(690, 242);
            this.cBoxUnknown1.Name = "cBoxUnknown1";
            this.cBoxUnknown1.Size = new System.Drawing.Size(80, 17);
            this.cBoxUnknown1.TabIndex = 11;
            this.cBoxUnknown1.Text = "checkBox5";
            this.cBoxUnknown1.UseVisualStyleBackColor = true;
            // 
            // cbOriginalImage
            // 
            this.cbOriginalImage.AutoSize = true;
            this.cbOriginalImage.Location = new System.Drawing.Point(690, 265);
            this.cbOriginalImage.Name = "cbOriginalImage";
            this.cbOriginalImage.Size = new System.Drawing.Size(93, 17);
            this.cbOriginalImage.TabIndex = 12;
            this.cbOriginalImage.Text = "Original Image";
            this.cbOriginalImage.UseVisualStyleBackColor = true;
            // 
            // lblMaxValueEx
            // 
            this.lblMaxValueEx.AutoSize = true;
            this.lblMaxValueEx.Location = new System.Drawing.Point(624, 358);
            this.lblMaxValueEx.Name = "lblMaxValueEx";
            this.lblMaxValueEx.Size = new System.Drawing.Size(124, 13);
            this.lblMaxValueEx.TabIndex = 13;
            this.lblMaxValueEx.Text = "Maximum value extractor";
            // 
            // lblMinValueEx
            // 
            this.lblMinValueEx.AutoSize = true;
            this.lblMinValueEx.Location = new System.Drawing.Point(624, 294);
            this.lblMinValueEx.Name = "lblMinValueEx";
            this.lblMinValueEx.Size = new System.Drawing.Size(121, 13);
            this.lblMinValueEx.TabIndex = 14;
            this.lblMinValueEx.Text = "Minimum value extractor";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 430);
            this.Controls.Add(this.lblMinValueEx);
            this.Controls.Add(this.lblMaxValueEx);
            this.Controls.Add(this.cbOriginalImage);
            this.Controls.Add(this.cBoxUnknown1);
            this.Controls.Add(this.cBoxDraw3D);
            this.Controls.Add(this.cBoxDraw2D);
            this.Controls.Add(this.tbMaxValueEx);
            this.Controls.Add(this.tbMinValueEx);
            this.Controls.Add(this.cBoxOtsu);
            this.Controls.Add(this.cBoxGreyscale);
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
        private System.Windows.Forms.CheckBox cBoxGreyscale;
        private System.Windows.Forms.CheckBox cBoxOtsu;
        private System.Windows.Forms.TrackBar tbMinValueEx;
        private System.Windows.Forms.TrackBar tbMaxValueEx;
        private System.Windows.Forms.CheckBox cBoxDraw2D;
        private System.Windows.Forms.CheckBox cBoxDraw3D;
        private System.Windows.Forms.CheckBox cBoxUnknown1;
        private System.Windows.Forms.CheckBox cbOriginalImage;
        private System.Windows.Forms.Label lblMaxValueEx;
        private System.Windows.Forms.Label lblMinValueEx;

    }
}