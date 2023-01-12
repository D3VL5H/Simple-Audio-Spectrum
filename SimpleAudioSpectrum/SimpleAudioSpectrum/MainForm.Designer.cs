namespace SimpleAudioSpectrum
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AudioSpectrumPbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AudioSpectrumPbox)).BeginInit();
            this.SuspendLayout();
            // 
            // AudioSpectrumPbox
            // 
            this.AudioSpectrumPbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AudioSpectrumPbox.Location = new System.Drawing.Point(0, 0);
            this.AudioSpectrumPbox.Name = "AudioSpectrumPbox";
            this.AudioSpectrumPbox.Size = new System.Drawing.Size(800, 450);
            this.AudioSpectrumPbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioSpectrumPbox.TabIndex = 1;
            this.AudioSpectrumPbox.TabStop = false;
            this.AudioSpectrumPbox.Paint += new System.Windows.Forms.PaintEventHandler(this.AudioSpectrumPbox_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AudioSpectrumPbox);
            this.Name = "MainForm";
            this.Text = "SimpleAudioSpectrum";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.AudioSpectrumPbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox AudioSpectrumPbox;
    }
}