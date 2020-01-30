using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        string msg; string userMsg;
        public IPEndPoint ie;

        IPForm ipDiag = new IPForm();

        public Form1()
        {
            ipDiag.ShowDialog();
            InitializeComponent();
            ie = new IPEndPoint(IPAddress.Parse(IPForm.IP), IPForm.PORT);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btns_Click(object sender, EventArgs e)
        {
            using (Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    server.Connect(ie);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                using (NetworkStream ns = new NetworkStream(server))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    sw.WriteLine((sender as Button).Text);
                    sw.Flush();

                    if ((sender as Button).Text != "APAGAR")
                    {
                        this.txtOut.Text = sr.ReadLine().ToString();
                    }
                }
            }            
        }

        // Make borderless form draggable (copy paste)
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // EOF borderless draggable
    }
}
