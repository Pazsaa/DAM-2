using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI5
{
    delegate void SetTextDelegate(string text);
    delegate string GetTextDelegate();

    public partial class Form1 : Form
    {
        public DateTime date = DateTime.Now;
        public static string DesignTitle = "Titulo";
        public static char[] letras = DesignTitle.ToCharArray();
        public int TimerCounter = 0;
        public bool iconChanged = false;


        public Form1()
        {
            InitializeComponent();
            this.Text = "";
        }

        // Funcion que hice yo, para no andar repitiendo código al borrar cosas de la listbox
        // La uso en BtnDel y BtnTras1
        public void Delete_Elements(ListBox.SelectedIndexCollection col)
        {
            for (int i = col.Count - 1; i >= 0; i--)
            {
                listBox1.Items.RemoveAt(col[i]);
            }
        }

        // Funcion para animar el texto.
        

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(txt1.Text != "")
            {
                listBox1.Items.Add(txt1.Text);
            }
            ListBox1_SizeChanged(sender, e);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            // Se hace al revés (descendente) para que el indice no cambie. Si vas aumentando y borras el 2 y el 6, por ejemplo, al llegar al 6, ya no es el 6.
            ListBox.SelectedIndexCollection selected = listBox1.SelectedIndices;
            Delete_Elements(selected);
            //for(int i = selected.Count - 1; i >= 0; i--)
            //{
            //    listBox1.Items.RemoveAt(selected[i]);
            //}
            ListBox1_SizeChanged(sender, e);
        }

        private void BtnTras1_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection selected = listBox1.SelectedIndices;
            for (int i = selected.Count - 1; i >= 0; i--)
            {
                listBox2.Items.Insert(0, listBox1.Items[selected[i]]);
            }

            Delete_Elements(selected);
            ListBox1_SizeChanged(sender, e);

            // Tooltip
            toolTip1.SetToolTip(this.listBox2, listBox2.Items.Count.ToString());
        }

        private void BtnTras2_Click(object sender, EventArgs e)
        {
            object selectedItem = listBox2.SelectedItem;
            int selectedIndex = listBox2.SelectedIndex;

            if(selectedItem != null)
            {
                listBox1.Items.Insert(0, selectedItem);
                listBox2.Items.RemoveAt(selectedIndex); 
            }

            ListBox1_SizeChanged(sender, e);

            // Tooltip
            toolTip1.SetToolTip(this.listBox2, listBox2.Items.Count.ToString());
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_SizeChanged(object sender, EventArgs e)
        {
            lbl1.Text = listBox1.Items.Count.ToString();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection selected = listBox1.SelectedIndices;
            lbl2.Text = "" + selected.Count;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(TimerCounter < letras.Length && TimerCounter != -1)
            {
                this.Text += letras[TimerCounter];
                TimerCounter++;
            }

            if (TimerCounter == -1)
            {
                TimerCounter = 0;
                this.Text = "";
            }

            if (this.Text == DesignTitle)
            {
                // Empty round just to wait twice the time
                TimerCounter = -1;
            }

            // ICONO
            if(TimerCounter % 2 == 0)
            {
                if (!iconChanged)
                {
                    this.Icon = new Icon("C:\\Users\\apazgarcia\\Desktop\\Main 2\\Desarrollo Interfaces\\Tema 4\\DI5\\DI5\\bin\\Debug\\santa.ico");
                    iconChanged = !iconChanged;
                }
                else
                {
                    this.Icon = new Icon("C:\\Users\\apazgarcia\\Desktop\\Main 2\\Desarrollo Interfaces\\Tema 4\\DI5\\DI5\\bin\\Debug\\reindeer.ico");
                    iconChanged = !iconChanged;
                }
            }
        }
    }
}
