using MvcSegundoExamen.Models;
using System.Net.Http.Headers;

namespace MvcSegundoExamen.Services
{
    public class ServiceApiEventos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceApiEventos(KeysModel keys)
        {
            this.UrlApi = keys.UrlApi;
            this.header = new MediaTypeWithQualityHeaderValue
                ("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "/eventos";
            List<Evento> data = await this.CallApiAsync<List<Evento>>(request);
            return data;
        }        
        public async Task<List<CategoriaEvento>> GetCategoriasAsync()
        {
            string request = "/categorias";
            List<CategoriaEvento> data = await this.CallApiAsync<List<CategoriaEvento>>(request);
            return data;
        }        
        public async Task<List<Evento>> FindEventosByCatAsync(int idEvento)
        {
            string request = "/eventos/"+idEvento;
            List<Evento> data = await this.CallApiAsync<List<Evento>>(request);
            return data;
        }
    }
}
