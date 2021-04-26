using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBuro.Models
{
   
        public class CnsInfoBuro
    {
        public CnsBcNombre CnsBcNombre { get; set; }
        public List<CuentaSP> CnsBcCuenta { get; set; }
        public List<CnsBcScoreBc> CnsBcScoreBc { get; set; }
        public List<CnsBcResumenReporte> CnsBcResumenReporte { get; set; }
       
        //public List<CnsBcEncabezado> CnsBcEncabezado { get; set; }



    }


    
}

