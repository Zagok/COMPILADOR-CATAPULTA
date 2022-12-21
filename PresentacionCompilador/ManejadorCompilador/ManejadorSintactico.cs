using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesCompilador;

namespace ManejadorCompilador
{
    public class ManejadorSintactico
    {
        ManejadorLexico lexico = new ManejadorLexico();
        public string[] errores = System.IO.File.ReadAllLines("Errores.txt");
        int contar = 0;
        public List<EntidadErrores> error;
        public string Sintactico(DataGridView tabla)
        {
            error = new List<EntidadErrores>();
            contar = 0;
            string rs = "";

            RevisarSubir(tabla);
            RevisarBajar(tabla);
            RevisarIzquierda(tabla);
            RevisarDerecha(tabla);

            foreach (var item in error)
            {
                rs+= string.Format("Error {0} {1} en linea: {2}", item._Numero, item._Descripcion, item._Linea);
            }
            return rs;
        }
        //Árboles sintacticos
        public string RevisarSubir(DataGridView tabla)
        {
            try
            {
                string r = "";
                int linea;
                 
                for (int i = 0; i < tabla.RowCount; i++)
                {
                    if (tabla.Rows[i].Cells[1].Value.ToString().Equals("Cargar"))
                    {
                        if (tabla.Rows[i + 1].Cells[2].Value.ToString().Equals("Expresión"))
                        {
                        }
                        else
                        {
                            linea = int.Parse(tabla.Rows[i].Cells["Linea"].Value.ToString());
                            contar++;
                            r = errores[1];
                            error.Add(new EntidadErrores(linea, contar, r));
                        }
                    }
                }
                return r;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string RevisarBajar(DataGridView tabla)
        {
            try
            {
                string r = "";
                int linea;

                for (int i = 0; i < tabla.RowCount; i++)
                {
                    if (tabla.Rows[i].Cells[1].Value.ToString().Equals("Soltar"))
                    {
                        if (tabla.Rows[i + 1].Cells[2].Value.ToString().Equals("Expresión"))
                        {
                        }
                        else
                        {
                            linea = int.Parse(tabla.Rows[i].Cells["Linea"].Value.ToString());
                            contar++;
                            r = errores[1];
                            error.Add(new EntidadErrores(linea, contar, r));
                        }
                    }
                }
                return r;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string RevisarIzquierda(DataGridView tabla)
        {
            try
            {
                string r = "";
                int linea;

                for (int i = 0; i < tabla.RowCount; i++)
                {
                    if (tabla.Rows[i].Cells[1].Value.ToString().Equals("Izquierda"))
                    {
                        if (tabla.Rows[i + 1].Cells[2].Value.ToString().Equals("Expresión"))
                        {
                        }
                        else
                        {
                            linea = int.Parse(tabla.Rows[i].Cells["Linea"].Value.ToString());
                            contar++;
                            r = errores[1];
                            error.Add(new EntidadErrores(linea, contar, r));
                        }
                    }
                }
                return r;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string RevisarDerecha(DataGridView tabla)
        {
            try
            {
                string r = "";
                int linea;

                for (int i = 0; i < tabla.RowCount; i++)
                {
                    if (tabla.Rows[i].Cells[1].Value.ToString().Equals("Derecha"))
                    {
                        if (tabla.Rows[i + 1].Cells[2].Value.ToString().Equals("Expresión"))
                        {
                        }
                        else
                        {
                            linea = int.Parse(tabla.Rows[i].Cells["Linea"].Value.ToString());
                            contar++;
                            r = errores[1];
                            error.Add(new EntidadErrores(linea, contar, r));
                        }
                    }
                }
                return r;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}

