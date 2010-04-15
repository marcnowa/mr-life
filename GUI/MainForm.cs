using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Life.Logic;

namespace Life
{
    public partial class MainForm : Form
    {
        private Population population;
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            int size = 500;
            population = new Population(size);
            RefreshImage();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextState();
        }

        private void NextState()
        {
            population.NextState();
            RefreshImage();
        }

        private void RefreshImage()
        {
            pictureBox1.Image = population.GetCurrentImage(trackBar2.Value+1, new Point(0,0));
            pictureBox1.Refresh();
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = !startStopButton.Checked;
            if (startStopButton.Checked)
            {
                timer1.Start();
                startStopButton.Text = "stop";
            }
            else
            {
                timer1.Stop();
                startStopButton.Text = "start";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = (trackBar1.Maximum + 1 - trackBar1.Value) * 100;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NextState();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            RefreshImage();
        }
    }
}
