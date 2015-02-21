using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Devart.Data.PostgreSql;

namespace SMC.PresentationLayer.Formularios_modificacion
{
    public partial class OrderOptionsAgregar : SMC.PresentationLayer.FormaPlantillaAgregarModificar
    {
        public OrderOptionsAgregar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PgSqlConnection connection = new PgSqlConnection();
            try
            {
                //Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;
                connection.Open();

                PgSqlCommand commandInsert = new PgSqlCommand();
                commandInsert.CommandText = "INSERT INTO OrderOptions (SalesTaxRate, FirstBookShipCharge, AdditionalBookShipCharge) "
                                 + " VALUES(:SalesTaxRate, :FirstBookShipCharge, :AdditionalBookShipCharge)";
                commandInsert.CommandType = CommandType.Text;
                commandInsert.Connection = connection;

                PgSqlDataAdapter adapter = new PgSqlDataAdapter();
                commandInsert.Parameters.Add(":SalesTaxRate", PgSqlType.Int, 38).Value=txtTasa.Text;
                commandInsert.Parameters.Add(":FirstBookShipCharge", PgSqlType.Int, 38).Value=txtPrime.Text;
                commandInsert.Parameters.Add(":AdditionalBookShipCharge", PgSqlType.Int,38).Value=txtAdicional.Text;
                
                
                int filasActualizadas = commandInsert.ExecuteNonQuery();//filasActualizadas = 1

                if (filasActualizadas > 0)
                {
                    MessageBox.Show("Registro Insertado Correctamente",
                        "Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puedo insertar el registro",
                        "Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                
            }
            catch
            {

                MessageBox.Show("Error de PgSql Server No Se Puede Conectar");
                      
            }
       }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtTasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(sender, e);
        }
  }
}
