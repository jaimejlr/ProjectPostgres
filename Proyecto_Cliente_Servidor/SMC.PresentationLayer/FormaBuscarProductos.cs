using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace SMC.PresentationLayer.Resources
{
    public partial class FormaBuscarProductos : Form
    {
         private DataSet _datos;
          
        private DataView _dataViewProducts;
        public FormaBuscarProductos()
        {
            InitializeComponent();
            _dataViewProducts = new DataView();
            this.Text = "Buscar Producto";
            _datos = new DataSet();
        }

        private void FormaBuscarProductos_Load(object sender, EventArgs e)
        {
            recuperar();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void recuperar()
        {

            #region hola
            //OracleConnection connection = new OracleConnection();


            //Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            //connection.ConnectionString = Conexion.CadenaConexion;


            //String select = "SELECT PRODUCTCODE as CODIGO,DESCRIPTION as DESCRIPCION,"+
            //    "UNITPRICE as PRECIO_UNITARIO,ONHANDQUANTITY as CANTIDAD_DISPONIBLE FROM PRODUCTS";
            //OracleCommand command = new OracleCommand(select, connection);

            //OracleDataAdapter adapter = new OracleDataAdapter();
            //adapter.SelectCommand = command;

            //DataSet dataset = new DataSet();

            //adapter.Fill(dataset, "PRODUCTS");
            //dgvDatos.DataSource = dataset;
            //dgvDatos.DataMember = "PRODUCTS";
            //lblMensaje.Text = "Filas recuperadas: " + dataset.Tables[0].Rows.Count;
            ////DataView _datViewCustomers = new DataView();

            ////_dataViewProducts = dataset.Tables["PRODUCTS"].DefaultView;
            ////dgvDatos.DataSource = _dataViewProducts;
            ////---------------------------------------------------------------------
            ////Recuperar datos de la tabla:States y mostrarlos en el combo box
            ////select = "SELECT StateCode,StateName " +
            ////        "FROM States";
            ////command.CommandText = select;
            ////command.CommandType = CommandType.Text;
            ////command.Connection = connection;

            //connection.Open();
            //// usar un DataReader para recuperar los datos
            //OracleDataReader reader = command.ExecuteReader(); //sqlDataReader no tiene contructor
            ////DataTable table = new DataTable();
            ////table.Load(reader); //leer los datos

            ////vincular-enlazar los datos del dataTable
            ////al comboBox.
            ////cboEstado.DataSource = table;
            ////cboEstado.DisplayMember = "StateName";

            ////cboEstado.ValueMember = "StateCode";

            ////
            //for (int i = 0; i < _dataViewProducts.Table.Columns.Count; i++)
            //{
            //    lstCampoParaOrdenar.Items.Add(_dataViewProducts.Table.Columns[i].ColumnName);
            //}
            #endregion

            OracleConnection connection = new OracleConnection();
            // String ora_connect = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            connection.ConnectionString = Conexion.CadenaConexion;
            OracleDataAdapter adapter = new OracleDataAdapter();

            //Crear y un configurar: Command
            OracleCommand command = new OracleCommand();
            //command.CommandText = "SELECT * FROM States";
            command.CommandText = "SELECT PRODUCTCODE as CODIGO,DESCRIPTION as DESCRIPCION," +
                  "UNITPRICE as PRECIO,ONHANDQUANTITY as DISPONIBLE FROM PRODUCTS";
            command.CommandType = CommandType.Text;
            command.Connection = connection;
           // dgvDatos.Width = 20;
            //Configurar el DataAdapter
            adapter.SelectCommand = command;//SELECT

            //adapter.InsertCommand = command;//INSERT
            //adapter.DeleteCommand = command;//DELETE
            //adapter.UpdateCommand = command;//UPDATE

            //3.- Crear y configurar un objeto: DataSet
            //DataSet datos = new DataSet();//base de datos.
            //_datos = new DataSet();               
           
            //

            // Bind the DataGridView controls to the BindingSource
            // components and load the data from the database.
            //DataGridViewColumn column = dgvDatos.Columns[8];
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            DataGrid G = new DataGrid();
           
            adapter.Fill(_datos, "PRODUCTS");//(0)

            //adapter.Fill(temporal, "States");//(0)
            //if (_datos.Tables["States"].Rows.Count == 0)

            //adapter.Fill(_datos, "Products");//(1)

            //Fill:
            //1.- Abrir la conexion (open)
            //2.- Utilizar la propiedad: SelectCommand del adapter para hacer el SELECT
            //3.- Crear un clase (DataTable) con estructura del tabla segun el SELECT
            //4.- Recupera los datos y llena el Datable.
            //5.- Cierra la conexion.

            //4.- Vincular-enlazar (MOSTRAR) los datos del DataSet a un control.
            dgvDatos.DataSource = _datos;//DataSet, DataTable, DataView, Collectins, Generics
            dgvDatos.DataMember = "PRODUCTS";//mostrar la tabla: States
        }
    }
}
