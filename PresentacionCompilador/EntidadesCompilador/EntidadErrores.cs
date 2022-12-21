using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompilador
{
    public class EntidadErrores
    {
        public EntidadErrores(int linea, int numero, string descripcion)
        {
            _Linea = linea;
            _Numero = numero;
            _Descripcion = descripcion;
        }

        public int _Linea { get; set; }
        public int _Numero { get; set; }
        public string _Descripcion { get; set; }
    }
}
