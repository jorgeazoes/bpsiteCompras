using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Grpc.Core;

namespace PROYCUATRO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try{
             Channel channel = new Channel("localhost:4000", ChannelCredentials.Insecure);
             /* var client = new TiempoEsperaService.TiempoEsperaServiceClient(channel);
              TiempoEspera tiempominutos = client.GetTiempoEspera(new TiempoEsperaRequest());

              //if(tiempominutos ==null || string.IsNullOrWhiteSpace(tiempominutos.Minutos.ToString()))
               // {
                    //Console.WriteLine($" Tiempo de espera " + tiempominutos.Minutos);
               // };*/
   

            }
             catch(Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
              
                
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>(); 
    }
}
