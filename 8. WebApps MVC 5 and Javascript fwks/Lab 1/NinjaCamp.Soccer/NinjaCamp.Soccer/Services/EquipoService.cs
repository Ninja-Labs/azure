using Newtonsoft.Json;
using NinjaCamp.Soccer.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace NinjaCamp.Soccer.Services
{
    public class EquipoService
    {
        private HttpClient _cliente;
        private string _serviceUri;

        public EquipoService()
        {
            _cliente = new HttpClient();
            _serviceUri = "http://ninjacampapi20160213101731.azurewebsites.net/api";
        }

        public async Task<bool> AddEquipo(Equipo equipo)
        {
            var addEquipo = JsonConvert.SerializeObject(equipo);
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format("{0}/Equipo", _serviceUri))
            {
                Content = new StringContent(addEquipo, Encoding.UTF8, "application/json")
            };
            var data = await _cliente.SendAsync(request);
            return data.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<Equipo>> GetEquipos()
        {
            var equipos = await _cliente.GetStringAsync(string.Format("{0}/Equipo", _serviceUri));
            return JsonConvert.DeserializeObject<IEnumerable<Equipo>>(equipos);
        }
        public async Task<Equipo> GetEquipo(string id)
        {
            var equipo = await _cliente.GetStringAsync(string.Format("{0}/Equipo/{1}", _serviceUri, id));
            return JsonConvert.DeserializeObject<Equipo>(equipo);
        }

        public async Task<bool> UpdateEquipo(Equipo equipo)
        {
            var updateEquipo = JsonConvert.SerializeObject(equipo);
            var patch = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(patch, string.Format("{0}/Equipo/{1}", _serviceUri, equipo.Id))
            {
                Content = new StringContent(updateEquipo, Encoding.UTF8, "application/json")
            };
            var data = await _cliente.SendAsync(request);
            return data.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteEquipo(string id)
        {
            var data = await _cliente.DeleteAsync(string.Format("{0}/Equipo/{1}", _serviceUri, id));
            return data.IsSuccessStatusCode;
        }
    }
}