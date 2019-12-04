using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI6
{
    public class FormPin : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.TextBox txtPin;

        public static string Pin = "6663";
        public static int PinTries = 3;

        public FormPin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtPin = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(12, 12);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(208, 20);
            this.txtPin.TabIndex = 0;
            this.txtPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(226, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(46, 20);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(23, 57);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.Btn1_Click);
            this.btn1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(104, 57);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 23);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.Btn1_Click);
            this.btn2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(185, 57);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 23);
            this.btn3.TabIndex = 4;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.Btn1_Click);
            this.btn3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(185, 86);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 23);
            this.btn6.TabIndex = 7;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.Btn1_Click);
            this.btn6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(104, 86);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 23);
            this.btn5.TabIndex = 6;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.Btn1_Click);
            this.btn5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(23, 86);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 23);
            this.btn4.TabIndex = 5;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.Btn1_Click);
            this.btn4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(185, 115);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 23);
            this.btn9.TabIndex = 10;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.Btn1_Click);
            this.btn9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn9.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(104, 115);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 23);
            this.btn8.TabIndex = 9;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.Btn1_Click);
            this.btn8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn8.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(23, 115);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 23);
            this.btn7.TabIndex = 8;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.Btn1_Click);
            this.btn7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn7.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(104, 144);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(75, 23);
            this.btn0.TabIndex = 11;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.Btn1_Click);
            this.btn0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.btn0.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Btn1_PreviewKeyDown);
            // 
            // FormPin
            // 
            this.ClientSize = new System.Drawing.Size(284, 178);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPin);
            this.KeyPreview = true;
            this.Name = "FormPin";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPin_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (txtPin.Text.Length < 4)
            {
                txtPin.Text += (sender as Button).Text;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (txtPin.Text == Pin)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                PinTries--;
                txtPin.Text = "";
                if (PinTries == 0)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                MessageBox.Show("Pin incorrecto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                BtnOk_Click(sender, e);
            }
        }

        private void Btn1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnOk_Click(sender, e);
            }
        }
    }
}
