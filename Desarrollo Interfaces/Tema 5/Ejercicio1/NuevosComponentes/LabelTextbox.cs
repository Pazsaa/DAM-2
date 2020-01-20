using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevosComponentes
{
    [DefaultProperty("TextLbl")]
    [DefaultEvent("Load")]
    public partial class LabelTextbox : UserControl
    {
        public LabelTextbox()
        {
            InitializeComponent();
            TextLbl = "Hola";
            TextTxt = "";
            recolocar();
        }

        public enum ePosicion
        {
            IZQUIERDA, DERECHA
        }

        private ePosicion posicion = ePosicion.IZQUIERDA;

        [Category("Appearance")]
        [Description("Indica si la Label se coloca a la izquierda o a la derecha del Textbox")]
        public ePosicion Posicion
        {
            set
            {
                if(Enum.IsDefined(typeof(ePosicion), value))
                {
                    posicion = value;
                    recolocar();

                    CambiaPosicion?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }

            get
            {
                return posicion;
            }
        }


        private int separacion = 0;

        [Category("Design")]
        [Description("Píxels de separación entre Label y Textbox")]
        public int Separacion
        {
            set
            {
                if(value >= 0)
                {
                    separacion = value;
                    recolocar();

                    CambiaSeparacion?.Invoke(this, EventArgs.Empty);
                }
                else{
                    throw new ArgumentOutOfRangeException();
                }
            }

            get
            {
                return separacion;
            }
        }

        [Category("Appearance")]
        [Description("Texto asociado a la Label del control")]
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
                recolocar();
            }

            get
            {
                return lbl.Text;
            }
        }

        [Category("Appearance")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
        {
            set
            {
                txt.Text = value;
            }

            get
            {
                return txt.Text;
            }
        }

        [Category("Appearance")]
        [Description("Cambia el texto del textbox a modo contraseña")]
        public char PswChr
        {
            set
            {
                txt.PasswordChar = value;
            }

            get
            {
                return txt.PasswordChar;
            }
        }

        private void recolocar()
        {
            switch (posicion)
            {
                case ePosicion.DERECHA:
                    txt.Location = new Point(0, 0);
                    txt.Width = this.Width - lbl.Width - Separacion;

                    lbl.Location = new Point(txt.Width + separacion, 0);

                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
                case ePosicion.IZQUIERDA:
                    lbl.Location = new Point(0, 0);

                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    txt.Width = this.Width - lbl.Width - Separacion;

                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
            }
        }

        private void LabelTextBox_SizeChanged(object sender, EventArgs e)
        {
            recolocar();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void Txt_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la porpiedad Posicion cambia")]
        public event System.EventHandler CambiaPosicion;

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Separacion cambia")]
        public event System.EventHandler CambiaSeparacion;

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad TextTxt cambia")]
        public event System.EventHandler TxtChanged;

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            TxtChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
