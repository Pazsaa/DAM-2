using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class Form1 : Form
    {
        public int dinero = 50;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            winLbl.Visible = false;
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            winLbl.Visible = false;

            Random r = new Random();
            slot1.Text = (r.Next(7) + 1).ToString();
            slot2.Text = (r.Next(7) + 1).ToString();
            slot3.Text = (r.Next(7) + 1).ToString();

            checkSlots();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            updateEarnings(10);
        }

        public void checkSlots()
        {
            if (slot1.Text == slot2.Text && slot1.Text == slot3.Text)
            {
                // WIN WIN
                winLbl.ForeColor = Color.Green;
                winLbl.Text = "¡Gana 20€!";
                winLbl.Visible = true;
                updateEarnings(20);
            }
            else if (slot1.Text == slot2.Text || slot2.Text == slot3.Text || slot3.Text == slot1.Text)
            {
                // half win
                winLbl.ForeColor = Color.Green;
                winLbl.Text = "¡Gana 5€!";
                winLbl.Visible = true;
                updateEarnings(5);
                
            }
            else
            {
                // Loss
                winLbl.ForeColor = Color.Red;
                winLbl.Text = "¡Pierde 2€!";
                winLbl.Visible = true;
                updateEarnings(-2);
            }
        }

        public void updateEarnings(int money)
        {
            dinero += money;
            dineroLbl.Text = dinero + "€";
        }
    }
}
