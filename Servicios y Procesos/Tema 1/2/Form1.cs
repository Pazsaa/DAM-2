using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Serv2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();

            pinfoTxt.Clear();
            pinfoTxt.AppendText(string.Format("{0,-15}\t\t{1,-5}\t\t{2,-10}", "NAME", "PID", "TITLE"));
            pinfoTxt.AppendText(Environment.NewLine + Environment.NewLine);
            foreach (Process p in processes)
            {
                string name = p.ProcessName.Length > 10 ? p.ProcessName.Substring(0, 7) + "..." : p.ProcessName;
                string title = p.MainWindowTitle.Length > 10 ? p.MainWindowTitle.Substring(0, 7) + "..." : p.MainWindowTitle;
                pinfoTxt.AppendText(string.Format("{0,-15}\t\t{1,-5}\t\t{2,-10}", name, p.Id, title));
                pinfoTxt.AppendText(Environment.NewLine);
            }
        }

        private void PinfoBtn_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;
            int pid = -1;
            bool parsed = Int32.TryParse(str, out pid);

            pinfoTxt.Clear();
            if(!parsed)
            {
                pinfoTxt.AppendText("Error, invalid PID");
            }
            else
            {
                try
                {
                    Process target = Process.GetProcessById(pid);
                    pinfoTxt.AppendText("Name: " + target.ProcessName + Environment.NewLine);
                    pinfoTxt.AppendText("PID: " + target.Id + Environment.NewLine);
                    pinfoTxt.AppendText("Window Title: " + target.MainWindowTitle + Environment.NewLine);

                    pinfoTxt.AppendText("Threads: " + Environment.NewLine);
                    ProcessThreadCollection threads = target.Threads;
                    foreach(ProcessThread thread in threads)
                    {
                        pinfoTxt.AppendText("\t" + thread.Id + "\t\t" + thread.StartTime + Environment.NewLine);
                    }
                    pinfoTxt.AppendText(Environment.NewLine);

                    pinfoTxt.AppendText("Modules: " + Environment.NewLine);
                    ProcessModuleCollection modules = target.Modules;
                    foreach(ProcessModule module in modules)
                    {
                        pinfoTxt.AppendText("\t" + module.ModuleName + "\t\t" + module.FileName + Environment.NewLine);
                    }
                }
                catch(ArgumentException ex)
                {
                    pinfoTxt.AppendText("Error, non existent PID");
                } 
            }
        }

        private void ClosepBtn_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;
            int pid = -1;
            bool parsed = Int32.TryParse(str, out pid);

            pinfoTxt.Clear();
            if (!parsed)
            {
                pinfoTxt.AppendText("Error, invalid PID");
            }
            else
            {
                try
                {
                    Process target = Process.GetProcessById(pid);
                    target.CloseMainWindow();
                }
                catch (ArgumentException ex)
                {
                    pinfoTxt.AppendText("Error, non existent PID");
                }
            }
        }

        private void KillpBtn_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;
            int pid = -1;
            bool parsed = Int32.TryParse(str, out pid);

            pinfoTxt.Clear();
            if (!parsed)
            {
                pinfoTxt.AppendText("Error, invalid PID");
            }
            else
            {
                try
                {
                    Process target = Process.GetProcessById(pid);
                    target.Kill();
                }
                catch (ArgumentException ex)
                {
                    pinfoTxt.AppendText("Error, non existent PID");
                }
            }
        }

        private void RunpBtn_Click(object sender, EventArgs e)
        {
            string appName = textBox2.Text;

            try
            {
                Process.Start(appName);
            }
            catch (Exception ex)
            {
                pinfoTxt.AppendText("Erorr, app not found");
            }
        }
    }
}
