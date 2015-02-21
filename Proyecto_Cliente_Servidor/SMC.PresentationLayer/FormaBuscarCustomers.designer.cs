
namespace SMC.PresentationLayer
{
    partial class FormaBuscarCustomers
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAceptarNombre = new System.Windows.Forms.Button();
            this.btnQuitarFiltro = new System.Windows.Forms.Button();
            this.btnAceptarIdCliente = new System.Windows.Forms.Button();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDescendente = new System.Windows.Forms.RadioButton();
            this.rdbAscendente = new System.Windows.Forms.RadioButton();
            this.lstCampoParaOrdenar = new System.Windows.Forms.ListBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAceptarNombre);
            this.groupBox1.Controls.Add(this.btnQuitarFiltro);
            this.groupBox1.Controls.Add(this.btnAceptarIdCliente);
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(33, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(489, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por:";
            // 
            // btnAceptarNombre
            // 
            this.btnAceptarNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptarNombre.Location = new System.Drawing.Point(343, 69);
            this.btnAceptarNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptarNombre.Name = "btnAceptarNombre";
            this.btnAceptarNombre.Size = new System.Drawing.Size(119, 37);
            this.btnAceptarNombre.TabIndex = 8;
            this.btnAceptarNombre.Text = "Aceptar";
            this.btnAceptarNombre.UseVisualStyleBackColor = true;
            this.btnAceptarNombre.Click += new System.EventHandler(this.btnAceptarNombre_Click);
            // 
            // btnQuitarFiltro
            // 
            this.btnQuitarFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitarFiltro.Location = new System.Drawing.Point(343, 110);
            this.btnQuitarFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitarFiltro.Name = "btnQuitarFiltro";
            this.btnQuitarFiltro.Size = new System.Drawing.Size(119, 37);
            this.btnQuitarFiltro.TabIndex = 7;
            this.btnQuitarFiltro.Text = "Quitar filtro";
            this.btnQuitarFiltro.UseVisualStyleBackColor = true;
            this.btnQuitarFiltro.Click += new System.EventHandler(this.btnQuitarFiltro_Click);
            // 
            // btnAceptarIdCliente
            // 
            this.btnAceptarIdCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptarIdCliente.Location = new System.Drawing.Point(343, 30);
            this.btnAceptarIdCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptarIdCliente.Name = "btnAceptarIdCliente";
            this.btnAceptarIdCliente.Size = new System.Drawing.Size(119, 37);
            this.btnAceptarIdCliente.TabIndex = 6;
            this.btnAceptarIdCliente.Text = "Aceptar";
            this.btnAceptarIdCliente.UseVisualStyleBackColor = true;
            this.btnAceptarIdCliente.Click += new System.EventHandler(this.btnAceptarIdCliente_Click);
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(107, 119);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(215, 24);
            this.cboEstado.TabIndex = 5;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(107, 81);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(215, 22);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(107, 49);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(132, 22);
            this.txtIdCliente.TabIndex = 1;
            this.txtIdCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdCliente_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Cliente:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDescendente);
            this.groupBox2.Controls.Add(this.rdbAscendente);
            this.groupBox2.Controls.Add(this.lstCampoParaOrdenar);
            this.groupBox2.Location = new System.Drawing.Point(533, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(368, 171);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordenar por:";
            // 
            // rdbDescendente
            // 
            this.rdbDescendente.AutoSize = true;
            this.rdbDescendente.Location = new System.Drawing.Point(244, 78);
            this.rdbDescendente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbDescendente.Name = "rdbDescendente";
            this.rdbDescendente.Size = new System.Drawing.Size(113, 21);
            this.rdbDescendente.TabIndex = 2;
            this.rdbDescendente.TabStop = true;
            this.rdbDescendente.Text = "Descendente";
            this.rdbDescendente.UseVisualStyleBackColor = true;
            this.rdbDescendente.CheckedChanged += new System.EventHandler(this.rdbDescendente_CheckedChanged);
            // 
            // rdbAscendente
            // 
            this.rdbAscendente.AutoSize = true;
            this.rdbAscendente.Location = new System.Drawing.Point(244, 38);
            this.rdbAscendente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbAscendente.Name = "rdbAscendente";
            this.rdbAscendente.Size = new System.Drawing.Size(104, 21);
            this.rdbAscendente.TabIndex = 1;
            this.rdbAscendente.TabStop = true;
            this.rdbAscendente.Text = "Ascendente";
            this.rdbAscendente.UseVisualStyleBackColor = true;
            this.rdbAscendente.CheckedChanged += new System.EventHandler(this.rdbAscendente_CheckedChanged);
            this.rdbAscendente.Click += new System.EventHandler(this.rdbAscendente_Click);
            // 
            // lstCampoParaOrdenar
            // 
            this.lstCampoParaOrdenar.FormattingEnabled = true;
            this.lstCampoParaOrdenar.ItemHeight = 16;
            this.lstCampoParaOrdenar.Location = new System.Drawing.Point(27, 28);
            this.lstCampoParaOrdenar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstCampoParaOrdenar.Name = "lstCampoParaOrdenar";
            this.lstCampoParaOrdenar.Size = new System.Drawing.Size(208, 116);
            this.lstCampoParaOrdenar.TabIndex = 0;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMensaje.Location = new System.Drawing.Point(33, 230);
            this.lblMensaje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(46, 17);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "label4";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(33, 252);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(868, 185);
            this.dgvDatos.TabIndex = 3;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // FormaBuscarCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(920, 460);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormaBuscarCustomers";
            this.Text = "Buscar Customers";
            this.Load += new System.EventHandler(this.FormaBuscarCustomers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptarIdCliente;
        private System.Windows.Forms.Button btnQuitarFiltro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstCampoParaOrdenar;
        private System.Windows.Forms.RadioButton rdbDescendente;
        private System.Windows.Forms.RadioButton rdbAscendente;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnAceptarNombre;
    }
}
