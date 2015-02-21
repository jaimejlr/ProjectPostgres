using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Devart.Data.PostgreSql;


namespace SMC.PresentationLayer.Formularios_modificacion
{
    public partial class FormaDetalleFactura : Form
    {
        public DataTable dt = new DataTable();
        int boton;
        public double totalProductos=0;
        public double totalApagar = 0;
        public double impuesto = 0;
        public string this[int indice]
        {
            set
            {
                txtCliente.Text = value;
            }
            get
            {
                return txtCliente.Text;
            }

        }

        public String cliente
        {
            set
            {
                txtCliente.Text = value;
            }
            get
            {
                return txtCliente.Text;
            }

        }
        
       
        
    
     private DataSet _datos;
     public FormaDetalleFactura()
        {
            InitializeComponent();
            _datos = new DataSet();
            boton = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.BotonPresionado;
        }
      
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void RecuperarDetalle() {
            PgSqlConnection connection = new PgSqlConnection();
            try
            {
                //Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;
                connection.Open();

                string select = "SELECT ProductCode as PRODUCTO,UnitPrice as PRECIO,Quantity as CANTIDAD,ItemTotal as TOTAL "+
                                "FROM InvoiceLineItems WHERE InvoiceID = :InvoiceID";

                PgSqlCommand command = new PgSqlCommand();
                command.CommandText = select;
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                command.Parameters.Add(":InvoiceID", PgSqlType.Int, 38).Value = Convert.ToInt32(txtNumeroFactura.Text);

                PgSqlDataAdapter adapter = new PgSqlDataAdapter();
                adapter.SelectCommand = command;

                adapter.Fill(_datos, "InvoiceLineItems");
                dgvDetalle.DataSource = _datos;
                dgvDetalle.DataMember = "InvoiceLineItems";

                //crear y agregar parametro

            }
            catch (PgSqlException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                // Excepciones.Gestionar(ex);

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

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SMC.PresentationLayer.FormaBuscarCustomers buscarCliente = new SMC.PresentationLayer.FormaBuscarCustomers(1);
            buscarCliente.ShowDialog();
        }

       

        private void FormaDetalleFactura_Load(object sender, EventArgs e)
        {

            //PgSqlConnection connection = new PgSqlConnection();


            
           
            if (boton == 2)
            {

                #region inicializar campos
                SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura factura = new Formularios_mantenimiento.FormaMFactura();
                txtNumeroFactura.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.NumeroFactura;
                txtCliente.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Cliente;
                txtFecha.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Fecha;
                txtTotalProductos.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.TotalProductos;
                txtImpuesto.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Impuesto;
                txtEnvio.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Envio;
                txtFacturaTotal.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.FacturaTotal;
                dt.Columns.Add("PRODUCTO"); //le creas las columnas 
                dt.Columns.Add("PRECIO");
                dt.Columns.Add("CANTIDAD");
                dt.Columns.Add("TOTAL");
                // DataRow row = dt.NewRow(); //creas un registro 
                //row["Nombre"] = "Guillermo"; //Le añadres un valor 
                //row["Apellido"] = "Salazar";
                //dt.Rows.Add(row); //añades el registro a la tabla 
                dgvDetalle.DataSource = dt;
                #endregion
                RecuperarDetalle();
            }
            else if(boton==1){
                txtCliente.Visible = true;

               //creas una tabla 
                dt.Columns.Add("PRODUCTO"); //le creas las columnas 
                dt.Columns.Add("PRECIO");
                dt.Columns.Add("CANTIDAD");
                dt.Columns.Add("TOTAL");
              
                dgvDetalle.DataSource = dt; //añades la tabla al datagrid 
                
               
            }
        }


      

        private void insertarFactura() {

         try
         {
             PgSqlConnection connection = new PgSqlConnection();
            // Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
             connection.ConnectionString = Conexion.CadenaConexion;

             string insert = "INSERT INTO INVOICES(InvoiceID,CustomerID,InvoiceDate,ProductTotal,SalesTax,Shipping,InvoiceTotal) " +
                              "VALUES(:InvoiceID,:CustomerID,:InvoiceDate,:ProductTotal,:SalesTax,:Shipping,:InvoiceTotal)";
            
             PgSqlCommand command = new PgSqlCommand(insert, connection);

             //creamos y añadimos parametros

             command.Parameters.Add(":InvoiceID", PgSqlType.Int, 6).Value = Convert.ToInt32(txtNumeroFactura.Text);
             command.Parameters.Add(":CustomerID", PgSqlType.Int, 38).Value = Convert.ToInt32(txtCliente.Text);
             command.Parameters.Add(":InvoiceDate", PgSqlType.Date, 5).Value = txtFecha.Value;
             command.Parameters.Add(":ProductTotal", PgSqlType.Double, 8).Value = Convert.ToDouble(txtTotalProductos.Text);
             command.Parameters.Add(":SalesTax", PgSqlType.Double, 8).Value = Convert.ToDouble(txtImpuesto.Text);
             command.Parameters.Add(":Shipping", PgSqlType.Double, 8).Value = Convert.ToDouble(txtEnvio.Text);
             command.Parameters.Add(":InvoiceTotal", PgSqlType.Double, 8).Value = Convert.ToDouble(txtFacturaTotal.Text);

             connection.Open();

             int filasInsertadas = command.ExecuteNonQuery();
             if (filasInsertadas > 0)
             {
                 MessageBox.Show("Registro insertado",
                         "Facturas",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                
             }
             else

                 MessageBox.Show("Registro no insertado",
                             "Facturas",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);

             #region seccion catch
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

                //Liberar memoria.
                //connection.Dispose();
            }
             #endregion

        }
        private void insertarDetalle() { 
        
            double factura;
            string producto;
            double precio;
            double cantidad;
            double total;

        foreach (DataGridViewRow row in dgvDetalle.Rows)
        {
         
            
            if (!string.IsNullOrEmpty(row.Cells["PRODUCTO"].FormattedValue.ToString()))
            {
               
                producto = (row.Cells["PRODUCTO"].Value.ToString()); 
                precio= Convert.ToDouble(row.Cells["PRECIO"].Value.ToString());
                cantidad = Convert.ToDouble((row.Cells["CANTIDAD"].Value.ToString()));
                totalProductos+=cantidad;
                total = precio * cantidad;
                totalApagar += total;
                row.Cells["TOTAL"].Value = Convert.ToString(total);
                
                txtTotalProductos.Text = totalProductos.ToString();
              
                factura= Convert.ToDouble(txtNumeroFactura.Text);
             
              inserttar(factura,producto,precio,cantidad,total);
               
            }
          
           
        }

      

        


        }

        private void inserttar(double factura,string producto,double precio,double cantidad,double total) { 
         PgSqlConnection connection = new PgSqlConnection();
           // Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            connection.ConnectionString = Conexion.CadenaConexion;
            try { 
                
           
            //preparar el insert
            string insert = "INSERT INTO InvoiceLineItems(InvoiceID,ProductCode,UnitPrice,Quantity,ItemTotal) " +
                                       "VALUES(:InvoiceID,:ProductCode,:UnitPrice,:Quantity,:ItemTotal)";

            PgSqlCommand command = new PgSqlCommand(insert, connection);

            //creamos y añadimos parametros

             //crear y agregar parametros
                command.Parameters.Add(":InvoiceID", PgSqlType.Double, 38).Value = factura;
                command.Parameters.Add(":ProductCode", PgSqlType.Char, 10).Value= producto;
                command.Parameters.Add(":UnitPrice", PgSqlType.Double, 8).Value = precio;
                command.Parameters.Add(":Quantity", PgSqlType.Double, 38).Value = cantidad;
                command.Parameters.Add(":ItemTotal", PgSqlType.Double, 8).Value= total;

            connection.Open();

            int filasInsertadas = command.ExecuteNonQuery();
            if (filasInsertadas > 0)
            {
                //MessageBox.Show("Registro insertado",
                //        "Detalle",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
                
                //dgvDetalle.DataMember = null;
                //dt = (DataTable)dgvDetalle.DataSource;
                //dt.Clear();
            }
            else
            
                MessageBox.Show("Registro no insertado",
                            "Detalle",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
           int boton= SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.BotonPresionado;
           if (boton == 2)
           {

               insertarDetalle();
           }
           else
           {
               insertarFactura();
               insertarDetalle();
           }
            

        }

    
        

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          SMC.PresentationLayer.Formularios_mantenimiento.FormaMProductos productos= new  SMC.PresentationLayer.Formularios_mantenimiento.FormaMProductos(1);
         
          productos.button1.Visible = false;
          productos.button2.Visible = false;
            productos.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            

        }

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(sender, e);
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(sender, e);
        }

        private void txtTotalProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(sender, e);
        }
    }

  
}
