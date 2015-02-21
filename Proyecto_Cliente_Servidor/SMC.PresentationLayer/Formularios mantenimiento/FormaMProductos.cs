using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Devart.Data.PostgreSql;

namespace SMC.PresentationLayer.Formularios_mantenimiento
{
    public partial class FormaMProductos : SMC.PresentationLayer.FormaPlantillaAgregarModificar
    {
        DataSet _datos;
        int boton;
        public FormaMProductos()
        {
            InitializeComponent();
            _datos = new DataSet();
        }

        public FormaMProductos(int botonPresionado)
        {
            InitializeComponent();
            _datos = new DataSet();
            this.boton = botonPresionado;
        }
        private void recuperar() {
            PgSqlConnection connection = new PgSqlConnection();
          //  string cadena = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
           // Conexion.CadenaConexion = connection;
            connection.ConnectionString = Conexion.CadenaConexion;
             

            try
            {
                PgSqlDataAdapter adapter = new PgSqlDataAdapter();
                PgSqlCommand command = new PgSqlCommand();
                command.CommandText = "SELECT PRODUCTCODE,DESCRIPTION,UNITPRICE,ONHANDQUANTITY FROM PRODUCTS";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                
                adapter.SelectCommand = command;



                adapter.Fill(_datos, "PRODUCTS");
                dgvProductos.DataSource = _datos;
                dgvProductos.DataMember = "PRODUCTS";

            }
            catch (PgSqlException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                // Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show(Excepciones.MensajePersonalizado,
                    "Error de SQL Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }//errores del cliente.
            catch (Exception ex)
            {
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show(Excepciones.MensajePersonalizado,
                    "Error de C#",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                //if (connection.State == ConnectionState.Open)
                //{
                //    //Cerrar la conexion.
                //    connection.Close();
                //}

                //Liberar memoria.
                connection.Dispose();
            }
        }

        private void FormaMProductos_Load(object sender, EventArgs e)
        {
            if(boton==1){
                //cuando instaciamos desde el formulario factura detalle
                //no necesitamos los botones de guardar y cancelar
                //por lo tanto los desabilitamos
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;
                recuperar();
            }
            else {
                recuperar();
            }
            
        }

      

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PgSqlConnection connection = new PgSqlConnection();



            try
            {

                connection.ConnectionString = Conexion.CadenaConexion;

                connection.Open();
                PgSqlDataAdapter adapter = new PgSqlDataAdapter();
                PgSqlCommand commandInsert = new PgSqlCommand();

                #region insertar
                commandInsert.CommandText = "INSERT INTO PRODUCTS(PRODUCTCODE,DESCRIPTION,UNITPRICE,ONHANDQUANTITY) " +
                                        "VALUES(:PRODUCTCODE,:DESCRIPTION,:UNITPRICE,:ONHANDQUANTITY)";
                commandInsert.CommandType = CommandType.Text;
                commandInsert.Connection = connection;

                //crear y agregar parametros
                commandInsert.Parameters.Add(":PRODUCTCODE", PgSqlType.Char, 10, "PRODUCTCODE");
                commandInsert.Parameters.Add(":DESCRIPTION", PgSqlType.VarChar, 50, "DESCRIPTION");
                commandInsert.Parameters.Add(":UNITPRICE", PgSqlType.Double, 8, "UNITPRICE");
                commandInsert.Parameters.Add(":ONHANDQUANTITY", PgSqlType.Double, 38, "ONHANDQUANTITY");
                #endregion
                #region eliminar
                PgSqlCommand commandDelete = new PgSqlCommand();
                //Preparar el SQL
                string delete = "DELETE FROM PRODUCTS " +
                                "WHERE PRODUCTCODE= :PRODUCTCODE";
                commandDelete.CommandText = delete;
                commandDelete.CommandType = CommandType.Text;
                commandDelete.Connection = connection;

                commandDelete.Parameters.Add(":PRODUCTCODE", PgSqlType.Char, 10, "PRODUCTCODE");
                #endregion
                #region actualizar
                string update = "UPDATE PRODUCTS SET DESCRIPTION=:DESCRIPTION,UNITPRICE=:UNITPRICE," +
                                "ONHANDQUANTITY=:ONHANDQUANTITY WHERE PRODUCTCODE=:PRODUCTCODE";

                PgSqlCommand commandUpdate = new PgSqlCommand(update, connection);

                // crear y agregar parametros
                commandUpdate.Parameters.Add(":DESCRIPTION", PgSqlType.VarChar, 50, "DESCRIPTION");
                commandUpdate.Parameters.Add(":UNITPRICE", PgSqlType.Double, 8, "UNITPRICE");
                commandUpdate.Parameters.Add(":ONHANDQUANTITY", PgSqlType.Double, 38, "ONHANDQUANTITY");
                commandUpdate.Parameters.Add(":PRODUCTCODE", PgSqlType.Char, 10, "PRODUCTCODE");

                #endregion
                adapter.InsertCommand = commandInsert;
                adapter.DeleteCommand = commandDelete;
                adapter.UpdateCommand = commandUpdate;

                DataSet temporal = new DataSet();
                temporal.Merge(_datos);
                adapter.Update(temporal, "PRODUCTS");
                _datos.Clear();
                recuperar();


            }
            catch (PgSqlException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                // Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show("No se puede actualizar la PK",
                    "Error de PgSql Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }//errores del cliente.
            catch (Exception ex)
            {
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show("No se puede actualizar la PK",
                    "Error de C#",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                //if (connection.State == ConnectionState.Open)
                //{
                //    //Cerrar la conexion.
                //    connection.Close();
                //}

                //Liberar memoria.
                connection.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _datos.Clear();
            recuperar();
        }

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (boton == 1)
                {
                    String producto = (dgvProductos.Rows[e.RowIndex].Cells["PRODUCTCODE"].Value.ToString());
                    String precio = (dgvProductos.Rows[e.RowIndex].Cells["UNITPRICE"].Value.ToString());
                    SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura detalle = (SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura)Application.OpenForms[3];
                    DataRow row = detalle.dt.NewRow();//creas un registro 
                    row["PRODUCTO"] = producto; //Le añadres un valor 
                    row["PRECIO"] = precio;
                    detalle.dt.Rows.Add(row); //añades el registro a la tabla 
                    detalle.dgvDetalle.DataSource = detalle.dt; //añades la tabla al datagrid 
                    detalle.dgvDetalle.Update(); //actualizas
                    //detalle.dgvDetalle.U
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"ERROR AL PASAR DATOS");
            }
            
        }
    }
}
