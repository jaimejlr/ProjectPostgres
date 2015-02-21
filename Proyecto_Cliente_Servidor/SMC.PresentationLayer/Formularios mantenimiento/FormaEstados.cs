using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;//DataSet
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Devart.Data.PostgreSql;

namespace SMC.PresentationLayer
{
     public partial class FormaEstados : SMC.PresentationLayer.FormaPlantillaAgregarModificar
     {
         private DataSet _datos;
         public int var = 0;
        public FormaEstados()
        {
            InitializeComponent();

            //Inicializar el DataSet
           
            _datos = new DataSet();
        }

        private void FormaEstados_Load(object sender, EventArgs e)
        {
            Recuperar();
        }

        private void Recuperar()
        {
            //Recuperar los datos de la tabla: States y mostrarlos 
            //en el DataGridView.

            //1.-Crear-instanciar y configurar un objeto: Connection.
            PgSqlConnection connection = new PgSqlConnection();
           // String ora_connect = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
          //  Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            connection.ConnectionString = Conexion.CadenaConexion;
           // connection.ConnectionString = "User Id=postgres;Password=postgres;Host=localhost;Database=MMABOOKS;Initial Schema=public";

            try
            {
                //connection.ConnectionString = "Data Source=(local);Initial Catalog=MMABooks;User ID=sa;Password=sa";
               
               // connection.ConnectionString = Conexion.CadenaConexion;//get

                //Abrir la conexion.
                //connection.Open();//ConnectionString

                //2.-Crear y configurar un DataAdapter
                //tiene 4 objecto de tipo: Comand. SELECT, INSERT, DELETE, UPDATE
                PgSqlDataAdapter adapter = new PgSqlDataAdapter();

                //Crear y un configurar: Command
                PgSqlCommand command = new PgSqlCommand();
                //command.CommandText = "SELECT * FROM States";
                command.CommandText = "SELECT StateCode, StateName FROM States";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                //Configurar el DataAdapter
                adapter.SelectCommand = command;//SELECT

                //adapter.InsertCommand = command;//INSERT
                //adapter.DeleteCommand = command;//DELETE
                //adapter.UpdateCommand = command;//UPDATE

                //3.- Crear y configurar un objeto: DataSet
                //DataSet datos = new DataSet();//base de datos.
                //_datos = new DataSet();               

                adapter.Fill(_datos, "States");//(0)

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
                dgvDatos.DataMember = "States";//mostrar la tabla: States

            }//errores de BD.
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Recuperar los datos de la tabla: States y mostrarlos 
            //en el DataGridView.

            //1.-Crear-instanciar y configurar un objeto: Connection.
            PgSqlConnection connection = new PgSqlConnection();

            try
            {
                //connection.ConnectionString = "Data Source=(local);Initial Catalog=MMABooks;User ID=sa;Password=sa";
                connection.ConnectionString = Conexion.CadenaConexion;//get

                //Abrir la conexion.
                connection.Open();//ConnectionString

                //2.-Crear y configurar un DataAdapter
                //tiene 4 objecto de tipo: Comand. SELECT, INSERT, DELETE, UPDATE
                PgSqlDataAdapter adapter = new PgSqlDataAdapter();

                #region Insert 
                //Crear y un configurar los Command
                //INSERT
                PgSqlCommand commandInsert = new PgSqlCommand();


                //INSERT CON PARAMETROS EN SQL SERVER
                commandInsert.CommandText = "INSERT INTO States (StateCode, StateName) VALUES (:StateCode, :StateName)";//Sql Server.
                commandInsert.CommandType = CommandType.Text;
                commandInsert.Connection = connection;

                //Cuando el SQL tiene parametros hay que hacer lo siguiente:
                //1.- Crear el o los parametros.
                //2.- Hay que agregar los parametros a la coleccion de parametros
                //    (Parameters) del Command.
                //3.- Enviar los valores para cada parametro
                //    ANTES DE EJECUTAR EL SQL.

                //1.- Crear el o los parametros.
               PgSqlParameter parametro1 = new PgSqlParameter();
                parametro1.ParameterName = ":StateCode";
                parametro1.PgSqlType = PgSqlType.Char;
                parametro1.Size = 2;                
                //solo para el caso en el que valor del parametro se tome 
                //de una celda del DataGridView
                parametro1.SourceColumn = "StateCode";

                PgSqlParameter parametro2 = new PgSqlParameter(":StateName", PgSqlType.VarChar, 20, "StateName");

                //2.- Hay que agregar el o los parametros a la coleccion de parametros
                //    (Parameters) del Command.
                commandInsert.Parameters.Add(parametro1);//posicion (0)
                commandInsert.Parameters.Add(parametro2);//posicion (1)

              

                //    NOTA: En el caso del DataGridView que esta vinculado al DataSet
                //          no hace falta enviar los valores para los parametros, porque
                //          los toma de las CELDAS del DataGridView AUTOMATICAMENTE.

                #endregion

                #region Delete

                ////Crear y configuar los Command para el DELETE y el UPDATE
                PgSqlCommand commandDelete = new PgSqlCommand();
                //Preparar el SQL
                string delete = "DELETE FROM States " +
                                "WHERE StateCode= :StateCode";
                commandDelete.CommandText = delete;
                commandDelete.CommandType = CommandType.Text;
                commandDelete.Connection = connection;
                //Como tiene parametros el SQL.
                //1, 2 - Crear y agregar el o los parametros.
                commandDelete.Parameters.Add(":StateCode", PgSqlType.Char, 2, "StateCode");//parameter1
                //3.- Enviar los valores para cada parametro
                //commandDelete.Parameters.Add("@StateCode", SqlDbType.Char, 2).Value = "XA";//parameter1

                //#endregion

                //#region Update

                ////Crear un configurar un Command (UPDATE)
                string update = "UPDATE States SET StateName=:StateName WHERE StateCode=:StateCode";
               

                PgSqlCommand commandUpdate = new PgSqlCommand(update, connection);
                //Como tiene parametros el SQL.
                //1, 2 - Crear y agregar el o los parametros al objeto Command
                commandUpdate.Parameters.Add(":StateName", PgSqlType.VarChar, 20, "StateName");
                commandUpdate.Parameters.Add(":StateCode", PgSqlType.Char, 2, "StateCode");

                #endregion

                //Configurar las propiedades del DataAdapter
                //a) InsertCommand
                //b) DeleteCommand
                //c) UpdateCommand
                adapter.InsertCommand = commandInsert;//INSERT
                adapter.DeleteCommand = commandDelete;//DELETE
                adapter.UpdateCommand = commandUpdate;//UPDATE

                //3.- Crear y configurar un objeto: DataSet
                //DataSet datos = new DataSet();//base de datos.
                //_datos = new DataSet();

                DataSet temporal = new DataSet();                

                //temporal = _datos.Copy();
                temporal.Merge(_datos);//copia la estructuras pero solo con los modificados.

                adapter.Update(temporal, "States");

                _datos.Clear();
                Recuperar();

                //UPDATE:                
                //1.- Abrir la conexion (open)
                //2.- Utilizar la propiedades: 
                //    InsertCommand(INSERT)
                //    DeleteCommand (DELETE)
                //    UpdateCommand (UPDATE) del adapter
                //    para actualizar la base de datos.               
                //    NOTA: Esto se lo hace usando la propiedad: (RowState) 
                //          de cada objeto DataTable.
                //3.- Cierra la conexion.
                
                MessageBox.Show("Datos actualizados", "states");
            }//errores de BD.
            catch (PgSqlException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                //Excepciones.Gestionar(ex);

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
                //Liberar memoria.
                connection.Dispose();
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int testInt;
            #region validar codigo
            if (e.ColumnIndex == 0)
            {

                if (e.FormattedValue.ToString().Length != 0)
                {
                    try
                    {
                        if (int.TryParse(e.FormattedValue.ToString(), out testInt))
                        {
                            dgvDatos.Rows[e.RowIndex].ErrorText = "Debe ser un alfabetico \n menor o igual a 2";
                            e.Cancel = true;
                        }
                        else
                        {
                            dgvDatos.Rows[e.RowIndex].ErrorText = string.Empty;
                            e.Cancel = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: codigo deber ser alfabetico");
                    }
                }
            }
            #endregion
            #region validar nombre
            if (e.ColumnIndex == 1)
            {

                if (e.FormattedValue.ToString().Length != 0)
                {
                    try
                    {
                        if (int.TryParse(e.FormattedValue.ToString(), out testInt))
                        {
                            dgvDatos.Rows[e.RowIndex].ErrorText = "Debe ser un alfabetico \n menor o igual a 20";
                            e.Cancel = true;
                        }
                        else
                        {
                            dgvDatos.Rows[e.RowIndex].ErrorText = string.Empty;
                            e.Cancel = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: nombre deber ser alfabetico");
                    }
                }
            }
            #endregion
        }

        private void dgvDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }

        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }
    }
}
