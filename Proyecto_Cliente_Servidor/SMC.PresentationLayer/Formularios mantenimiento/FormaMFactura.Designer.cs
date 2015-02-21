namespace SMC.PresentationLayer.Formularios_mantenimiento
{
    partial class FormaMFactura
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.txtTotalProductos = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.txtEnvio = new System.Windows.Forms.TextBox();
            this.txtFacturaTotal = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(301, 69);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(5);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(229, 335);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(5);
            this.btnModificar.Size = new System.Drawing.Size(115, 48);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(369, 335);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Size = new System.Drawing.Size(115, 48);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(89, 335);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(5);
            this.btnAgregar.Size = new System.Drawing.Size(115, 48);
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitulo.Size = new System.Drawing.Size(798, 57);
            this.lblTitulo.Text = "Factura";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(655, 337);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(5);
            this.btnSalir.Size = new System.Drawing.Size(115, 48);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 230);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "&Impuesto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 263);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "&Envio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "&Total Productos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "&Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "&Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "&Numero Factura:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 297);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "Factu&ra Total:";
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(201, 226);
            this.txtImpuesto.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(400, 22);
            this.txtImpuesto.TabIndex = 35;
            this.txtImpuesto.TabStop = false;
            // 
            // txtTotalProductos
            // 
            this.txtTotalProductos.Location = new System.Drawing.Point(204, 194);
            this.txtTotalProductos.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalProductos.Name = "txtTotalProductos";
            this.txtTotalProductos.ReadOnly = true;
            this.txtTotalProductos.Size = new System.Drawing.Size(399, 22);
            this.txtTotalProductos.TabIndex = 33;
            this.txtTotalProductos.TabStop = false;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(204, 130);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(399, 22);
            this.txtCliente.TabIndex = 31;
            this.txtCliente.TabStop = false;
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(204, 84);
            this.txtNumeroFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(65, 22);
            this.txtNumeroFactura.TabIndex = 30;
            this.txtNumeroFactura.Tag = "Customer ID";
            this.txtNumeroFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFactura_KeyPress);
            // 
            // txtEnvio
            // 
            this.txtEnvio.Location = new System.Drawing.Point(201, 258);
            this.txtEnvio.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnvio.Name = "txtEnvio";
            this.txtEnvio.ReadOnly = true;
            this.txtEnvio.Size = new System.Drawing.Size(399, 22);
            this.txtEnvio.TabIndex = 36;
            this.txtEnvio.TabStop = false;
            // 
            // txtFacturaTotal
            // 
            this.txtFacturaTotal.Location = new System.Drawing.Point(201, 293);
            this.txtFacturaTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtFacturaTotal.Name = "txtFacturaTotal";
            this.txtFacturaTotal.ReadOnly = true;
            this.txtFacturaTotal.Size = new System.Drawing.Size(399, 22);
            this.txtFacturaTotal.TabIndex = 37;
            this.txtFacturaTotal.TabStop = false;
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(204, 165);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(397, 22);
            this.txtFecha.TabIndex = 38;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancelar.Image = global::SMC.PresentationLayer.Properties.Resources.Cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(505, 337);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(122, 46);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormaMFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(798, 393);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtFacturaTotal);
            this.Controls.Add(this.txtEnvio);
            this.Controls.Add(this.txtImpuesto);
            this.Controls.Add(this.txtTotalProductos);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtNumeroFactura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "FormaMFactura";
            this.Load += new System.EventHandler(this.FormaMFacturaDetalle_Load);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtNumeroFactura, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.txtTotalProductos, 0);
            this.Controls.SetChildIndex(this.txtImpuesto, 0);
            this.Controls.SetChildIndex(this.txtEnvio, 0);
            this.Controls.SetChildIndex(this.txtFacturaTotal, 0);
            this.Controls.SetChildIndex(this.txtFecha, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtImpuesto;
        public System.Windows.Forms.TextBox txtTotalProductos;
        public System.Windows.Forms.TextBox txtCliente;
        public System.Windows.Forms.TextBox txtNumeroFactura;
        public System.Windows.Forms.TextBox txtEnvio;
        public System.Windows.Forms.TextBox txtFacturaTotal;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.Button btnCancelar;
    }
}
