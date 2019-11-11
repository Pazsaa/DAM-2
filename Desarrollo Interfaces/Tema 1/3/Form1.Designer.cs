namespace Ejercicio3
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
            this.slot1 = new System.Windows.Forms.TextBox();
            this.slot3 = new System.Windows.Forms.TextBox();
            this.slot2 = new System.Windows.Forms.TextBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.dineroLbl = new System.Windows.Forms.Label();
            this.winLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // slot1
            // 
            this.slot1.Location = new System.Drawing.Point(34, 25);
            this.slot1.Name = "slot1";
            this.slot1.Size = new System.Drawing.Size(25, 20);
            this.slot1.TabIndex = 0;
            // 
            // slot3
            // 
            this.slot3.Location = new System.Drawing.Point(96, 25);
            this.slot3.Name = "slot3";
            this.slot3.Size = new System.Drawing.Size(25, 20);
            this.slot3.TabIndex = 1;
            // 
            // slot2
            // 
            this.slot2.Location = new System.Drawing.Point(65, 25);
            this.slot2.Name = "slot2";
            this.slot2.Size = new System.Drawing.Size(25, 20);
            this.slot2.TabIndex = 2;
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(47, 51);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(58, 23);
            this.playBtn.TabIndex = 3;
            this.playBtn.Text = "GO";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(78, 104);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "ADD";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // dineroLbl
            // 
            this.dineroLbl.AutoSize = true;
            this.dineroLbl.Location = new System.Drawing.Point(44, 109);
            this.dineroLbl.Name = "dineroLbl";
            this.dineroLbl.Size = new System.Drawing.Size(25, 13);
            this.dineroLbl.TabIndex = 5;
            this.dineroLbl.Text = "50€";
            // 
            // winLbl
            // 
            this.winLbl.AutoSize = true;
            this.winLbl.Location = new System.Drawing.Point(44, 77);
            this.winLbl.Name = "winLbl";
            this.winLbl.Size = new System.Drawing.Size(35, 13);
            this.winLbl.TabIndex = 6;
            this.winLbl.Text = "label1";
            this.winLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 129);
            this.Controls.Add(this.winLbl);
            this.Controls.Add(this.dineroLbl);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.slot2);
            this.Controls.Add(this.slot3);
            this.Controls.Add(this.slot1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox slot1;
        private System.Windows.Forms.TextBox slot3;
        private System.Windows.Forms.TextBox slot2;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label dineroLbl;
        private System.Windows.Forms.Label winLbl;
    }
}

