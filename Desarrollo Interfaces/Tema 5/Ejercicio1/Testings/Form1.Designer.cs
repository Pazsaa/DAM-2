namespace Testings
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
            this.BtnPos = new System.Windows.Forms.Button();
            this.BtnSep = new System.Windows.Forms.Button();
            this.labelTextbox1 = new NuevosComponentes.LabelTextbox();
            this.SuspendLayout();
            // 
            // BtnPos
            // 
            this.BtnPos.Location = new System.Drawing.Point(12, 51);
            this.BtnPos.Name = "BtnPos";
            this.BtnPos.Size = new System.Drawing.Size(75, 23);
            this.BtnPos.TabIndex = 1;
            this.BtnPos.Text = "POSICION";
            this.BtnPos.UseVisualStyleBackColor = true;
            this.BtnPos.Click += new System.EventHandler(this.BtnPos_Click);
            // 
            // BtnSep
            // 
            this.BtnSep.Location = new System.Drawing.Point(93, 51);
            this.BtnSep.Name = "BtnSep";
            this.BtnSep.Size = new System.Drawing.Size(87, 23);
            this.BtnSep.TabIndex = 2;
            this.BtnSep.Text = "SEPARACION";
            this.BtnSep.UseVisualStyleBackColor = true;
            this.BtnSep.Click += new System.EventHandler(this.BtnSep_Click);
            // 
            // labelTextbox1
            // 
            this.labelTextbox1.Location = new System.Drawing.Point(12, 12);
            this.labelTextbox1.Name = "labelTextbox1";
            this.labelTextbox1.Posicion = NuevosComponentes.LabelTextbox.ePosicion.IZQUIERDA;
            this.labelTextbox1.PswChr = '/';
            this.labelTextbox1.Separacion = 10;
            this.labelTextbox1.Size = new System.Drawing.Size(234, 20);
            this.labelTextbox1.TabIndex = 0;
            this.labelTextbox1.TextLbl = "Test";
            this.labelTextbox1.TextTxt = "Test";
            this.labelTextbox1.CambiaPosicion += new System.EventHandler(this.LabelTextbox1_CambiaPosicion);
            this.labelTextbox1.CambiaSeparacion += new System.EventHandler(this.LabelTextbox1_CambiaSeparacion);
            this.labelTextbox1.TxtChanged += new System.EventHandler(this.LabelTextbox1_TxtChanged);
            this.labelTextbox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LabelTextbox1_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 97);
            this.Controls.Add(this.BtnSep);
            this.Controls.Add(this.BtnPos);
            this.Controls.Add(this.labelTextbox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private NuevosComponentes.LabelTextbox labelTextbox1;
        private System.Windows.Forms.Button BtnPos;
        private System.Windows.Forms.Button BtnSep;
    }
}

