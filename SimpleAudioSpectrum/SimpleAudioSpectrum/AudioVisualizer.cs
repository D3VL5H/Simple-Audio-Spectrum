using MathNet.Numerics.IntegralTransforms;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioSpectrum
{
    public class AudioVisualizer
    {
        private WaveBuffer? buffer = null;
        private float size = 0;

        private List<Complex[]> loopbackDataList = new List<Complex[]>();
        private Complex[] curLoopbackDatas;

        private float count = 64;
        private Pen pen = new Pen(Color.Green, 10);

        private int formWidth = 0;
        private int formHeight = 0;

        public AudioVisualizer()
        {
            var loopbackCapture = new WasapiLoopbackCapture();
            loopbackCapture.DataAvailable += LoopbackCapture_DataAvailable;
            loopbackCapture.RecordingStopped += (s, a) =>
            {
                loopbackCapture.Dispose();
            };

            loopbackCapture.StartRecording();
        }

        public void SetFormSize(int w, int h)
        {
            formWidth = w;
            formHeight = h - 40;
        }

        private void LoopbackCapture_DataAvailable(object? sender, WaveInEventArgs e)
        {
            buffer = new WaveBuffer(e.Buffer);
            int len = buffer.FloatBuffer.Length / 8;
            curLoopbackDatas = new Complex[len];
            for (int i = 0; i < len; i++)
            {
                curLoopbackDatas[i] = new Complex(buffer.FloatBuffer[i], 0.0);
            }
            Fourier.Forward(curLoopbackDatas);

            loopbackDataList.Add(curLoopbackDatas);
            if (loopbackDataList.Count > 1)
            {
                loopbackDataList.RemoveAt(0);
            }
        }

        public double MakeSmooth(int i)
        {
            double value = 0;
            for (int h = Math.Max(i - 1, 0); h < Math.Min(i + 1, count); h++)
            {
                for (int v = 0; v < loopbackDataList.Count; v++)
                {
                    value += Math.Abs(loopbackDataList[v] != null ? loopbackDataList[v][h].Magnitude : 0.0);
                }
                value /= loopbackDataList.Count;
            }
            return value / 2;
        }

        public void Draw(Graphics grp)
        {
            if (buffer == null)
            {
                return;
            }

            size = formWidth / count;
            for (int i = 0; i < count; i++)
            {
                var value = (MakeSmooth(i) * formHeight / 2 + MakeSmooth(i - 1) + MakeSmooth(i + 1)) / 3;
                float x = i * size;
                grp.DrawLine(pen, x, formHeight - (float)value, x, formHeight);
            }
        }
    }
}
