using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMC.PresentationLayer
{
    class Validacion
    {
        public static void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == ' ')
                e.Handled = false;
            else
                e.Handled = true;
        }

        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
