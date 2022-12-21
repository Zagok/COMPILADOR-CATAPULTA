using System;
using System.Windows.Forms;

namespace ManejadorCompilador
{
    public class ManejadorSemantico
    {
        public string Semantico(DataGridView tabla)
        {
            string rs = "";
            rs = Regla1(tabla);
            if (rs.Length == 0)
                rs = Regla2(tabla);
            if (rs.Length == 0)
                rs = Regla3(tabla);
            if (rs.Length == 0)
                rs = Regla4(tabla);
            if (rs.Length == 0)
                rs = Regla5(tabla);
            if(rs.Length == 0)
                rs = Regla6(tabla);
           
            return rs;

        }
        public string Regla1(DataGridView tabla)
        {
            string r = "";
            if (!tabla.Rows[0].Cells[1].Value.ToString().Equals("Inicio"))
                r += "La primer línea debe de ser Inicio";
            return r;
        }
        public string Regla2(DataGridView tabla)
        {
            string r = "";

            if (!tabla.Rows[tabla.RowCount - 1].Cells[1].Value.ToString().Equals("Fin"))
                r += "La última linea debe de ser Fin";
            return r;
        }
        public string Regla3(DataGridView tabla)
        {
            string r = "";
            int Inicio = 0, Fin = 0;
            for (int i = 0; i < tabla.RowCount; i++)
            {
                if (tabla.Rows[i].Cells[1].Value.ToString() == "Inicio")
                    Inicio++;
                else if (tabla.Rows[i].Cells[1].Value.ToString() == "Fin")
                    Fin++;
            }
            if (Inicio > 1)
                r += "Hay más de un Inicio.";
            if (Fin > 1)
                r += " Hay más de un Fin.";
            return r;
        }

        public string Regla4(DataGridView tabla)
        {
            string r = "";

            for (int i = 0; i < tabla.RowCount; i++)
            {
                if (tabla.Rows[i].Cells[2].Value.ToString() == "Expresión")
                {
                    int valor = i + 1;
                    if (tabla.Rows[valor].Cells[2].Value.ToString() == "Expresión" && valor < tabla.RowCount)
                    {
                        r = "No debe haber dos expresiones juntas";
                    }
                }
            }
            return r;
        }
        public string Regla5(DataGridView tabla)
        {
            string r = "";
            string token = "";

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (tabla.Rows[i].Cells[2].Value.ToString() == "Expresión")
                {
                    token = tabla.Rows[i].Cells[1].Value.ToString();
                    token = token.Substring(1, token.Length - 2);
                    if (int.Parse(token) > 250)
                    {
                        r = "El límite máximo es 250";
                    }
                    else if (int.Parse(token) < 0)
                    {
                        r = "El límite mínimo es 0";
                    }
                }
            }

            return r;
        }

        public string Regla6(DataGridView tabla)
        {
            string r = "";
            try
            {
                for (int i = 0; i < tabla.RowCount; i++)
                {
                    if (tabla.Rows[i].Cells[2].Value.ToString() == "Expresión")
                    {
                        int valor = i + 1;

                        if (tabla.Rows[i - 1].Cells[1].Value.ToString() != "Cargar" && tabla.Rows[i - 1].Cells[1].Value.ToString() != "Soltar")
                        {
                            r = "No debe de haber expresiones vacías";

                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return r;
        }
    }
}