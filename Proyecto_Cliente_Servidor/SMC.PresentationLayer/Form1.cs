using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMC.PresentationLayer
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         public string this[int index]{
        set{
            textBox1.Text = value;
            }
    get{

        return textBox1.Text;
    }
        }

         public String mensaje {
             set
             {
                 textBox1.Text = value;
             }
             get
             {

                 return textBox1.Text;
             }
         }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormaBuscarCustomers b = new FormaBuscarCustomers();
            b.Show();
        }
    }
}
