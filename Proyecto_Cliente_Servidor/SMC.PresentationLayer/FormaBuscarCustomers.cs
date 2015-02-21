using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Devart.Data.PostgreSql;


namespace SMC.PresentationLayer
{
    public partial class FormaBuscarCustomers : SMC.PresentationLayer.FormaPlantillaPrincipal
    {
        private DataView _dataViewCustomes;
        public delegate void enviar(String mensaje);
        public event enviar eventoUno;
        public static FormaBuscarCustomers forma = new FormaBuscarCustomers();
        int valor;
        public FormaBuscarCustomers()
        {
            InitializeComponent();
            _dataViewCustomes = new DataView();
        }

        public FormaBuscarCustomers(int identificador)
        {
            this.valor = identificador;
            InitializeComponent();
            _dataViewCustomes = new DataView();
        }
        private void FormaBuscarCustomers_Load(object sender, EventArgs e)
        {
            PgSqlConnection connection = new PgSqlConnection();
             //Conexion.CadenaConexion = connection.ConnectionString;

           // Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            connection.ConnectionString = Conexion.CadenaConexion;

             
             String select = "SELECT CustomerID,Name,Address,City,State,ZipCode " +
                          "FROM Customers";
             PgSqlCommand command = new PgSqlCommand(select, connection);

             PgSqlDataAdapter adapter = new PgSqlDataAdapter();
            adapter.SelectCommand = command;

            DataSet dataset = new DataSet();

            adapter.Fill(dataset,"Customers");
            dgvDatos.DataSource = dataset;
            dgvDatos.DataMember = "Customers";
            lblMensaje.Text = "Filas recuperadas: " + dataset.Tables[0].Rows.Count;
               DataView _datViewCustomers= new DataView() ;

               _dataViewCustomes = dataset.Tables["Customers"].DefaultView;
               dgvDatos.DataSource = _dataViewCustomes;
            //---------------------------------------------------------------------
            //Recuperar datos de la tabla:States y mostrarlos en el combo box
            select = "SELECT StateCode,StateName " +
                    "FROM States";
            command.CommandText = select;
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            connection.Open();
            // usar un DataReader para recuperar los datos
            PgSqlDataReader reader = command.ExecuteReader(); //sqlDataReader no tiene contructor
            DataTable table = new DataTable();
            table.Load(reader); //leer los datos

            //vincular-enlazar los datos del dataTable
            //al comboBox.
            cboEstado.DataSource = table;
            cboEstado.DisplayMember = "StateName";

            cboEstado.ValueMember = "StateCode";

            //
            for (int i = 0; i < _dataViewCustomes.Table.Columns.Count; i++)
            {
                lstCampoParaOrdenar.Items.Add(_dataViewCustomes.Table.Columns[i].ColumnName);
            }
        }


        private void btnAceptarIdCliente_Click(object sender, EventArgs e)
        {
            _dataViewCustomes.RowFilter = "CustomerID=" + txtIdCliente.Text.Trim() + "";
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;//

            //MOstrar los datos una vez filtrados.
            dgvDatos.DataSource =_dataViewCustomes;
            lblMensaje.Text ="Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void btnAceptarNombre_Click(object sender, EventArgs e)
        {
            //establecer la busqueda por campo: CustomerID
            //__dataViewCustomes.RowFilter : SELECT* FROM Customers WHERE CustomerID......
            _dataViewCustomes.RowFilter = "Name LIKE '"+txtNombre.Text.Trim()+"%'"; //patron de busqueda
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewCustomes;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            _dataViewCustomes.RowFilter = "Name LIKE '" + txtNombre.Text.Trim() + "%'"; //patron de busqueda
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewCustomes;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //establecer la busqueda por campo: State
            //__dataViewCustomes.RowFilter : SELECT* FROM Customers WHERE CustomerID......
            _dataViewCustomes.RowFilter = "State = '"+cboEstado.SelectedValue+"' "; //patron de busqueda
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewCustomes;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                //FormaMcliente form = (FormaMcliente)Application.OpenForms[0];
                //form. acer= "hola";

                //FormaMcliente f = new FormaMcliente();
                //f.acer = "hola";
                this.eventoUno("hola mundo");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "CUSTOMER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbAscendente_CheckedChanged(object sender, EventArgs e)
        {
           if(lstCampoParaOrdenar.SelectedIndex>=0)
           {
               _dataViewCustomes.Sort = lstCampoParaOrdenar.SelectedItem+" ASC";
               //MOSTRAR LOS DATOS UNA VEZ ORDENADOS
               dgvDatos.DataSource = _dataViewCustomes;

               //MOSTRAR el criterio de ordenamiento
               lblMensaje.Text = "Ordenado por : " + lstCampoParaOrdenar.SelectedItem +
                                   "ascendentemente";
           }
        }

        private void rdbDescendente_CheckedChanged(object sender, EventArgs e)
        {
            if (lstCampoParaOrdenar.SelectedIndex >= 0)
            {
                _dataViewCustomes.Sort = lstCampoParaOrdenar.SelectedItem + " DESC";
                //MOSTRAR LOS DATOS UNA VEZ ORDENADOS
                dgvDatos.DataSource = _dataViewCustomes;

                //MOSTRAR el criterio de ordenamiento
                lblMensaje.Text = "Ordenado por : " + lstCampoParaOrdenar.SelectedItem +
                                    "descendentemente";
            }
        }

        private void rdbAscendente_Click(object sender, EventArgs e)
        {
           
        }

      

        

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (valor == 1)
                {
                    String IDValor = (dgvDatos.Rows[e.RowIndex].Cells["CUSTOMERID"].Value.ToString());
                    SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura detalle = (SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura)Application.OpenForms[3];
                 //  detalle.txtCliente.ReadOnly = false;
                  
                    detalle.cliente = IDValor;
                }
                else if (valor == 2)
                {
                    String nombre = (dgvDatos.Rows[e.RowIndex].Cells["NAME"].Value.ToString());
                    String id = (dgvDatos.Rows[e.RowIndex].Cells["CUSTOMERID"].Value.ToString());
                    String direccion = (dgvDatos.Rows[e.RowIndex].Cells["ADDRESS"].Value.ToString());
                    String ciudad = (dgvDatos.Rows[e.RowIndex].Cells["CITY"].Value.ToString());
                    String estado = (dgvDatos.Rows[e.RowIndex].Cells["STATE"].Value.ToString());
                    String codezip = (dgvDatos.Rows[e.RowIndex].Cells["ZIPCODE"].Value.ToString());
                    FormaMcliente customer = (FormaMcliente)Application.OpenForms[2];
                   
                    customer.txtNombre.Text = nombre;
                    customer.txtIDcliente.Text = id;
                    customer.txtDireccion.Text = direccion;
                    customer.txtCiudad.Text = ciudad;
                    customer.txtEstado.Text = estado;
                    customer.txtCodigoZip.Text = codezip;

                }
                
            }
            catch(Exception ex){
                MessageBox.Show("ERROR","CUSTOMER",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(sender, e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(sender, e);
        }
    }
}
