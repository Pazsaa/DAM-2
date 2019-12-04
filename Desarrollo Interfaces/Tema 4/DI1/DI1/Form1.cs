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

namespace DI1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Color oldColor;

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to exit?", "OK", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {

            byte r, g, b;
            bool parsedR = byte.TryParse(txtR.Text, out r);
            bool parsedG = byte.TryParse(txtG.Text, out g);
            bool parsedB = byte.TryParse(txtB.Text, out b);

            if(parsedR && parsedG && parsedB)
            {
                this.BackColor = Color.FromArgb(r, g, b);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                BtnSalir_Click(sender, e);
            }
        }

        private void BtnImg_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtImg.Text.Trim();
                lblImg.Image = new Bitmap(path);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Ruta incorrecta");
            }
           
        }

        private void TxtImg_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnImg;
        }

        private void TxtR_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnColor;
        }

        private void BtnSalir_Enter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            oldColor = btn.BackColor;

            Random r = new Random();
            Color color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));

            btn.BackColor = color;
        }

        private void BtnSalir_Leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = oldColor;
        }
    }
}
