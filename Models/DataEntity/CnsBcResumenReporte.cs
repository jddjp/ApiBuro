using System;
using System.Collections.Generic;

namespace ApiBuro.Models
{
    public partial class CnsBcResumenReporte
    {
        public int PkResumenReporte { get; set; }
        public string NumeroControlConsulta { get; set; }
        public string FechaIngresoBd { get; set; }
        public string NumeroMop7 { get; set; }
        public string NumeroMop6 { get; set; }
        public string NumeroMop5 { get; set; }
        public string NumeroMop4 { get; set; }
        public string NumeroMop3 { get; set; }
        public string NumeroMop2 { get; set; }
        public string NumeroMop1 { get; set; }
        public string NumeroMop0 { get; set; }
        public string NumeroMopur { get; set; }
        public string NumeroCuentas { get; set; }
        public string CuentasPagosFijosHipotecas { get; set; }
        public string CuentasRevolventesAbiertas { get; set; }
        public string CuentasCerradas { get; set; }
        public string CuentasNegativasActuales { get; set; }
        public string CuentasClavesHistoriaNegativa { get; set; }
        public string CuentasDisputa { get; set; }
        public string NumeroSolicitudesUltimos6Meses { get; set; }
        public string NuevaDireccionReportadaUltimos60Dias { get; set; }
        public string MensajesAlerta { get; set; }
        public string ExistenciaDeclaracionesConsumidor { get; set; }
        public string TipoMoneda { get; set; }
        public string TotalCreditosMaximosRevolventes { get; set; }
        public string TotalLimitesCreditoRevolventes { get; set; }
        public string TotalSaldosActualesRevolventes { get; set; }
        public string TotalSaldosVencidosRevolventes { get; set; }
        public string TotalPagosRevolventes { get; set; }
        public string PctLimiteCreditoUtilizadoRevolventes { get; set; }
        public string TotalCreditosMaximosPagosFijos { get; set; }
        public string TotalSaldosActualesPagosFijos { get; set; }
        public string TotalSaldosVencidosPagosFijos { get; set; }
        public string TotalPagosPagosFijos { get; set; }
        public string NumeroMop96 { get; set; }
        public string NumeroMop97 { get; set; }
        public string NumeroMop99 { get; set; }
        public string FechaAperturaCuentaMasAntigua { get; set; }
        public string FechaAperturaCuentaMasReciente { get; set; }
        public string TotalSolicitudesReporte { get; set; }
        public string FechaSolicitudReporteMasReciente { get; set; }
        public string NumeroTotalCuentasDespachoCobranza { get; set; }
        public string FechaAperturaCuentaMasRecienteDespachoCobranza { get; set; }
        public string NumeroTotalSolicitudesDespachosCobranza { get; set; }
        public string FechaSolicitudMasRecienteDespachoCobranza { get; set; }
    }
}
