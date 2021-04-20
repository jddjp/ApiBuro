using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBuro.Models
{
    public class ConsultaBc
    {

        public string? Version { get; set; }
        public string? NumeroReferenciaOperador { get; set; }
        public string? ProductoRequerido { get; set; }
        public string? ClavePais { get; set; }
        public string? IdentificadorBuro { get; set; }
        public string? ClaveUsuario { get; set; }
        public string? Password { get; set; }
        public string? TipoConsulta { get; set; }
        public string? TipoContrato { get; set; }
        public string? ClaveUnidadMonetaria { get; set; }
        public string? Idioma { get; set; }
        public string? TipoSalida { get; set; }

        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno  { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? RFC { get; set; }


        public string? Direccion1 { get; set; }
        public string? ColoniaPoblacion { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
        public string? CP { get; set; }
        public int Nombres { get; set; }
        public int Cuentas { get; set; }
        public int Score { get; set; }
        public int ResumenReporte { get; set; }


    }
}
