using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RedSocial.Models;
using RedSocial.Utilities;
using RedSocialWebApi.Models;

namespace RedSocial.Services
{
   public class ServicioAmigos:BaseServicios<Amigos>
   {
       public ServicioAmigos(string url) : base(url)
       {
       }

       public async Task AddNuevoAmigo(NuevoAmigo na)
       {
           var serializado = Serializador.Serializar(na);

           using (var handler = new HttpClientHandler())
           {

               using (var client = new HttpClient(handler))
               {
                   var contenido = new StringContent(serializado);
                   contenido.Headers.ContentType =
                       new MediaTypeHeaderValue("application/json");

                   await client.PostAsync(new Uri(Url),
                       contenido);
               }
           }

       }
   }
}
