using System;
using System.Collections.Generic;

namespace ApiBuro.Models
{
    public partial class CnsBcEncabezado
    {
        public int PkEncabezado { get; set; }
        public string NumeroReferenciaOperador { get; set; }
        public string ClavePais { get; set; }
        public string IdentificadorBuro { get; set; }
        public string ClaveOtorgante { get; set; }
        public string ClaveRetornoConsumidorPrincipal { get; set; }
        public string ClaveRetornoConsumidorSecundario { get; set; }
        public string NumeroControlConsulta { get; set; }
    }
}
