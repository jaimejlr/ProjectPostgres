﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Devart.Data.PostgreSql;

namespace SMC.PresentationLayer.Formularios_modificacion
{
    public partial class FormaAMempleado : SMC.PresentationLayer.FormaPlantillaAgregarModificar
    {
        public FormaAMempleado()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PgSqlConnection connection = new PgSqlConnection();
            //Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            connection.ConnectionString = Conexion.CadenaConexion;
            try { 
                if(SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.BotonPresionado==1){
            #region insertar
            //preparar el insert
            string insert = "INSERT INTO EMPLOYEES(LASTNAME,FIRSTNAME,TITLE,HIREDATE,POSTALCODE) " +
                             "VALUES(:LASTNAME,:FIRSTNAME,:TITLE,:HIREDATE,:POSTALCODE)";

            PgSqlCommand command = new PgSqlCommand(insert, connection);

            //creamos y añadimos parametros

            command.Parameters.Add(":LASTNAME", PgSqlType.VarChar, 20).Value = txtApellido.Text;
            command.Parameters.Add(":FIRSTNAME", PgSqlType.VarChar, 10).Value = txtNombre.Text;
            command.Parameters.Add(":TITLE", PgSqlType.VarChar, 30).Value = txtTitulo.Text;
            command.Parameters.Add(":HIREDATE", PgSqlType.Date, 5).Value = txtFecha.Value;
            command.Parameters.Add(":POSTALCODE", PgSqlType.VarChar, 10).Value = txtCodigoPostal.Text;

            connection.Open();

            int filasInsertadas = command.ExecuteNonQuery();
            if (filasInsertadas > 0)
            {
                MessageBox.Show("Registro insertado",
                        "Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                txtApellido.Clear();
                txtCodigoPostal.Clear();
                txtNombre.Clear();
                txtTitulo.Clear();
                txtFecha.Text = "";
            }
            else
            
                MessageBox.Show("Registro no insertado",
                            "Clientes",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);


            #endregion
                }

                else if (SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.BotonPresionado == 2)
                {
                    #region actualizar
                    string update = "UPDATE EMPLOYEES SET LASTNAME=:LASTNAME,FIRSTNAME=:FIRSTNAME," +
                                    "TITLE=:TITLE,HIREDATE=:HIREDATE,POSTALCODE=:POSTALCODE" +
                                    " WHERE EMPLOYEEID=:EMPLOYEEID";

                    PgSqlCommand commandUpdate = new PgSqlCommand(update, connection);

                    //crear y agregar parametros
                    commandUpdate.Parameters.Add(":LASTNAME", PgSqlType.VarChar, 20).Value = txtApellido.Text;
                    commandUpdate.Parameters.Add(":FIRSTNAME", PgSqlType.VarChar, 10).Value = txtNombre.Text;
                    commandUpdate.Parameters.Add(":TITLE", PgSqlType.VarChar, 30).Value = txtTitulo.Text;
                    commandUpdate.Parameters.Add(":HIREDATE", PgSqlType.Date, 5).Value = txtFecha.Value;
                    commandUpdate.Parameters.Add(":POSTALCODE", PgSqlType.VarChar, 10).Value = txtCodigoPostal.Text;
                    commandUpdate.Parameters.Add(":EMPLOYEEID",PgSqlType.Int,9).Value = (SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.IDEmployee);

                    connection.Open();
                    int filasActualizadas = commandUpdate.ExecuteNonQuery();
                    if (filasActualizadas > 0)
                    {

                        MessageBox.Show("Registro actualizado",
                                 "Clientes",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro no actualizado",
                                    "Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    }
                    #endregion
                }
            } catch (PgSqlException ex)
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
            
        

       
        private void FormaAMempleado_Load(object sender, EventArgs e)
        {
            this.txtApellido.Select();
            if (SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.BotonPresionado == 2)
            {
                txtApellido.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.Apellido;
                txtNombre.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.Nombre;
                txtTitulo.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.Titulo;
                txtCodigoPostal.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.CodigoPostal;
                txtFecha.Value = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.Fecha;
            }
            else {
                txtApellido.Clear();
                txtNombre.Clear();
                txtTitulo.Clear();
                txtCodigoPostal.Clear();
            }
        }

        private void txtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(sender, e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(sender, e);
        }

        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(sender, e);
        }
    }
}
