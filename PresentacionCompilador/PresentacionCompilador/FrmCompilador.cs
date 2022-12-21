using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManejadorCompilador;
using System.IO;
using System.Diagnostics;

namespace PresentacionCompilador
{
    public partial class FrmCompilador : Form
    {
        ManejadorLexico ml;
        ManejadorSintactico ms;
        ManejadorSemantico mse;
        ManejadorTraductor mt;
        public FrmCompilador()
        {
            InitializeComponent();
            ml = new ManejadorLexico();
            ms = new ManejadorSintactico();
            mse = new ManejadorSemantico();
            mt = new ManejadorTraductor();
        }
        
        void Cargar()
        {
            ml.AnalizadorLexico(txtCodigo.Text, dtgTabla, 0);

             if (dtgTabla.RowCount>0)
             {
                 string r = ms.Sintactico(dtgTabla);
                 if (r.Length > 0)
                     MessageBox.Show(r);
                 else
                 {
                    r= mse.Semantico(dtgTabla);
                    if (r.Length > 0)
                        MessageBox.Show(r);
                    else
                    {
                        mt.Traducir(dtgTabla);
                        MessageBox.Show("Traducción exitosa");
                    }
                 }        
             }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   
        }

        private void btnTraducir_Click(object sender, EventArgs e)
        {
            //Crear archivo bat
            try
            {
                StreamWriter sw = new StreamWriter("cargar.bat");
                sw.WriteLine("ArduinoUploader codigo.ino 1 COM3");
                sw.WriteLine("pause");
                sw.Close();
                //Lanzar archivo
                Process.Start("cargar.bat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
