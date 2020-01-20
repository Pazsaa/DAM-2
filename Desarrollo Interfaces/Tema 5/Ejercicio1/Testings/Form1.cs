using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NuevosComponentes;

namespace Testings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // cambia la posicion
        private void BtnPos_Click(object sender, EventArgs e)
        {
            labelTextbox1.Posicion = labelTextbox1.Posicion == LabelTextbox.ePosicion.DERECHA ? LabelTextbox.ePosicion.IZQUIERDA : LabelTextbox.ePosicion.DERECHA;
        }

        // cambia la separacion de 5 a 10 y viceversa
        private void BtnSep_Click(object sender, EventArgs e)
        {
            labelTextbox1.Separacion = labelTextbox1.Separacion == 5 ? 10 : 5;
        }

        // Actualiza el titulo en base a la posicion
        private void LabelTextbox1_CambiaPosicion(object sender, EventArgs e)
        {
            this.Text = labelTextbox1.Posicion.ToString();
        }

        // cambia el texto del boton en base a la separacion
        private void LabelTextbox1_CambiaSeparacion(object sender, EventArgs e)
        {
            BtnSep.Text = labelTextbox1.Separacion.ToString();
        }

        // cambia el texto de la lbl cuando se SUELTA una tecla
        private void LabelTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
            labelTextbox1.TextLbl = ((char)e.KeyCode).ToString();
        }

        // cambia el fondo de color cuando se modifica el texto del txtbox
        private void LabelTextbox1_TxtChanged(object sender, EventArgs e)
        {
            Random r = new Random();

            this.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
        }
    }
}
