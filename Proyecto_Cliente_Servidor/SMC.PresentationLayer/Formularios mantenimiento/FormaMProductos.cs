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
        public int probar = 0;
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
            connection.ConnectionString = "User Id=postgres;Password=postgres;Host=localhost;Database=MMABOOKS;Initial Schema=public";
            //connection.ConnectionString = Conexion.CadenaConexion;
             

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
                this.Location = new Point(830, 200);
                //cuando instaciamos desde el formulario factura detalle
                //no necesitamos los botones de guardar y cancelar
                //por lo tanto los desabilitamos
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;
                recuperar();
                dgvProductos.ReadOnly = true;
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
                SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura detalle = (SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura)Application.OpenForms[1];
             //  detalle.dgvDetalle.Columns["PRODUCT"].ReadOnly = false;
                if (boton == 1)
                {
                    dgvProductos.ReadOnly = true;
                    String producto = (dgvProductos.Rows[e.RowIndex].Cells["PRODUCTCODE"].Value.ToString());
                    String precio = (dgvProductos.Rows[e.RowIndex].Cells["UNITPRICE"].Value.ToString());
                     //[3]
                    DataRow row = detalle.dt.NewRow();//creas un registro 
                    row["PRODUCTO"] = producto; //Le añadres un valor 
                    row["PRECIO"] = precio;
                    //detalle.dgvDetalle.Columns["PRODUCTO"].Frozen = false;
                   
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

        private void dgvProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            


        }

       

        private void dgvProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            int testInt;
            double testDouble;
            #region validar codigo 
            if (e.ColumnIndex == 0) {

                if (e.FormattedValue.ToString().Length != 0)
                {
                    try
                    {
                        if (int.TryParse(e.FormattedValue.ToString(), out testInt))
                            
                        {
                            

                            dgvProductos.Rows[e.RowIndex].ErrorText = "Debe ser un alfabetico \n menor o igual a 10";
                            e.Cancel = true;
                        }
                        else
                        {
                            dgvProductos.Rows[e.RowIndex].ErrorText = string.Empty;
                            e.Cancel = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: codigo  deber ser alfabeticos");
                    }
                }
            }
            #endregion

            #region validar descripcion
            if (e.ColumnIndex == 1)
            {

                if (e.FormattedValue.ToString().Length != 0)
                {
                    try
                    {
                        if (int.TryParse(e.FormattedValue.ToString(), out testInt))
                        {
                            dgvProductos.Rows[e.RowIndex].ErrorText = "Debe ser un alfabetico \n menor o igual a 50";
                            e.Cancel = true;
                        }
                        else
                        {
                            dgvProductos.Rows[e.RowIndex].ErrorText = string.Empty;
                            e.Cancel = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: descripcion deber ser alfabetico");
                    }
                }
            }
            #endregion

            #region validar precio
            else if (e.ColumnIndex == 2)
          {
              if (e.FormattedValue.ToString().Length != 0)
              {
                  try{
                  if (!double.TryParse(e.FormattedValue.ToString(), out testDouble))
                  {
                      dgvProductos.Rows[e.RowIndex].ErrorText = "Debe ser un numero \n entero o decimal";
                      e.Cancel = true;
                  }
                  else
                  {
                      dgvProductos.Rows[e.RowIndex].ErrorText = string.Empty;
                      e.Cancel = false;
                  }
                  }
                  catch(Exception ex){
                  MessageBox.Show("Error: precio deber ser numero");
                  }
              }
          }
            #endregion

            #region validar cantidad disponible
            else if (e.ColumnIndex == 3)
            {
                if (e.FormattedValue.ToString().Length != 0)
                {
                    try
                    {
                        if (!int.TryParse(e.FormattedValue.ToString(), out testInt))
                        {
                            dgvProductos.Rows[e.RowIndex].ErrorText = "Debe ser un \n numero entero ";
                            e.Cancel = true;
                        }
                        else
                        {
                            dgvProductos.Rows[e.RowIndex].ErrorText = string.Empty;
                            e.Cancel = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: cantidad deber ser numerico");
                    }
                }
            }
            #endregion
        }

        private void dgvProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this, "Precio y Cantidad deben ser numeros", "Error");
            e.ThrowException = false;
            e.Cancel = false;
        }

        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            
}

        private void FormaMProductos_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormaMProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("hola");
            //if (boton == 1)
            //{
            //    SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura detalle = new SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura();
            //    //MessageBox.Show("hola");
            //    detalle.detalle.dgvDetalle.Columns["PRODUCT"].ReadOnly = true;
            //    detalle.Close();
            //    this.Dispose();
            //    this.Close();
                
            //}
        }
            
            
            
                 
        }
            
      }

        
        
    

