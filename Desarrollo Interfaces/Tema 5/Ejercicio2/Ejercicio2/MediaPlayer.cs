using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    [DefaultProperty("Player")]
    [DefaultEvent("Click")]
    public partial class MediaPlayer : UserControl
    {
        public MediaPlayer()
        {
            InitializeComponent();
        }


        public enum eState
        {
            PLAYING, PAUSED
        }

        private eState state = eState.PAUSED;

        [Category("Design")]
        [Description("Refleja el estado del reproductor")]
        public eState State
        {
            set
            {
                if(Enum.IsDefined(typeof(eState), value))
                {
                    state = value;
                    //StatusChanged.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }

            get
            {
                return state;
            }
        }

        public enum eAction
        {
            PLAY, PAUSE
        }

        private eAction action = eAction.PLAY;

        [Category("Appearance")]
        [Description("Cambia el estado del botón")]
        public eAction Action
        {
            set
            {
                if(Enum.IsDefined(typeof(eAction), value))
                {
                    action = value;
                    BtnPlay.Text = action.ToString();
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }

            get
            {
                return action;
            }
        }

        private int timeX = 0;
        private int timeY = 0;

        [Category("Design")]
        [Description("Tiempo en minutos.")]
        public int TimeX
        {
            set
            {
                if(value > 99)
                {
                    timeX = 0;
                }
                else
                {
                    timeX = value;
                }
            }
            get
            {
                return timeX;
            }
        }

        [Category("Design")]
        [Description("TIempo en segundos")]
        public int TimeY
        {
            set
            {
                if(value > 59)
                {
                    timeY = 0;
                    DesbordaTiempo.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    timeY = value;
                }
            }

            get
            {
                return timeY;
            }
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            this.state = this.state == eState.PLAYING ? eState.PAUSED : eState.PLAYING;
            BtnPlay.Text = this.state == eState.PLAYING ? eAction.PAUSE.ToString() : eAction.PLAY.ToString();
            this.OnClick(e);
        }

        private void MediaPlayer_Load(object sender, EventArgs e)
        {
            
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            if (this.State == eState.PLAYING)
            {
                TimeY++;
                this.LblTime.Text = String.Format("{0}:{1}", TimeX >= 10 ? TimeX.ToString(): "0" + TimeX, 
                                                             TimeY >= 10 ? TimeY.ToString(): "0" + TimeY);
            }
        }

        [Category("Property changed")]
        [Description("Evento que se lanza cada vez que los segundos pasan de 59")]
        public event System.EventHandler DesbordaTiempo;

        [Category("Property changed")]
        [Description("Evento que se lanza cada vez que cambia el estado PAUSED/PLAYING")]
        public event System.EventHandler StatusChanged;
    }
}
