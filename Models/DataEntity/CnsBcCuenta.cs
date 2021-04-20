using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiBuro.Models
{
    public partial class CnsBcCuenta
    {
        public int? PkCuenta { get; set; }
        
        public string? NumeroControlConsulta { get; set; }
        public string? FechaActualizacion { get; set; }
        public string? RegistroImpugnado { get; set; }
        public string? ClaveOtorgante { get; set; }
        public string? NombreOtorgante { get; set; }
        public string? NumeroTelefonoOtorgante { get; set; }
        public string? IdentificadorSociedadInformacionCrediticia { get; set; }
        public string? NumeroCuentaActual { get; set; }
        public string? IndicadorTipoResponsabilidad { get; set; }
        public string? TipoCuenta { get; set; }
        public string? TipoContrato { get; set; }
        public string? ClaveUnidadMonetaria { get; set; }
        public string? ValorActivoValuacion { get; set; }
        public string? NumeroPagos { get; set; }
        public string? FrecuenciaPagos { get; set; }
        public string? MontoPagar { get; set; }
        public string? FechaAperturaCuenta { get; set; }
        public string? FechaUltimoPago { get; set; }
        public string? FechaUltimaCompra { get; set; }
        public string? FechaCierreCuenta { get; set; }
        public string? FechaReporte { get; set; }
        public string? ModoReportar { get; set; }
        public string? UltimaFechaSaldoCero { get; set; }
        public string? Garantia { get; set; }
        public string? CreditoMaximo { get; set; }
        public string? SaldoActual { get; set; }
        public string? LimiteCredito { get; set; }
        public string? SaldoVencido { get; set; }
        public string? NumeroPagosVencidos { get; set; }
        public string? FormaPagoActual { get; set; }
        public string? HistoricoPagos { get; set; }
        public string? FechaMasRecienteHistoricoPagos { get; set; }
        public string? FechaMasAntiguaHistoricoPagos { get; set; }
        public string? ClaveObservacion { get; set; }
        public string? TotalPagosReportados { get; set; }
        public string? TotalPagosCalificadosMop2 { get; set; }
        public string? TotalPagosCalificadosMop3 { get; set; }
        public string? TotalPagosCalificadosMop4 { get; set; }
        public string? TotalPagosCalificadosMop5 { get; set; }
        public string? ImporteSaldoMorosidadHistMasGrave { get; set; }
        public string? FechaHistoricaMorosidadMasGrave { get; set; }
        public string? MopHistoricoMorosidadMasGrave { get; set; }
        public string? MontoUltimoPago { get; set; }
        public string? FechaInicioReestructura { get; set; }
    }
}
