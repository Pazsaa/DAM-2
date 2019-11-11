namespace Serv2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pinfoTxt = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.viewBtn = new System.Windows.Forms.Button();
            this.pinfoBtn = new System.Windows.Forms.Button();
            this.closepBtn = new System.Windows.Forms.Button();
            this.killpBtn = new System.Windows.Forms.Button();
            this.runpBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pinfoTxt
            // 
            this.pinfoTxt.Location = new System.Drawing.Point(12, 12);
            this.pinfoTxt.Multiline = true;
            this.pinfoTxt.Name = "pinfoTxt";
            this.pinfoTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pinfoTxt.Size = new System.Drawing.Size(376, 355);
            this.pinfoTxt.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(427, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(348, 20);
            this.textBox2.TabIndex = 1;
            // 
            // viewBtn
            // 
            this.viewBtn.Location = new System.Drawing.Point(31, 386);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(98, 23);
            this.viewBtn.TabIndex = 2;
            this.viewBtn.Text = "View Processes";
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.ViewBtn_Click);
            // 
            // pinfoBtn
            // 
            this.pinfoBtn.Location = new System.Drawing.Point(427, 54);
            this.pinfoBtn.Name = "pinfoBtn";
            this.pinfoBtn.Size = new System.Drawing.Size(75, 23);
            this.pinfoBtn.TabIndex = 3;
            this.pinfoBtn.Text = "Process Info";
            this.pinfoBtn.UseVisualStyleBackColor = true;
            this.pinfoBtn.Click += new System.EventHandler(this.PinfoBtn_Click);
            // 
            // closepBtn
            // 
            this.closepBtn.Location = new System.Drawing.Point(508, 54);
            this.closepBtn.Name = "closepBtn";
            this.closepBtn.Size = new System.Drawing.Size(85, 23);
            this.closepBtn.TabIndex = 4;
            this.closepBtn.Text = "Close Process";
            this.closepBtn.UseVisualStyleBackColor = true;
            this.closepBtn.Click += new System.EventHandler(this.ClosepBtn_Click);
            // 
            // killpBtn
            // 
            this.killpBtn.Location = new System.Drawing.Point(599, 54);
            this.killpBtn.Name = "killpBtn";
            this.killpBtn.Size = new System.Drawing.Size(85, 23);
            this.killpBtn.TabIndex = 5;
            this.killpBtn.Text = "Kill Process";
            this.killpBtn.UseVisualStyleBackColor = true;
            this.killpBtn.Click += new System.EventHandler(this.KillpBtn_Click);
            // 
            // runpBtn
            // 
            this.runpBtn.Location = new System.Drawing.Point(690, 54);
            this.runpBtn.Name = "runpBtn";
            this.runpBtn.Size = new System.Drawing.Size(85, 23);
            this.runpBtn.TabIndex = 6;
            this.runpBtn.Text = "Run App";
            this.runpBtn.UseVisualStyleBackColor = true;
            this.runpBtn.Click += new System.EventHandler(this.RunpBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.runpBtn);
            this.Controls.Add(this.killpBtn);
            this.Controls.Add(this.closepBtn);
            this.Controls.Add(this.pinfoBtn);
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pinfoTxt);
            this.Name = "Form1";
            this.Text = "TASK MANAGER IMPOSTOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pinfoTxt;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button viewBtn;
        private System.Windows.Forms.Button pinfoBtn;
        private System.Windows.Forms.Button closepBtn;
        private System.Windows.Forms.Button killpBtn;
        private System.Windows.Forms.Button runpBtn;
    }
}

