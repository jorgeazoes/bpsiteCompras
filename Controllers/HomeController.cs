using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROYCUATRO.Models;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PROYCUATRO.Controllers
{
    public class HomeController : Controller
    {
      private readonly IConfiguration _configuration;
       private string pEnlace;
       private string pEmpresa;
    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
          pEnlace =  _configuration.GetValue<string>("LinkServiciogRpc");
          pEmpresa = _configuration.GetValue<string>("Empresa");
    }

         
        public IActionResult Inicio()
        { 
            Channel channel = new Channel( pEnlace, ChannelCredentials.Insecure);
             var client = new TiempoEsperaService.TiempoEsperaServiceClient(channel);
             TiempoEspera tiempominutos = client.GetTiempoEspera(new TiempoEsperaRequest());
            
         
            return View(tiempominutos);
        }

        public async Task<IActionResult> Index(string pMensajeRespuesta)
        {

         ViewBag.MensajeRespuesta = pMensajeRespuesta;
       /* Channel channel = new Channel("localhost:5000", ChannelCredentials.Insecure);
              var client = new TiempoEsperaService.TiempoEsperaServiceClient(channel);
              TiempoEspera tiempominutos = client.GetTiempoEspera(new TiempoEsperaRequest()); */

          Channel channel = new Channel(pEnlace, ChannelCredentials.Insecure);
            var clOrdenes = new OrdenesCompraService.OrdenesCompraServiceClient(channel);

            var listOrdenes = new List<OrdenesCompra>();
            var request = new GetOrdenesRequest();
            request.PcodEmpresa = pEmpresa;
            request.PcodUsuarioWindows = "PVEGA";

           try
            {
               using (var call = clOrdenes.GetOrdenes(request))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        GetOrdenesResponse Orden = call.ResponseStream.Current;                        
                        listOrdenes.Add(Orden.Ordencompra);
                   
                    }  
                      
                      //FALTA VALIDAR EL ERROR;
                }

                
            }
            catch (RpcException)
            {
                //call = null;
                throw;
            }
          return View(listOrdenes);
        }

/*public IActionResult IrDetalle(){
    return Redirect("/Home/DetalleOrden/");
}*/
      
       public async Task<IActionResult> DetalleOrden(string param1, string param2)
        {

            ViewBag.vNumOrden = param1;
            ViewBag.vNumComparativo = param2;

            Channel channel = new Channel(pEnlace, ChannelCredentials.Insecure);
            var clsAprobadores = new CListaAprobadoresService.CListaAprobadoresServiceClient(channel);
            var clsAdjuntos = new CListaAdjuntosService.CListaAdjuntosServiceClient(channel);
            var clsCotizaciones = new CCotizacionesService.CCotizacionesServiceClient(channel);
            var clsCotizacionDetalle = new CCotizacionDetalleService.CCotizacionDetalleServiceClient(channel);

            var listCotizaciones = new List<CCotizacionOrden>();
            var requestCotizaciones = new GetCCotizacionRequest();
            requestCotizaciones.PcodEmpresa = pEmpresa;
            requestCotizaciones.PcodUsuarioWindows = "PVEGA";
            requestCotizaciones.PnumComparativo = param2;

            var listAprobadores = new List<CAprobadoresOrden>();
            var request = new GetCAprobadoresRequest();
            request.PcodEmpresa = pEmpresa;
            request.PcodUsuarioWindows = "PVEGA";
            request.NumOrdenCompra = param1;

            var listAdjuntos = new List<CAdjuntosOrden>();
            var requestAdjuntos = new GetCAdjuntosRequest();
            requestAdjuntos.PcodEmpresa = pEmpresa;
            requestAdjuntos.PcodUsuarioWindows = "PVEGA";
            requestAdjuntos.NumOrdenCompra = param1;

           try
            {        

                using (var call = clsCotizaciones.GetCotizaciones(requestCotizaciones))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        GetCCotizacionResponse Cotizaciones = call.ResponseStream.Current;
                        //Console.WriteLine("NumeroOrden " + Aprobadores.CAprobador.NumOrdenCompra.ToString());
                        //Console.WriteLine("NumOrdenCompra " + Aprobadores.CAprobador.NomUsuario.ToString());
                        listCotizaciones.Add(Cotizaciones.CCotizacionOrden);
                   
                    }  
                      
                      ViewData["LCotizaciones"] = listCotizaciones;
                }       

               using (var call = clsAprobadores.GetAprobadores(request))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        GetCAprobadoresResponse Aprobadores = call.ResponseStream.Current;
                        //Console.WriteLine("NumeroOrden " + Aprobadores.CAprobador.NumOrdenCompra.ToString());
                        //Console.WriteLine("NumOrdenCompra " + Aprobadores.CAprobador.NomUsuario.ToString());
                        listAprobadores.Add(Aprobadores.CAprobador);
                   
                    }  
                      
                      ViewData["LAprobadores"] = listAprobadores;
                }

               using (var call = clsAdjuntos.GetAdjuntos(requestAdjuntos))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        GetCAdjuntosResponse Adjuntos = call.ResponseStream.Current;
                        //Console.WriteLine("NumeroOrden " + Aprobadores.CAprobador.NumOrdenCompra.ToString());
                        //Console.WriteLine("NumOrdenCompra " + Aprobadores.CAprobador.NomUsuario.ToString());
                        listAdjuntos.Add(Adjuntos.CAdjuntos);
                   
                    }  
                      
                      ViewData["LAdjuntos"] = listAdjuntos;
                } 


                //FALTA VALIDAR EL ERROR;


                
            }
            catch (RpcException)
            {
                //call = null;
                throw;
            }
          return View();
        }

       [BindProperty]
       public CResolucionModel cResolucion {get; set;}
        public IActionResult SetResolucion()
        {
            Channel channel = new Channel(pEnlace, ChannelCredentials.Insecure);
            var client = new CResolucionOrdenService.CResolucionOrdenServiceClient(channel);
           
           // return Json(cResolucion);

            var request = new PutCResolucionOrdenRequest
            {
                PcodEmpresa = pEmpresa,
                PcodUsuarioWindows = "PVEGA",
                CResolucion = new CResolucionOrden
                {
                    CodEmpresa =  "1",                    
                    NumOrdenCompra = cResolucion.num_orden_compra,
                    TipResolucion = cResolucion.tip_resolucion,
                    NumAutorizacion = cResolucion.num_autorizacion,
                    DesObservaciones = cResolucion.des_observaciones
                }

            };
            //Console.WriteLine(Json(request));           
           PutCResolucionOrdenResponse respuestaResolucion = client.PutCResolucionOrden(new PutCResolucionOrdenRequest(request));
 
       // Si la respuesta es 000000 fue exitoso se setea el mensaje
           if (respuestaResolucion.CResolucion.MensajeRepuesta == "000000"){             
              ViewBag.showSuccessAlert = "1";             
              TempData["Mensaje"] = "Proceso ejecutado con éxito!!"; 
           }
           else{
               ViewBag.showSuccessAlert = "0";              
               TempData["Mensaje"]="Error: " + respuestaResolucion.CResolucion.MensajeRepuesta.ToString();
           }

           // Se manda en la url el indicador 1 para mostrar el mensaje         
           return RedirectToAction("Index","Home", new {pMensajeRespuesta = ViewBag.showSuccessAlert});         
        }

       //[HttpPost]
        public async Task<IActionResult> GetDetalleCot(string param1, string param2)
        {
           ViewBag.vNumOrden = param2;
           ViewBag.vNumCotizacion = param1;

            Channel channel = new Channel(pEnlace, ChannelCredentials.Insecure);
            var clsCotizacionDetalle = new CCotizacionDetalleService.CCotizacionDetalleServiceClient(channel);
           
           // return Json(cResolucion);
           var listCotizacionDeta = new List<CCotizacionDeta>();
            var requestCotizacionDeta = new GetCCotizacionDetaRequest();
            requestCotizacionDeta.PcodEmpresa = pEmpresa;
            requestCotizacionDeta.PcodUsuarioWindows = "PVEGA";
            requestCotizacionDeta.PnumCotizacion = param1; //"359";
            requestCotizacionDeta.PnumCotizacionDeta = "";

            
                        //Console.WriteLine(Json(request));           
         using (var call = clsCotizacionDetalle.GetCotizacionDetalle(requestCotizacionDeta))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        GetCCotizacionDetaResponse CotizacionDetalle = call.ResponseStream.Current;
                        Console.WriteLine("CotizacionDetalle " + CotizacionDetalle.CCotizacionDetaOrden.NumCotizacionDetalle.ToString());
                        //Console.WriteLine("NumOrdenCompra " + Aprobadores.CAprobador.NomUsuario.ToString());
                        listCotizacionDeta.Add(CotizacionDetalle.CCotizacionDetaOrden);
                   
                    }  
                      
                      ViewData["LCotizacionDetalle"] = listCotizacionDeta;
                }       
      
           return View();
   
          // return Json(listCotizacionDeta);
        
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
