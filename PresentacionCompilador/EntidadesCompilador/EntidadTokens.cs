using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompilador
{
    public class EntidadTokens
    {
        public EntidadTokens(int no, string token, string descripcion, int linea)
        {
            No = no;
            Token = token;
            Descripcion = descripcion;
            Linea = linea;
        }

        public int No { get; set; }
        public string Token { get; set; }
        public string Descripcion { get; set; }
        public int Linea { get; set; }


    }
}
