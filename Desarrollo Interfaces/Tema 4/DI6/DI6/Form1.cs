using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI6
{
    public partial class Form1 : Form
    {
        Button[] btns = new Button[13];
        public Color btnDefaultColor = Color.Transparent;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormPin f = new FormPin();
            DialogResult result = f.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                this.Close();
                this.MinimumSize = new Size(284, 178);
                this.MaximumSize = new Size(284, 178);
            }

            int x = 23; int y = 57;
            int cont = 1;
            for(int i = 0; i < btns.Length -1 ; i++)
            {
                btns[i] = new Button();
                btns[i].Location = new System.Drawing.Point(x, y);
                btns[i].Name = "btn" + i + 1;
                btns[i].Text = (i + 1).ToString();
                btns[i].Size = Size = new System.Drawing.Size(75, 23);
                btns[i].BackColor = btnDefaultColor;
                btns[i].Click += Buttons_Click;
                btns[i].MouseEnter += Buttons_Enter;
                btns[i].MouseLeave += Buttons_Leave;
                this.Controls.Add(btns[i]);
                x += 81;

                switch (btns[i].Text)
                {
                    case "10":
                        btns[i].Text = "#";
                        break;
                    case "11":
                        btns[i].Text = "0";
                        break;
                    case "12":
                        btns[i].Text = "*";
                        break;
                    default:
                        break;
                }

                if(cont % 3 == 0)
                {
                    y += 29;
                    x = 23;
                }
                cont++;
            }

            this.ClientSize = new System.Drawing.Size(300, 217);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
            (sender as Button).BackColor = Color.FromArgb(100, 150, 100);
        }

        private void  Buttons_Enter(object sender, EventArgs e)
        {
            if((sender as Button).BackColor == Color.Transparent)
                (sender as Button).BackColor = Color.FromArgb(255, 0, 255);
        }

        private void Buttons_Leave(object sender, EventArgs e)
        {
            if ((sender as Button).BackColor == Color.FromArgb(255, 0, 255)) 
                (sender as Button).BackColor = btnDefaultColor;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            for(int i = 0; i < btns.Length - 1; i++)
            {
                btns[i].BackColor = btnDefaultColor;
            }

            //foreach(Button btn in btns)
            //{
            //    btn.BackColor = btnDefaultColor;
            //}
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnReset_Click(sender, e);
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
