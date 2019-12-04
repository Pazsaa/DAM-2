namespace DI1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnSalir = new System.Windows.Forms.Button();
            this.txtR = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtImg = new System.Windows.Forms.TextBox();
            this.btnImg = new System.Windows.Forms.Button();
            this.lblImg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(538, 170);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(149, 64);
            this.BtnSalir.TabIndex = 0;
            this.BtnSalir.Text = "SALIR";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            this.BtnSalir.MouseEnter += new System.EventHandler(this.BtnSalir_Enter);
            this.BtnSalir.MouseLeave += new System.EventHandler(this.BtnSalir_Leave);
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(27, 54);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(100, 20);
            this.txtR.TabIndex = 1;
            this.txtR.Enter += new System.EventHandler(this.TxtR_Enter);
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(154, 53);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(100, 20);
            this.txtG.TabIndex = 2;
            this.txtG.Enter += new System.EventHandler(this.TxtR_Enter);
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(291, 53);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 20);
            this.txtB.TabIndex = 3;
            this.txtB.Enter += new System.EventHandler(this.TxtR_Enter);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(423, 52);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "COLOR";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.BtnColor_Click);
            this.btnColor.MouseEnter += new System.EventHandler(this.BtnSalir_Enter);
            this.btnColor.MouseLeave += new System.EventHandler(this.BtnSalir_Leave);
            // 
            // txtImg
            // 
            this.txtImg.Location = new System.Drawing.Point(27, 130);
            this.txtImg.Name = "txtImg";
            this.txtImg.Size = new System.Drawing.Size(100, 20);
            this.txtImg.TabIndex = 5;
            this.txtImg.Enter += new System.EventHandler(this.TxtImg_Enter);
            // 
            // btnImg
            // 
            this.btnImg.Location = new System.Drawing.Point(154, 128);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(75, 23);
            this.btnImg.TabIndex = 6;
            this.btnImg.Text = "ASOCIADO";
            this.btnImg.UseVisualStyleBackColor = true;
            this.btnImg.Click += new System.EventHandler(this.BtnImg_Click);
            this.btnImg.MouseEnter += new System.EventHandler(this.BtnSalir_Enter);
            this.btnImg.MouseLeave += new System.EventHandler(this.BtnSalir_Leave);
            // 
            // lblImg
            // 
            this.lblImg.Location = new System.Drawing.Point(24, 196);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(300, 202);
            this.lblImg.TabIndex = 7;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnColor;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 416);
            this.Controls.Add(this.lblImg);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.txtImg);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtR);
            this.Controls.Add(this.BtnSalir);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox txtImg;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.Label lblImg;
    }
}

