using System;
using System.Collections.Generic;

namespace ApiBuro.Models
{
    public partial class CnsBcEmpleo
    {
        public int PkEmpleo { get; set; }
        public string NumeroControlConsulta { get; set; }
        public string NombreEmpresa { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string ColoniaPoblacion { get; set; }
        public string DelegacionMunicipio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Cp { get; set; }
        public string NumeroTelefono { get; set; }
        public string Extension { get; set; }
        public string Fax { get; set; }
        public string Cargo { get; set; }
        public string FechaContratacion { get; set; }
        public string ClaveMoneda { get; set; }
        public string Salario { get; set; }
        public string BaseSalarial { get; set; }
        public string NumeroEmpleado { get; set; }
        public string FechaUltimoDiaEmpleo { get; set; }
        public string FechaReportoEmpleo { get; set; }
        public string FechaVerificacionEmpleo { get; set; }
        public string ModoVerificacion { get; set; }
        public string CodPais { get; set; }
    }
}
