using Microsoft.AspNetCore.Mvc;
using PROYCUATRO.Models;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROYCUATRO.ViewComponents
{
    public class CotizaciondViewComponent : ViewComponent
    {
       private readonly IConfiguration _configuration;
       private string pEnlace;
       private string pEmpresa;
        public CotizaciondViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
            pEnlace =  _configuration.GetValue<string>("LinkServiciogRpc");
            pEmpresa = _configuration.GetValue<string>("Empresa");
        }

          public async Task<IViewComponentResult> InvokeAsync(string param1, string param2)
        {

            ViewBag.vNumCotizacion = param1;
            //ViewBag.vNumCotizacionDeta = param2;

            Channel channel = new Channel(pEnlace, ChannelCredentials.Insecure);           
            var clsCotizacionDetalle = new CCotizacionDetalleService.CCotizacionDetalleServiceClient(channel);

            var listCotizacionDeta = new List<CCotizacionDeta>();
            var requestCotizacionDeta = new GetCCotizacionDetaRequest();
            requestCotizacionDeta.PcodEmpresa = pEmpresa;
            requestCotizacionDeta.PcodUsuarioWindows = "PVEGA";
            requestCotizacionDeta.PnumCotizacion = param1;//"359";
            requestCotizacionDeta.PnumCotizacionDeta = param2;//"1";

           try
            {        

                using (var call = clsCotizacionDetalle.GetCotizacionDetalle(requestCotizacionDeta))
                {
                    while (await call.ResponseStream.MoveNext().ConfigureAwait(false))
                    {
                        GetCCotizacionDetaResponse CotizacionDeta = call.ResponseStream.Current;
                        //Console.WriteLine("NumeroOrden " + Aprobadores.CAprobador.NumOrdenCompra.ToString());
                        //Console.WriteLine("NumOrdenCompra " + Aprobadores.CAprobador.NomUsuario.ToString());
                        listCotizacionDeta.Add(CotizacionDeta.CCotizacionDetaOrden);
                   
                    }  
                      
                      ViewData["LCotizacionDeta"] = listCotizacionDeta;
                }       

                //FALTA VALIDAR EL ERROR;
                
            }
            catch (RpcException)
            {
                //call = null;
                throw;
            }
          return View(listCotizacionDeta);
        }


    }
}