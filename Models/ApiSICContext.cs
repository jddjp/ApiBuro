using System;
using ApiBuro.Models.DataEntrada;
using ApiBuro.Models.InfoBcFiltro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiBuro.Models
{
    public partial class ApiSICContext : DbContext
    {
        public ApiSICContext()
        {
        }

        public ApiSICContext(DbContextOptions<ApiSICContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CnsBcAr> CnsBcAr { get; set; }
        public virtual DbSet<CnsBcCaracteristica> CnsBcCaracteristica { get; set; }
        public virtual DbSet<CnsBcConsultaEfectuada> CnsBcConsultaEfectuada { get; set; }
        public virtual DbSet<CnsBcCuenta> CnsBcCuenta { get; set; }
        public virtual DbSet<CnsBcDeclaracionConsumidor> CnsBcDeclaracionConsumidor { get; set; }
        public virtual DbSet<CnsBcDomicilio> CnsBcDomicilio { get; set; }
        public virtual DbSet<CnsBcEmpleo> CnsBcEmpleo { get; set; }
        public virtual DbSet<CnsBcEncabezado> CnsBcEncabezado { get; set; }
        public virtual DbSet<CnsBcHawkAlertBd> CnsBcHawkAlertBd { get; set; }
        public virtual DbSet<CnsBcHawkAlertC> CnsBcHawkAlertC { get; set; }
        public virtual DbSet<CnsBcNombre> CnsBcNombre { get; set; }
        public virtual DbSet<CnsBcResumenReporte> CnsBcResumenReporte { get; set; }
        public virtual DbSet<CnsBcScoreBc> CnsBcScoreBc { get; set; }
        public virtual DbSet<CnsBcUr> CnsBcUr { get; set; }

        public virtual DbSet<CodigoRespuestaBD> CodigoRespuestaBD { get; set; }
         public virtual DbSet<CuentaSP> CuentaSP { get; set; }

        public virtual DbSet<EncabezadoConsultaBC> EncabezadoConsultaBC { get; set; }
        public virtual DbSet<BuscarBCRFC> BuscarBCRFC { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.200.207;Initial Catalog=ConsultaSIC;User ID=nvo.backoffice;Password=Nb4ck4pr;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CnsBcAr>(entity =>
            {
                entity.HasKey(e =>e.NumeroControlConsulta);

                entity.ToTable("cnsBC_AR");

                entity.Property(e => e.ClaveOpasswordErroneo)
                    .HasColumnName("ClaveOPasswordErroneo")
                    .HasMaxLength(18);

                entity.Property(e => e.ErrorReporteBloqueado).HasMaxLength(1);

                entity.Property(e => e.ErrorSistemaBc)
                    .HasColumnName("ErrorSistemaBC")
                    .HasMaxLength(1);

                entity.Property(e => e.EtiquetaSegmentoErronea).HasMaxLength(2);

                entity.Property(e => e.FaltaCampoRequerido).HasMaxLength(4);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.PkAr)
                    .HasColumnName("pk_AR")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReferenciaOperador).HasMaxLength(25);

                entity.Property(e => e.SujetoNoAutenticado).HasMaxLength(23);
            });

            modelBuilder.Entity<CnsBcCaracteristica>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_Caracteristica");

                entity.Property(e => e.CodigoCaracteristica).HasMaxLength(10);

                entity.Property(e => e.CodigoError).HasMaxLength(2);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.PkCaraceristica)
                    .HasColumnName("pk_Caraceristica")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Plantilla).HasMaxLength(10);

                entity.Property(e => e.PlantillaCaracteristica).HasMaxLength(10);

                entity.Property(e => e.Valor).HasMaxLength(10);
            });

            modelBuilder.Entity<CnsBcConsultaEfectuada>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_ConsultaEfectuada");

                entity.Property(e => e.ClaveOtorgante).HasMaxLength(10);

                entity.Property(e => e.ClaveUnidadMonetaria).HasMaxLength(2);

                entity.Property(e => e.ConsumidorNuevo).HasMaxLength(1);

                entity.Property(e => e.FechaConsulta).HasMaxLength(8);

                entity.Property(e => e.IdentificacionBuro).HasMaxLength(4);

                entity.Property(e => e.IdentificadorOrigenConsulta).HasMaxLength(25);

                entity.Property(e => e.ImporteContrato).HasMaxLength(9);

                entity.Property(e => e.IndicadorTipoResponsabilidad).HasMaxLength(1);

                entity.Property(e => e.NombreOtorgante).HasMaxLength(16);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.PkConsultaEfectuada)
                    .HasColumnName("pk_ConsultaEfectuada")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ResultadoFinal).HasMaxLength(25);

                entity.Property(e => e.TelefonoOtorgante).HasMaxLength(11);

                entity.Property(e => e.TipoContrato).HasMaxLength(2);
            });

            modelBuilder.Entity<CnsBcCuenta>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_Cuenta");

                entity.Property(e => e.ClaveObservacion).HasMaxLength(2);

                entity.Property(e => e.ClaveOtorgante).HasMaxLength(10);

                entity.Property(e => e.ClaveUnidadMonetaria).HasMaxLength(2);

                entity.Property(e => e.CreditoMaximo).HasMaxLength(9);

                entity.Property(e => e.FechaActualizacion).HasMaxLength(8);

                entity.Property(e => e.FechaAperturaCuenta).HasMaxLength(8);

                entity.Property(e => e.FechaCierreCuenta).HasMaxLength(8);

                entity.Property(e => e.FechaHistoricaMorosidadMasGrave).HasMaxLength(8);

                entity.Property(e => e.FechaInicioReestructura).HasMaxLength(8);

                entity.Property(e => e.FechaMasAntiguaHistoricoPagos).HasMaxLength(8);

                entity.Property(e => e.FechaMasRecienteHistoricoPagos).HasMaxLength(8);

                entity.Property(e => e.FechaReporte).HasMaxLength(8);

                entity.Property(e => e.FechaUltimaCompra).HasMaxLength(8);

                entity.Property(e => e.FechaUltimoPago).HasMaxLength(8);

                entity.Property(e => e.FormaPagoActual).HasMaxLength(2);

                entity.Property(e => e.FrecuenciaPagos).HasMaxLength(1);

                entity.Property(e => e.Garantia).HasMaxLength(40);

                entity.Property(e => e.HistoricoPagos).HasMaxLength(24);

                entity.Property(e => e.IdentificadorSociedadInformacionCrediticia).HasMaxLength(11);

                entity.Property(e => e.ImporteSaldoMorosidadHistMasGrave).HasMaxLength(9);

                entity.Property(e => e.IndicadorTipoResponsabilidad).HasMaxLength(1);

                entity.Property(e => e.LimiteCredito).HasMaxLength(9);

                entity.Property(e => e.ModoReportar).HasMaxLength(1);

                entity.Property(e => e.MontoPagar).HasMaxLength(9);

                entity.Property(e => e.MontoUltimoPago).HasMaxLength(9);

                entity.Property(e => e.MopHistoricoMorosidadMasGrave).HasMaxLength(2);

                entity.Property(e => e.NombreOtorgante).HasMaxLength(16);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.NumeroCuentaActual).HasMaxLength(25);

                entity.Property(e => e.NumeroPagos).HasMaxLength(4);

                entity.Property(e => e.NumeroPagosVencidos).HasMaxLength(4);

                entity.Property(e => e.NumeroTelefonoOtorgante).HasMaxLength(11);

                entity.Property(e => e.PkCuenta)
                    .HasColumnName("pk_Cuenta")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RegistroImpugnado).HasMaxLength(4);

                entity.Property(e => e.SaldoActual).HasMaxLength(9);

                entity.Property(e => e.SaldoVencido).HasMaxLength(9);

                entity.Property(e => e.TipoContrato).HasMaxLength(2);

                entity.Property(e => e.TipoCuenta).HasMaxLength(1);

                entity.Property(e => e.TotalPagosCalificadosMop2)
                    .HasColumnName("TotalPagosCalificadosMOP2")
                    .HasMaxLength(2);

                entity.Property(e => e.TotalPagosCalificadosMop3)
                    .HasColumnName("TotalPagosCalificadosMOP3")
                    .HasMaxLength(2);

                entity.Property(e => e.TotalPagosCalificadosMop4)
                    .HasColumnName("TotalPagosCalificadosMOP4")
                    .HasMaxLength(2);

                entity.Property(e => e.TotalPagosCalificadosMop5)
                    .HasColumnName("TotalPagosCalificadosMOP5")
                    .HasMaxLength(2);

                entity.Property(e => e.TotalPagosReportados).HasMaxLength(3);

                entity.Property(e => e.UltimaFechaSaldoCero).HasMaxLength(8);

                entity.Property(e => e.ValorActivoValuacion).HasMaxLength(9);
            });

            modelBuilder.Entity<CnsBcDeclaracionConsumidor>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_DeclaracionConsumidor");

                entity.Property(e => e.DeclaracionConsumidor).HasMaxLength(1000);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.PkDeclaracionConsumidor)
                    .HasColumnName("pk_DeclaracionConsumidor")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CnsBcDomicilio>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_Domicilio");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CodPais)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ColoniaPoblacion)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DelegacionMunicipio)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.FechaReporteDireccion)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaResidencia)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IndicadorEspecialDomicilio)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroControlConsulta)
                    .HasMaxLength(99)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.PkDomicilio)
                    .HasColumnName("pk_Domicilio")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TipoDomicilio)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CnsBcEmpleo>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_Empleo");

                entity.Property(e => e.BaseSalarial)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveMoneda)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CodPais)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ColoniaPoblacion)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DelegacionMunicipio)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.FechaContratacion)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaReportoEmpleo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaUltimoDiaEmpleo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaVerificacionEmpleo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ModoVerificacion)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEmpresa)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroControlConsulta)
                    .HasMaxLength(99)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroEmpleado)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.PkEmpleo)
                    .HasColumnName("pk_Empleo")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Salario)
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CnsBcEncabezado>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_Encabezado");

                entity.Property(e => e.ClaveOtorgante)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClavePais)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveRetornoConsumidorPrincipal)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveRetornoConsumidorSecundario)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificadorBuro)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroControlConsulta)
                    .HasMaxLength(99)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroReferenciaOperador)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PkEncabezado)
                    .HasColumnName("pk_Encabezado")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CnsBcHawkAlertBd>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_HawkAlertBD");

                entity.Property(e => e.CodigoClave).HasMaxLength(3);

                entity.Property(e => e.FechaReporte).HasMaxLength(8);

                entity.Property(e => e.Mensaje).HasMaxLength(48);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.PkHawkAlertBd)
                    .HasColumnName("pk_HawkAlertBD")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TipoInstitucion).HasMaxLength(16);
            });

            modelBuilder.Entity<CnsBcHawkAlertC>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_HawkAlertC");

                entity.Property(e => e.CodigoClave).HasMaxLength(3);

                entity.Property(e => e.FechaReporte).HasMaxLength(8);

                entity.Property(e => e.Mensaje).HasMaxLength(48);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.PkHawkAlertC)
                    .HasColumnName("pk_HawkAlertC")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TipoInstitucion).HasMaxLength(16);
            });

            modelBuilder.Entity<CnsBcNombre>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_Nombre");

                entity.Property(e => e.ApellidoAdicional)
                    .HasMaxLength(26)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(26)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(26)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveImpuestosOtroPais)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveOtroPais)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.EdadesDependientes)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDefuncion)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRecepcionInformacionDependientes)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCedulaProfesional)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroControlConsulta)
                    .HasMaxLength(99)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDependientes)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroLicenciaConducir)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroRegistroElectoral)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PkNombre)
                    .HasColumnName("pk_Nombre")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Prefijo)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(26)
                    .IsUnicode(false);

                entity.Property(e => e.Residencia)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .HasColumnName("RFC")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(26)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sufijo)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                  .HasMaxLength(25)
                  .IsUnicode(false);
            });

            modelBuilder.Entity<CnsBcResumenReporte>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_ResumenReporte");

                entity.Property(e => e.CuentasCerradas).HasMaxLength(4);

                entity.Property(e => e.CuentasClavesHistoriaNegativa).HasMaxLength(4);

                entity.Property(e => e.CuentasDisputa).HasMaxLength(2);

                entity.Property(e => e.CuentasNegativasActuales).HasMaxLength(4);

                entity.Property(e => e.CuentasPagosFijosHipotecas).HasMaxLength(4);

                entity.Property(e => e.CuentasRevolventesAbiertas).HasMaxLength(4);

                entity.Property(e => e.ExistenciaDeclaracionesConsumidor).HasMaxLength(1);

                entity.Property(e => e.FechaAperturaCuentaMasAntigua).HasMaxLength(8);

                entity.Property(e => e.FechaAperturaCuentaMasReciente).HasMaxLength(8);

                entity.Property(e => e.FechaAperturaCuentaMasRecienteDespachoCobranza).HasMaxLength(8);

                entity.Property(e => e.FechaIngresoBd)
                    .HasColumnName("FechaIngresoBD")
                    .HasMaxLength(8);

                entity.Property(e => e.FechaSolicitudMasRecienteDespachoCobranza).HasMaxLength(8);

                entity.Property(e => e.FechaSolicitudReporteMasReciente).HasMaxLength(2);

                entity.Property(e => e.MensajesAlerta).HasMaxLength(8);

                entity.Property(e => e.NuevaDireccionReportadaUltimos60Dias).HasMaxLength(1);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.NumeroCuentas).HasMaxLength(4);

                entity.Property(e => e.NumeroMop0)
                    .HasColumnName("NumeroMOP0")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop1)
                    .HasColumnName("NumeroMOP1")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop2)
                    .HasColumnName("NumeroMOP2")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop3)
                    .HasColumnName("NumeroMOP3")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop4)
                    .HasColumnName("NumeroMOP4")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop5)
                    .HasColumnName("NumeroMOP5")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop6)
                    .HasColumnName("NumeroMOP6")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop7)
                    .HasColumnName("NumeroMOP7")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop96)
                    .HasColumnName("NumeroMOP96")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop97)
                    .HasColumnName("NumeroMOP97")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMop99)
                    .HasColumnName("NumeroMOP99")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroMopur)
                    .HasColumnName("NumeroMOPUR")
                    .HasMaxLength(2);

                entity.Property(e => e.NumeroSolicitudesUltimos6Meses).HasMaxLength(2);

                entity.Property(e => e.NumeroTotalCuentasDespachoCobranza).HasMaxLength(2);

                entity.Property(e => e.NumeroTotalSolicitudesDespachosCobranza).HasMaxLength(2);

                entity.Property(e => e.PctLimiteCreditoUtilizadoRevolventes).HasMaxLength(3);

                entity.Property(e => e.PkResumenReporte)
                    .HasColumnName("pk_ResumenReporte")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TipoMoneda).HasMaxLength(2);

                entity.Property(e => e.TotalCreditosMaximosPagosFijos).HasMaxLength(9);

                entity.Property(e => e.TotalCreditosMaximosRevolventes).HasMaxLength(9);

                entity.Property(e => e.TotalLimitesCreditoRevolventes).HasMaxLength(9);

                entity.Property(e => e.TotalPagosPagosFijos).HasMaxLength(9);

                entity.Property(e => e.TotalPagosRevolventes).HasMaxLength(9);

                entity.Property(e => e.TotalSaldosActualesPagosFijos).HasMaxLength(10);

                entity.Property(e => e.TotalSaldosActualesRevolventes).HasMaxLength(10);

                entity.Property(e => e.TotalSaldosVencidosPagosFijos).HasMaxLength(9);

                entity.Property(e => e.TotalSaldosVencidosRevolventes).HasMaxLength(9);

                entity.Property(e => e.TotalSolicitudesReporte).HasMaxLength(2);
            });

            modelBuilder.Entity<CnsBcScoreBc>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_ScoreBC");

                entity.Property(e => e.CodigoError).HasMaxLength(2);

                entity.Property(e => e.CodigoRazon).HasMaxLength(3);

                entity.Property(e => e.CodigoScore).HasMaxLength(3);

                entity.Property(e => e.NombreScore)
                    .HasColumnName("nombreScore")
                    .HasMaxLength(30);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.PkScoreBc)
                    .HasColumnName("pk_ScoreBC")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ValorScore).HasMaxLength(4);
            });

            modelBuilder.Entity<CnsBcUr>(entity =>
            {
                entity.HasKey(e => e.NumeroControlConsulta);

                entity.ToTable("cnsBC_UR");

                entity.Property(e => e.ErrorReporteBloqueado).HasMaxLength(1);

                entity.Property(e => e.ErrorSistemaBuroCredito).HasMaxLength(23);

                entity.Property(e => e.EtiquetaSegmentoErronea).HasMaxLength(2);

                entity.Property(e => e.FaltaCampoRequerido).HasMaxLength(24);

                entity.Property(e => e.InformacionErroneaParaConsulta).HasMaxLength(46);

                entity.Property(e => e.NumeroControlConsulta).HasMaxLength(99);

                entity.Property(e => e.NumeroErroneoSegmentos).HasMaxLength(2);

                entity.Property(e => e.NumeroReferenciaOperador).HasMaxLength(25);

                entity.Property(e => e.OrdenErroneoSegmento).HasMaxLength(4);

                entity.Property(e => e.PasswordOclaveErronea)
                    .HasColumnName("PasswordOClaveErronea")
                    .HasMaxLength(18);

                entity.Property(e => e.PkUr)
                    .HasColumnName("pk_UR")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductoSolicitadoErroneo).HasMaxLength(3);

                entity.Property(e => e.SegmentoRequeridoNoProporcionado).HasMaxLength(2);

                entity.Property(e => e.SolicitudClienteErronea).HasMaxLength(4);

                entity.Property(e => e.UltimaInformacionValidaCliente).HasMaxLength(6);

                entity.Property(e => e.ValorErroneoCampoRelacionado).HasMaxLength(92);

                entity.Property(e => e.VersionProporcionadaErronea).HasMaxLength(2);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
