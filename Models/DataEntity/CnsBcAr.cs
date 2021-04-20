using System;
using System.Collections.Generic;

namespace ApiBuro.Models
{
    public partial class CnsBcAr
    {
        public int? PkAr { get; set; }
        public string? NumeroControlConsulta { get; set; }
        public string? ReferenciaOperador { get; set; }
        public string? SujetoNoAutenticado { get; set; }
        public string? ClaveOpasswordErroneo { get; set; }
        public string? ErrorSistemaBc { get; set; }
        public string? EtiquetaSegmentoErronea { get; set; }
        public string? FaltaCampoRequerido { get; set; }
        public string? ErrorReporteBloqueado { get; set; }
    }
}
