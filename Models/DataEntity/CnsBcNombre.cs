using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiBuro.Models
{
    public partial class CnsBcNombre
    {
        
        public int? PkNombre { get; set; }
        public string? NumeroControlConsulta { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? ApellidoAdicional { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? Rfc { get; set; }
        public string? Prefijo { get; set; }
        public string? Sufijo { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Residencia { get; set; }
        public string? NumeroLicenciaConducir { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Sexo { get; set; }
        public string? NumeroCedulaProfesional { get; set; }
        public string? NumeroRegistroElectoral { get; set; }
        public string? ClaveImpuestosOtroPais { get; set; }
        public string? ClaveOtroPais { get; set; }
        public string? NumeroDependientes { get; set; }
        public string? EdadesDependientes { get; set; }
        public string? FechaRecepcionInformacionDependientes { get; set; }
        public string? FechaDefuncion { get; set; }
        public DateTime? FechaRegistro { get; set; }

    }
}
