namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbGreyScale = new System.Windows.Forms.CheckBox();
            this.cbRemoveBlobs = new System.Windows.Forms.CheckBox();
            this.lBlob = new System.Windows.Forms.Label();
            this.cb3D = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 313);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 331);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(398, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(398, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start / Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(419, 111);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(109, 76);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // cbGreyScale
            // 
            this.cbGreyScale.AutoSize = true;
            this.cbGreyScale.Location = new System.Drawing.Point(417, 13);
            this.cbGreyScale.Name = "cbGreyScale";
            this.cbGreyScale.Size = new System.Drawing.Size(75, 17);
            this.cbGreyScale.TabIndex = 13;
            this.cbGreyScale.Text = "GreyScale";
            this.cbGreyScale.UseVisualStyleBackColor = true;
            // 
            // cbRemoveBlobs
            // 
            this.cbRemoveBlobs.AutoSize = true;
            this.cbRemoveBlobs.Location = new System.Drawing.Point(417, 36);
            this.cbRemoveBlobs.Name = "cbRemoveBlobs";
            this.cbRemoveBlobs.Size = new System.Drawing.Size(92, 17);
            this.cbRemoveBlobs.TabIndex = 14;
            this.cbRemoveBlobs.Text = "RemoveBlobs";
            this.cbRemoveBlobs.UseVisualStyleBackColor = true;
            // 
            // lBlob
            // 
            this.lBlob.AutoSize = true;
            this.lBlob.Location = new System.Drawing.Point(416, 95);
            this.lBlob.Name = "lBlob";
            this.lBlob.Size = new System.Drawing.Size(28, 13);
            this.lBlob.TabIndex = 15;
            this.lBlob.Text = "Blob";
            // 
            // cb3D
            // 
            this.cb3D.AutoSize = true;
            this.cb3D.Location = new System.Drawing.Point(417, 59);
            this.cb3D.Name = "cb3D";
            this.cb3D.Size = new System.Drawing.Size(76, 17);
            this.cb3D.TabIndex = 16;
            this.cb3D.Text = "3D Effects";
            this.cb3D.UseVisualStyleBackColor = true;
            this.cb3D.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 397);
            this.Controls.Add(this.cb3D);
            this.Controls.Add(this.lBlob);
            this.Controls.Add(this.cbRemoveBlobs);
            this.Controls.Add(this.cbGreyScale);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Video Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox cbGreyScale;
        private System.Windows.Forms.CheckBox cbRemoveBlobs;
        private System.Windows.Forms.Label lBlob;
        private System.Windows.Forms.CheckBox cb3D;
    }
}

