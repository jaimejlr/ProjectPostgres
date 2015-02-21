﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;//DataSet, DataTable
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Devart.Data.PostgreSql;

namespace SMC.PresentationLayer
{
    public partial class FormaAMcliente : SMC.PresentationLayer.FormaPlantillaAgregarModificar
    {
        public FormaAMcliente()
        {
            InitializeComponent();
        }

        private void FormaAMcliente_Load(object sender, EventArgs e)
        {
            this.Location = new Point(530, 130);
            //Se presiono el boton: Modificar.
            if (FormaMcliente.BotonPresionado == 2)
            {
                //Mostrar el registro en los controles.
                txtNombre.Text = FormaMcliente.Nombre;
                txtDireccion.Text = FormaMcliente.Direccion;
                txtCiudad.Text = FormaMcliente.Ciudad;
                //txtEstado.Text = FormaMcliente.Estado; //ComboBox.
                txtCodigoZip.Text = FormaMcliente.CodigoZip;
            }

            PgSqlConnection connection = new PgSqlConnection();            

            try
            {
              //  connection.ConnectionString = Conexion.CadenaConexion;                
                connection.ConnectionString = "User Id=postgres;Password=postgres;Host=localhost;Database=MMABOOKS;Initial Schema=public";

                //Preparar el SQL para el objeto Command
                string select = "SELECT StateCode, StateName " +
                                "FROM States";
               PgSqlCommand command = new PgSqlCommand(select, connection);
                
                //Abrir la conexion
                connection.Open();//ConnectionString

                //Crear un DataReader para leer los datos (SELECT)
                //ejecutar el command.
                //SqlDataReader reader = command.ExecuteReader(CommandBehavior.SchemaOnly);
               PgSqlDataReader reader = command.ExecuteReader();

                #region Primera forma

                ////Recuperar fila por fila los datos del SELECT.
                //while (reader.Read())
                //{
                //    //Pasar los datos al ComboBox.
                //    //cboEstado.Items.Add(reader[0] + " " + reader[1]);
                //    cboEstado.Items.Add(reader["StateCode"] + " " + reader["StateName"]);
                //}

                ////Cerrar el cursor.
                //reader.Close();

                #endregion

                #region Segunda Forma

                //Utilizar un objeto: DataTable
                DataTable states = new DataTable();
                states.Load(reader);//Crea la estructura (TABLE) y recupera los datos.

                //Vincular-enlazar los datos del DataTable con el ComboBox.
                cboEstado.DataSource = states;
                cboEstado.DisplayMember = "StateName";//Columna a mostrar.
                cboEstado.ValueMember = "StateCode";//Columna para INSERTAR y ACTUALIZAR.

                //if (reader.IsClosed)
                //{
                //    MessageBox.Show("Cursor cerrado");
                //    reader.Close();
                //}
               
                #endregion
            }
            //errores de BD.
            catch (PgSqlException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show(Excepciones.MensajePersonalizado,
                    "Error de PgSql Server",
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
                //Cerrar la conexion
                connection.Close();

                //Liberar memoria.
                connection.Dispose();
            }
        }

        private void InsertarSQLEmbebido(PgSqlConnection connection) {

            //Se presiono el boton Insertar: 
            //Preparar el: INSERT.
            string insert = "INSERT INTO Customers (Name, Address, City, State, ZipCode) " +
                            "VALUES (:Name, :Address, :City, :State, :ZipCode)";

            PgSqlCommand command = new PgSqlCommand(insert, connection);

            //Como tiene parametros el SQL, hay que crear, agregar y enviar
            //los valores para los parametros.
            command.Parameters.Add(":Name", PgSqlType.VarChar, 100).Value = txtNombre.Text;
            command.Parameters.Add(":Address", PgSqlType.VarChar, 50).Value = txtDireccion.Text;
            command.Parameters.Add(":City", PgSqlType.VarChar, 20).Value = txtCiudad.Text;

            command.Parameters.Add(":State", PgSqlType.Char, 2).Value = cboEstado.SelectedValue.ToString();

            command.Parameters.Add(":ZipCode", PgSqlType.Char, 15).Value = txtCodigoZip.Text;

            //Abrir la conexion.
            connection.Open();

            //Ejecutar el SQL contra la BD.
            int filasInsertadas = command.ExecuteNonQuery();//filasInsertadas = 1

            if (filasInsertadas > 0)
            {
                MessageBox.Show("Registro insertado",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        
        }
        private void insertarStoreProcedure(PgSqlConnection connection)
        {
            //Se presiono el boton Insertar: 

            PgSqlCommand command = new PgSqlCommand();
            command.CommandText = "P_inssertar_Customers";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            //Como el store procedure tiene parametros hay que crear,agregar y enviar valores para los parametros
            //los valores para los parametros.
            command.Parameters.Add("@Name", PgSqlType.VarChar, 100).Value = txtNombre.Text;
            command.Parameters.Add("@Address", PgSqlType.VarChar, 50).Value = txtDireccion.Text;
            command.Parameters.Add("@City", PgSqlType.VarChar, 20).Value = txtCiudad.Text;

            command.Parameters.Add("@State", PgSqlType.Char, 2).Value = cboEstado.SelectedValue.ToString();

            command.Parameters.Add("@ZipCode", PgSqlType.Char, 15).Value = txtCodigoZip.Text;

            //Abrir la conexion.
            connection.Open();

            //Ejecutar el Store procedure de la BD.
            int filasInsertadas = command.ExecuteNonQuery();//filasInsertadas = 1

            if (filasInsertadas > 0)
            {
                MessageBox.Show("Registro insertado",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtCodigoZip.Text = "";
                txtCiudad.Text = "";
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PgSqlConnection connection = new PgSqlConnection();

            try
            {
                connection.ConnectionString = Conexion.CadenaConexion;

                //Verificar si se hace un INSERT o un UPDATE
                if (FormaMcliente.BotonPresionado == 1)
                {
                    InsertarSQLEmbebido(connection);
                    //insertarStoreProcedure(connection);
                }
                else//Actualizar el registro correspondiente.
                    if (FormaMcliente.BotonPresionado == 2)
                    {
                        //Se presiono el boton Modificar: 
                        //Preparar el: UPDATE.
                        string update = "UPDATE Customers SET  " +
                        "Name=:Name,Address=:Address,City=:City,State=:State,ZipCode=:ZipCode " +
                        "WHERE CustomerID=:CustomerID";

                        PgSqlCommand command = new PgSqlCommand(update, connection);
                        //Como tiene parametros el SQL, hay que crear, agregar y enviar
                        //los valores para los parametros.
                        command.Parameters.Add(":Name", PgSqlType.VarChar, 100).Value = txtNombre.Text;
                        command.Parameters.Add(":Address", PgSqlType.VarChar, 50).Value = txtDireccion.Text;
                        command.Parameters.Add(":City", PgSqlType.VarChar, 20).Value = txtCiudad.Text;

                        command.Parameters.Add(":State", PgSqlType.Char, 2).Value = cboEstado.SelectedValue.ToString();

                        command.Parameters.Add(":ZipCode", PgSqlType.Char, 15).Value = txtCodigoZip.Text;

                        //Parametro para el primary key. El para parametro se envia de la ventana anterior.
                        command.Parameters.Add(":CustomerID", PgSqlType.Int, 4).Value = FormaMcliente.CustomerID;

                        //Abrir la conexion.
                        connection.Open();

                        //Ejecutar el SQL contra la BD.
                        int filasActualizadas = command.ExecuteNonQuery();//filasActualizadas = 1

                        if (filasActualizadas > 0)
                        {
                            MessageBox.Show("Registro actualizado",
                                "Clientes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se puedo actualizar el cliente",
                                "Clientes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }

                    }
            }
            //errores de BD.
            catch (PgSqlException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

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
                //Cerrar la conexion
                connection.Close();

                //Liberar memoria.
                connection.Dispose();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(sender, e);
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(sender, e);
        }
    }
}
