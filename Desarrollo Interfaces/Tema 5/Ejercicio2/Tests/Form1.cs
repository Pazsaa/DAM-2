using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form1 : Form
    {
        private string path = "";
        private int index = 0;
        string[] images;

        public bool isPaused = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void MediaPlayer1_DesbordaTiempo(object sender, EventArgs e)
        {
            mediaPlayer1.TimeX += 1;
        }

        private void MediaPlayer1_Click(object sender, EventArgs e)
        {
            if (path != null && path != "")
            {
                images = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);

                isPaused = !isPaused;
            }
        }

        private void MediaPlayer1_StatusChanged(object sender, EventArgs e)
        {
            // todo (no necesario para el ejercicio)
        }

        private void BtnDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            DialogResult res = d.ShowDialog();

            if (res != DialogResult.OK) return;

            textBox1.Text = d.SelectedPath;
            this.path = d.SelectedPath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            timer1.Start();
        }

        private void MediaPlayer1_Load(object sender, EventArgs e)
        {
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(images == null || images.Length == 0)
            {
                return;
            }

            if (!isPaused)
            {
                if (this.index >= images.Length)
                {
                    this.index = 0;
                }

                pictureBox1.Load(images[index]);
                index++;
            }
        }
    }
}
