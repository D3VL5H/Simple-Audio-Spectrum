namespace SimpleAudioSpectrum
{
    public partial class MainForm : Form
    {
        System.Windows.Forms.Timer drawTmr;
        AudioVisualizer vis;
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;            
            vis = new AudioVisualizer();
            vis.SetFormSize(this.Width, this.Height);
            SetTimer();        
        }

        private void SetTimer()
        {
            drawTmr = new System.Windows.Forms.Timer();
            drawTmr.Interval = 1000 / 60;
            drawTmr.Tick += DrawTmr_Tick;
            drawTmr.Start();
            Console.WriteLine("Interval : " + drawTmr.Interval);
        }

        private void DrawTmr_Tick(object? sender, EventArgs e)
        {
            AudioSpectrumPbox.Refresh();
        }

        private void AudioSpectrumPbox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                vis.Draw(e.Graphics);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            vis.SetFormSize(this.Width, this.Height);
        }
    }
}