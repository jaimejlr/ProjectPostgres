using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SMC.PresentationLayer
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           //Application.Run(new SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura());
       // Application.Run(new SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura());
            //Application.Run(new SMC.PresentationLayer.Resources.FormaBuscarProductos());
           //Application.Run(new SMC.PresentationLayer.Formularios_mantenimiento.OrderOptions());
           Application.Run(new FormaIngreso());
        //SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado
        }
    }
}
