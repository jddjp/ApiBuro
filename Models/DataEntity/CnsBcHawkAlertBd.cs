﻿using System;
using System.Collections.Generic;

namespace ApiBuro.Models
{
    public partial class CnsBcHawkAlertBd
    {
        public int PkHawkAlertBd { get; set; }
        public string NumeroControlConsulta { get; set; }
        public string FechaReporte { get; set; }
        public string CodigoClave { get; set; }
        public string TipoInstitucion { get; set; }
        public string Mensaje { get; set; }
    }
}
