using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiBuro.Models
{
    public partial class CnsBcScoreBc
    {
        
        public int? PkScoreBc { get; set; }
        public string? NumeroControlConsulta { get; set; }
        public string? NombreScore { get; set; }
        public string? CodigoScore { get; set; }
        public string? ValorScore { get; set; }
        public string? CodigoRazon { get; set; }
        public string? CodigoError { get; set; }
    }
}
