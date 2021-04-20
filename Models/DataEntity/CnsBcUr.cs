using System;
using System.Collections.Generic;

namespace ApiBuro.Models
{
    public partial class CnsBcUr
    {
        public int PkUr { get; set; }
        public string NumeroControlConsulta { get; set; }
        public string NumeroReferenciaOperador { get; set; }
        public string SolicitudClienteErronea { get; set; }
        public string VersionProporcionadaErronea { get; set; }
        public string ProductoSolicitadoErroneo { get; set; }
        public string PasswordOclaveErronea { get; set; }
        public string SegmentoRequeridoNoProporcionado { get; set; }
        public string UltimaInformacionValidaCliente { get; set; }
        public string InformacionErroneaParaConsulta { get; set; }
        public string ValorErroneoCampoRelacionado { get; set; }
        public string ErrorSistemaBuroCredito { get; set; }
        public string EtiquetaSegmentoErronea { get; set; }
        public string OrdenErroneoSegmento { get; set; }
        public string NumeroErroneoSegmentos { get; set; }
        public string FaltaCampoRequerido { get; set; }
        public string ErrorReporteBloqueado { get; set; }
    }
}
