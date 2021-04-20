using System;
using System.Collections.Generic;

namespace ApiBuro.Models
{
    public partial class CnsBcConsultaEfectuada
    {
        public int PkConsultaEfectuada { get; set; }
        public string NumeroControlConsulta { get; set; }
        public string FechaConsulta { get; set; }
        public string IdentificacionBuro { get; set; }
        public string ClaveOtorgante { get; set; }
        public string NombreOtorgante { get; set; }
        public string TelefonoOtorgante { get; set; }
        public string TipoContrato { get; set; }
        public string ClaveUnidadMonetaria { get; set; }
        public string ImporteContrato { get; set; }
        public string IndicadorTipoResponsabilidad { get; set; }
        public string ConsumidorNuevo { get; set; }
        public string ResultadoFinal { get; set; }
        public string IdentificadorOrigenConsulta { get; set; }
    }
}
