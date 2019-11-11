using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

  

        private void Form1_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double resultado = double.Parse(sum1.Text) + double.Parse(sum2.Text);
                res.Text = resultado.ToString();
                error.Visible = false;
            }
            catch(FormatException ex)
            {
                error.Visible = true;
                error.Text = "¡Solo sabemos sumar numeros!";
            }
        }
    }
}
