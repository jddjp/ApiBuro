using ApiBuro.Models;
using ApiBuro.Models.DataEntrada;
using ApiBuro.Models.InfoBcFiltro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
//using ServiceReference1;//preproduccion
using ServiceBuro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ApiBuro.Controllerspost
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaXmlBcController : ControllerBase
    {
        private readonly ApiSICContext _context;
        public ConsultaXmlBcController(ApiSICContext context)
        {
            _context = context;
        }
        public WSConsultaDelegateClient wsbc = new WSConsultaDelegateClient();
        AutenticacionBC BC = new AutenticacionBC
        {
            TipoReporte = "",
            TipoSalidaAU = "",
            ReferenciaOperador = "",
            TarjetaCredito = "",
            UltimosCuatroDigitos = "",
            EjercidoCreditoAutomotriz = "",
            EjercidoCreditoHipotecario = ""

        };

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CnsBcHawkAlertC>>> GetNombres()
        {
            return await _context.CnsBcHawkAlertC.ToListAsync();
        }


        [HttpGet("{pkNombre}")]
        public async Task<ActionResult<CnsBcNombre>> GetCnsBcNombre(int? pkNombre)
        {
            var cnsBcNombre = await _context.CnsBcNombre.FindAsync(pkNombre);

            if (cnsBcNombre == null)
            {
                return NotFound();
            }

            return cnsBcNombre;
        }

        [HttpPost]
        public  ActionResult Post(ConsultaBc item)
        {
            
                EncabezadoBC encabezado = new EncabezadoBC
                {
                    Version =item.Version,
                    NumeroReferenciaOperador =item.NumeroReferenciaOperador,
                    ProductoRequerido =item.ProductoRequerido,
                    ClavePais =item.ClavePais,
                    IdentificadorBuro = item.IdentificadorBuro,
                    ClaveUsuario = item.ClaveUsuario,
                    Password =item.Password ,
                    TipoConsulta =item.TipoConsulta ,
                    TipoContrato =item.TipoContrato,
                    ClaveUnidadMonetaria = item.ClaveUnidadMonetaria,
                    Idioma = item.Idioma,
                    TipoSalida =item.TipoSalida 
                //    Version = DatosEncabezado(item.Ambiente).ElementAt(0).Version,
                //    NumeroReferenciaOperador = DatosEncabezado(item.Ambiente).ElementAt(0).NumeroReferenciaOperador,
                //    ProductoRequerido = DatosEncabezado(item.Ambiente).ElementAt(0).ProductoRequerido,
                //    ClavePais = DatosEncabezado(item.Ambiente).ElementAt(0).ClavePais,
                //    IdentificadorBuro = DatosEncabezado(item.Ambiente).ElementAt(0).IdentificadorBuro,
                //    ClaveUsuario = DatosEncabezado(item.Ambiente).ElementAt(0).ClaveUsuario,
                //    Password = DatosEncabezado(item.Ambiente).ElementAt(0).Password,
                //    TipoConsulta = DatosEncabezado(item.Ambiente).ElementAt(0).Tipoconsulta,
                //    TipoContrato = DatosEncabezado(item.Ambiente).ElementAt(0).TipoContrato,
                //    ClaveUnidadMonetaria = DatosEncabezado(item.Ambiente).ElementAt(0).ClaveUnidadMonetaria,
                //    Idioma = DatosEncabezado(item.Ambiente).ElementAt(0).Idioma,
                //    TipoSalida = DatosEncabezado(item.Ambiente).ElementAt(0).TipoSalida
                };
                NombreBC nombreconsulta = new NombreBC
                {
                    ApellidoPaterno = item.ApellidoPaterno,
                    ApellidoMaterno = item.ApellidoMaterno,
                    PrimerNombre = item.PrimerNombre,
                    SegundoNombre = item.SegundoNombre,
                    RFC = item.RFC,
                };
                Direccion direccio = new Direccion
                {
                    Direccion1 = item.Direccion1,
                    //ColoniaPoblacion = item.ColoniaPoblacion,
                    Ciudad = item.Ciudad,
                    Estado = item.Estado,
                    CP = item.CP,
                };
                Direccion[] dir = new Direccion[1];
                dir[0] = direccio;
                EmpleoBC[] emp = new EmpleoBC[]{

                };
                PersonaBC personaunicaconsultar = new PersonaBC
                {
                    Encabezado = encabezado,
                    Nombre = nombreconsulta,
                    Domicilios = dir,
                    Empleos = emp

                };
                PersonasBC personaconsulta = new PersonasBC
                {
                    Persona = personaunicaconsultar,
                };

            
                ConsultaBC CBC = new ConsultaBC
                {
                    Personas = personaconsulta
                };
          
            //Ejecutar metodo de consulta de BD si existe o no existe 0 es no y 1 es si existe
            var outputInfo = new object();//variable comprobacion nos trae la informacion
            if (ConsultaBD(item.RFC).Count !=0)
            {
                outputInfo = TraerBusqueda(ConsultaBD(item.RFC).ElementAt(0).NumeroControlConsulta,Convert.ToBoolean(item.Nombres), Convert.ToBoolean(item.Cuentas), Convert.ToBoolean(item.Score),Convert.ToBoolean(item.ResumenReporte));
                return StatusCode(200, outputInfo);
            }else
            {
                var resultadoConsultaBuro = resultado(CBC);
                if (resultadoConsultaBuro.ElementAt(0).Encabezado == null)
                {
                    return StatusCode(203, (resultado(CBC)));
                }
                //Retorna un codigo de respuesta cuando se almacene correctamente la consulta en buro 
                var CodigoRespuestaBuro = guardarenlabd(resultadoConsultaBuro,DescargaDocumentos(CBC));

                outputInfo = TraerBusqueda(CodigoRespuestaBuro.ElementAt(0).CodigoRespuesta.ToString(), Convert.ToBoolean(item.Nombres), Convert.ToBoolean(item.Cuentas), Convert.ToBoolean(item.Score), Convert.ToBoolean(item.ResumenReporte));
                    return StatusCode(201, outputInfo);

            }

        }

       // Metodo para consultar al WS Buro 
        public PersonaRespBC[]  resultado(ConsultaBC CBC)
        {  var DatosConsultaBuro = wsbc.consultaXMLAsync(CBC).Result;
            var result = DatosConsultaBuro.@return.Personas;
            return result;
        }
        // Metodo para consultar al WS Buro DevuelveDocumentos
        public String DescargaDocumentos(ConsultaBC CBC)
        { var DatosConsultaBuro = wsbc.consultaPDFAsync(CBC).Result;
            if (DatosConsultaBuro == null) 
            {
                return "no hay documento";
            }
           
            SaveImage(DatosConsultaBuro.@return.Reporte,"ConsultaBuro"+CBC.Personas.Persona.Nombre.PrimerNombre+CBC.Personas.Persona.Nombre.ApellidoPaterno);
            return Convert.ToBase64String(DatosConsultaBuro.@return.Reporte);
           
        }
        //Metodo AlmacenarDocumentoReporteBuro
        public void SaveImage(byte[] DocumentoConsulta,String NombreTitularConsulta) 
        {
            if (DocumentoConsulta != null)
            {
                //Nombre del Documento:NombreTitularConsulta
                //Generar un documento en la ubicacion
                string filepath = "C:\\Users\\Desarrollo\\Pictures\\DocsConsultaBuro\\" + NombreTitularConsulta + ".pdf";
                var bytess = DocumentoConsulta;
                using (var imageFile = new FileStream(filepath, FileMode.Create))
                {
                    imageFile.Write(bytess, 0, bytess.Length);
                    imageFile.Flush();
                }
            }
            
        }
        //Metodo que me devuelve una lista con un Codigo de respuesta que se guardo la consulta en la bd
        public  List<CodigoRespuestaBD> guardarenlabd(PersonaRespBC[] result,String doc)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(result);
            var valorJSON = new SqlParameter("@JsonRespuesta",jsonData);
            var Documentoreporte = new SqlParameter("@Documentoreporte", doc);
            var datos = _context.CodigoRespuestaBD.FromSqlRaw<CodigoRespuestaBD>("EXEC [dbo].[cnsBC_GuardaRespuestaBCJSD] @JsonRespuesta,@Documentoreporte",
               valorJSON,Documentoreporte).ToList();
            return datos;
        }

        //Metodo de busqueda de Reporte si existe o no existe
        public List<BuscarBCRFC> ConsultaBD(String RFC)
        { var rfc = new SqlParameter("@rfc", RFC);
            var DatosBusqueda = _context.BuscarBCRFC.FromSqlRaw<BuscarBCRFC>("EXEC [dbo].[BuscarCB] @rfc", rfc).ToList();
            return DatosBusqueda;
        }
        //Lista de Informacion:
        //Retorna Listas Filtradas por el Numero de Control de la consulta
        public List<CuentaSP> resultadoCuenta(String numeroControlConsulta)
        {
            var DatoFiltro = new SqlParameter("@numeroControlConsulta", numeroControlConsulta);
            var DataInfo = _context.CuentaSP.FromSqlRaw<CuentaSP>("EXEC DataFiltroCuentasBc @numeroControlConsulta",DatoFiltro).ToList();
            _context.SaveChanges();
            return DataInfo;
        }
        public List<CnsBcNombre>resultadoNombre(String numeroControlConsulta)
        {
            //var DataInfo = _context.CnsBcNombre.FromSqlRaw<CnsBcNombre>("select * from cnsBC_Nombre where NumeroControlConsulta='" + numeroControlConsulta + "'").ToList();
            var DatoFiltro = new SqlParameter("@numeroControlConsulta", numeroControlConsulta);
            var DataInfo = _context.CnsBcNombre.FromSqlRaw<CnsBcNombre>("EXEC ExtraeNombreconFecha @numeroControlConsulta", DatoFiltro).ToList();

            _context.SaveChanges();
            return DataInfo;
        }
        public List<CnsBcResumenReporte> resultadoResumenReporte(String numeroControlConsulta)
        {
            var DataInfo = _context.CnsBcResumenReporte.FromSqlRaw<CnsBcResumenReporte>("select * from cnsBC_ResumenReporte where NumeroControlConsulta='" + numeroControlConsulta + "'").ToList();
            _context.SaveChanges();
            return DataInfo;
        }
        public List<CnsBcScoreBc> resultadoScoreBc(String numeroControlConsulta)
        {
            var DataInfo = _context.CnsBcScoreBc.FromSqlRaw<CnsBcScoreBc>("select * from cnsBC_ScoreBC where NumeroControlConsulta='" + numeroControlConsulta + "'").ToList();
            _context.SaveChanges();
            return DataInfo;
        }

        public List<CnsBcEncabezado> resultadoEncabezado(String numeroControlConsulta) 
        {
            var DataInfo = _context.CnsBcEncabezado.FromSqlRaw<CnsBcEncabezado>("select * from cnsBC_Encabezado where NumeroControlConsulta='" + numeroControlConsulta + "'").ToList();
            _context.SaveChanges();
            return DataInfo;
        }

        //public List<EncabezadoConsultaBC> DatosEncabezado(int? AmbienteCionsultar)
        //{
        //    var Ambiente = new SqlParameter("@ambiente",AmbienteCionsultar);
        //    var BuscarCredenciales = _context.EncabezadoConsultaBC.FromSqlRaw<EncabezadoConsultaBC>("EXEC [dbo].[DataConsultaCredenciales] @ambiente", Ambiente).ToList();
        //    _context.SaveChanges();
        //    return BuscarCredenciales;
        //}

        //Metodo que regresa la informacion
        public object TraerBusqueda(String numeroControlConsulta,Boolean Nombres, Boolean Cuentas, Boolean Score, Boolean ResumenReporte)
        {
        //Objeto de respuesta de informacion de Buro
         var respuesta = new CnsInfoBuro();
            if (Nombres == true)
            { 
                respuesta.CnsBcNombre = resultadoNombre(numeroControlConsulta);

               
            }
            if (Cuentas == true)
            {
                respuesta.CnsBcCuenta = resultadoCuenta(numeroControlConsulta);
            }
            if (Score == true)
            {
                respuesta.CnsBcScoreBc = resultadoScoreBc(numeroControlConsulta);
            }
            if (ResumenReporte==true) 
            {
               respuesta.CnsBcResumenReporte = resultadoResumenReporte(numeroControlConsulta);
            }


        
            return respuesta;
        }

    }
    



}