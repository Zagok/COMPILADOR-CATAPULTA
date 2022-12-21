using System;
using System.IO;
using System.Windows.Forms;

namespace ManejadorCompilador
{
    public class ManejadorTraductor
    {

        public void Traducir(DataGridView tabla)
        {
            string rt = "";
            //Proceso
            string setup = "", loop = "", otros = "", libreria = "";
            //Iniciar traducción
            setup = "void setup()\r\n{\r\n"+ TraducirSetup(tabla)+"}";
            loop = "void loop(){";
            otros = "}";

            rt = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}",libreria,setup,loop,otros);

            try
            {
                StreamWriter sw = new StreamWriter("codigo.ino");
                sw.WriteLine(rt);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string TraducirSetup(DataGridView tabla)
        {
            string rs = "";
            for (int i = 0; i < tabla.RowCount; i++)
            {
                if (tabla.Rows[i].Cells[1].Value.ToString().Equals("Subir") ||
                   tabla.Rows[i].Cells[1].Value.ToString().Equals("Bajar") ||
                   tabla.Rows[i].Cells[1].Value.ToString().Equals("Izquierda") ||
                   tabla.Rows[i].Cells[1].Value.ToString().Equals("Derecha") ||
                   tabla.Rows[i].Cells[1].Value.ToString().Equals("Estirar") ||
                   tabla.Rows[i].Cells[1].Value.ToString().Equals("Abrir") ||
                   tabla.Rows[i].Cells[1].Value.ToString().Equals("Cerrar"))
                   rs += "pinMode" + tabla.Rows[i + 1].Cells[1].Value.ToString().Substring(0,tabla.Rows[i + 1].Cells[1].Value.ToString().Length-1)+",OUTPUT);\r\n";
            }
            return rs;
        }
    }
}
