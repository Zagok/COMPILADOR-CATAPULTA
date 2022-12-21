using System.Collections.Generic;
using System.Linq;
using EntidadesCompilador;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ManejadorCompilador
{

    public class ManejadorLexico
    {
        string[] reservadas = { "Inicio", "Fin", "Cargar", "Soltar", "Izquierda", "Derecha"};// 6
        public static List<EntidadTokens> Tokens = new List<EntidadTokens>(); // 4
        const string ERROR_LEXICO = "No identificado";//1
        public string Reservadas(string token, int i)
        {
            string r = "";//1
            bool validar = false;//1
            //for (int i = 0; i < reservadas.Length; i++)//6
            //{
            if (i < reservadas.Length)
            {

                if (token.Equals(reservadas[i]))//1
                {
                    validar = true;//1
                    //break;//1
                }
                //i++;
                //return r;



                //}
                if (validar == true)//1
                {
                    if (token.Equals("Inicio") || token.Equals("Fin")
                        || token.Equals("Cargar") || token.Equals("Soltar")
                        || token.Equals("Izquierda") || token.Equals("Derecha"))//1
                    {
                        r = "Palabra Reservada";//1
                    }
                }
                else//1
                {
                    r = ERROR_LEXICO;//1
                }
                if (Regex.IsMatch(token, @"[/][/]\w+"))//1
                {
                    r = "Comentario";//1
                }
                else if (Regex.IsMatch(token, "[(][0-9]+[)]"))//1
                {
                    r = "Expresión";//1
                }
                return Reservadas(token, i = i + 1);            
            }
            return r;//1
        }
        int count = 0; //1
        int linea = 0;//1
        
        string[] tokens;//1
        public void AnalizadorLexico(string codigo, DataGridView tabla, int i)
        {
            Tokens.Clear();//1
            string[] lines = codigo.Split('\n');//1
            //for (int i = 0; i < lines.Length; i++)//+x
            //{
            if (i < lines.Length)
            {

                linea = i + 1;//1
                tokens = lines[i].Split(' ', '\r');//+x
                //for (int j = 0; j < tokens.Length; j++)//+x
                //{
                AnalizadorLexico2(tabla, i);

                //}
                tabla.DataSource = Tokens.ToList();//+x
                tabla.AutoResizeColumns();//1
                //i++;

                //}
                AnalizadorLexico(codigo, tabla, i=i+1);
            }
            else
                i = 0;


        }
        public void AnalizadorLexico2(DataGridView tabla, int j)
        {
            if (j < tokens.Length)
            {

                if (tokens[j] != "")//1
                {
                    tokens[j] = tokens[j].Replace(" ", "");//+x
                    count++;//1
                    Tokens.Add(new EntidadTokens(count, tokens[j], Reservadas(tokens[j], 0), linea));//+x
                    MessageBox.Show(tokens[j]);
                }
                //j++;
                AnalizadorLexico2(tabla, j = j + 1);
            }
            else j = 0;
        }
    }
}
