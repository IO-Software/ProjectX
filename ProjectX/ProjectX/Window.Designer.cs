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
            this.SuspendLayout();
            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(664, 262);
            this.Name = "Window";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pBoxUp;
        public System.Windows.Forms.PictureBox pBoxDown;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.ComboBox cBoxCam;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;

    }
}