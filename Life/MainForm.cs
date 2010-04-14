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
            int size = 200;
            population = new Population(size);
            pictureBox1.Image = population.GetCurrentImage();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            population.NextState();
            pictureBox1.Image = population.GetCurrentImage();
            pictureBox1.Refresh();
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
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
    }
}
