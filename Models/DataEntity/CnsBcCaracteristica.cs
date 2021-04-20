using System;
using System.Collections.Generic;

namespace ApiBuro.Models
{
    public partial class CnsBcCaracteristica
    {
        public int PkCaraceristica { get; set; }
        public string NumeroControlConsulta { get; set; }
        public string Plantilla { get; set; }
        public string PlantillaCaracteristica { get; set; }
        public string CodigoCaracteristica { get; set; }
        public string Valor { get; set; }
        public string CodigoError { get; set; }
    }
}
