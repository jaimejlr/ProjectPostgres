namespace SMC.PresentationLayer.Formularios_modificacion
{
    partial class OrderOptionsAgregar
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAdicional = new System.Windows.Forms.TextBox();
            this.txtPrime = new System.Windows.Forms.TextBox();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitulo.Size = new System.Drawing.Size(695, 54);
            this.lblTitulo.Text = " Opcion De Compra";
            // 
            // txtAdicional
            // 
            this.txtAdicional.Location = new System.Drawing.Point(395, 186);
            this.txtAdicional.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAdicional.Name = "txtAdicional";
            this.txtAdicional.Size = new System.Drawing.Size(207, 22);
            this.txtAdicional.TabIndex = 28;
            // 
            // txtPrime
            // 
            this.txtPrime.Location = new System.Drawing.Point(395, 143);
            this.txtPrime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrime.Name = "txtPrime";
            this.txtPrime.Size = new System.Drawing.Size(207, 22);
            this.txtPrime.TabIndex = 27;
            // 
            // txtTasa
            // 
            this.txtTasa.Location = new System.Drawing.Point(395, 98);
            this.txtTasa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(207, 22);
            this.txtTasa.TabIndex = 26;
            this.txtTasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTasa_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Adicional Reserve Buque de carga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Primer Libro de buques de carga";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tasa de Impuesto a las Ventas";
            // 
            // OrderOptionsAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(695, 353);
            this.Controls.Add(this.txtAdicional);
            this.Controls.Add(this.txtPrime);
            this.Controls.Add(this.txtTasa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "OrderOptionsAgregar";
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtTasa, 0);
            this.Controls.SetChildIndex(this.txtPrime, 0);
            this.Controls.SetChildIndex(this.txtAdicional, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdicional;
        private System.Windows.Forms.TextBox txtPrime;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
