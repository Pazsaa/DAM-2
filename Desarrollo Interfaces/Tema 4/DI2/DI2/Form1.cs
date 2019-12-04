#define TEST
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DI2
{
    public partial class Form1 : Form
    {
        public string Titulo = "Mouse Tester";
        public bool isTituloKey = false;
        public Color oldColor; public Color oldColor2;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!isTituloKey)
                this.Text = Titulo + " X: " + Cursor.Position.X + " Y: " + Cursor.Position.Y;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = Titulo;
        }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           
            Random r = new Random();
            switch (e.Button)
            {
                case MouseButtons.Left:
                    oldColor = button1.BackColor;
                    button1.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                    break;
                case MouseButtons.Right:
                    oldColor = button2.BackColor;
                    button2.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                    break;
                default:
                    oldColor = button1.BackColor;
                    oldColor2 = button2.BackColor;
                    button1.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                    button2.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                    break;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    button1.BackColor = oldColor;
                    break;
                case MouseButtons.Right:
                    button2.BackColor = oldColor;
                    break;
                default:
                    button1.BackColor = oldColor;
                    button2.BackColor = oldColor2;
                    break;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
#if TEST
            if (e.KeyChar == (char)Keys.Escape)
            {
                isTituloKey = false;
                this.Text = Titulo;
            }
            else
            {
                this.Text = e.KeyChar.ToString();
                isTituloKey = true;
            }
#else
            if (e.KeyChar == (char)Keys.Escape)
            {
                isTituloKey = false;
                this.Text = Titulo;
            }
            else
            {
                this.Text = ((int)e.KeyChar).ToString();
                isTituloKey = true;
            }
#endif
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que quieres salir?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
