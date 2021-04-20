using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBuro.Models.DataEntrada
{
    public class EncabezadoConsultaBC
    {
        [Key]
        public string? Version { get; set; }
        public string? NumeroReferenciaOperador { get; set; }
        public string? ProductoRequerido { get; set; }
        public string? ClavePais { get; set; }
        public string? IdentificadorBuro { get; set; }
        public string? ClaveUsuario { get; set; }
        public string? Password { get; set; }

        public string? Tipoconsulta { get; set; }

        public string? TipoContrato { get; set; }
        public string? ClaveUnidadMonetaria { get; set; }

        public string? Idioma { get; set; }
        public string? TipoSalida { get; set; }
    }
}
