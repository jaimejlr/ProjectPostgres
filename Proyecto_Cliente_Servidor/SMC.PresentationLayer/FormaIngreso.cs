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
    public partial class FormaIngreso : SMC.PresentationLayer.FormaPlantillaPrincipal
    {
        public FormaIngreso()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Crear un objeto para la conexion entre cliente/servidor.
            PgSqlConnection connection = new PgSqlConnection();
            //OdbcConnection connection = new OdbcConnection();
            //OleDbConnection connection2 = new OleDbConnection();
            try
            {

                //connection2.ConnectionString = "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI";

                //Establecer las principales propiedades del Connection.
                connection.ConnectionString = "User Id=postgres;Password=jaime;Host=localhost;Database=MMABooks;Initial Schema=public"; ;//jaime
               // connection.ConnectionString = "User Id=postgres;Password=uta007008;Host=192.168.1.10;Database=MMABooks;Initial Schema=public";//quinaluisa
                //connection.ConnectionString = "User Id="+txtUsuario.Text+"; Password="+txtContraseña.Text+"; Data Source="+txtServidor.Text+"";
                //"Data Source="+txtServidor.Text+";Initial Catalog="+txtBaseDatos.Text+";User ID="+txtUsuario.Text+";Password="+txtContraseña.Text+"";
                
                //Almacenar el ConnectionString  en un campo estatico
                Conexion.CadenaConexion = connection.ConnectionString;//set
                Conexion.BaseDatos = txtBaseDatos.Text;
                Conexion.Servidor = txtServidor.Text;
                Conexion.Usuario = txtUsuario.Text;
                Conexion.Contraseña = txtContraseña.Text;

                //Establecer la conexion entre c/s.
                connection.Open();//ConnectionString

                //Cerrar la forma actual.
                this.Hide();

                //Crear un objeto FormaMenu
                FormaMenu forma = new FormaMenu();
                forma.ShowDialog();
            }//errores de BD.
            catch (PgSqlException ex)
            {
                
                
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show(Excepciones.MensajePersonalizado, 
                    "Error de PgSql ", 
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
                //Cerrar la conexion.
                connection.Close();
                //Liberar memoria.
                connection.Dispose();
            }
        }

        private void txtServidor_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormaIngreso_Load(object sender, EventArgs e)
        {

        }
    }
}
