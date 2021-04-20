using System;
using System.Collections.Generic;

namespace ApiBuro.Models
{
    public partial class CnsBcDomicilio
    {
        public int PkDomicilio { get; set; }
        public string NumeroControlConsulta { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string ColoniaPoblacion { get; set; }
        public string DelegacionMunicipio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Cp { get; set; }
        public string FechaResidencia { get; set; }
        public string NumeroTelefono { get; set; }
        public string Extension { get; set; }
        public string Fax { get; set; }
        public string TipoDomicilio { get; set; }
        public string IndicadorEspecialDomicilio { get; set; }
        public string FechaReporteDireccion { get; set; }
        public string CodPais { get; set; }
    }
}
