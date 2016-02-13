using Newtonsoft.Json;
using NinjaCamp.Soccer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NinjaCamp.Soccer.Services
{
    public class JugadorService
    {
        private HttpClient _cliente;
        private string _serviceUri;
        public JugadorService()
        {
            _cliente = new HttpClient();
            _serviceUri = "http://ninjacampapi20160213101731.azurewebsites.net/api";
        }

        public async Task<bool> AddJugador(Jugador Jugador)
        {
            var addJugador = JsonConvert.SerializeObject(Jugador);
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format("{0}/Jugador", _serviceUri))
            {
                Content = new StringContent(addJugador, Encoding.UTF8, "application/json")
            };
            var data = await _cliente.SendAsync(request);
            return data.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<Jugador>> GetJugadores()
        {
            var Jugadores = await _cliente.GetStringAsync(string.Format("{0}/Jugador", _serviceUri));
            return JsonConvert.DeserializeObject<IEnumerable<Jugador>>(Jugadores);
        }
        public async Task<Jugador> GetJugador(string id)
        {
            var Jugador = await _cliente.GetStringAsync(string.Format("{0}/Jugador/{1}", _serviceUri, id));
            return JsonConvert.DeserializeObject<Jugador>(Jugador);
        }

        public async Task<bool> UpdateJugador(Jugador Jugador)
        {
            var updateJugador = JsonConvert.SerializeObject(Jugador);
            var patch = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(patch, string.Format("{0}/Jugador/{1}", _serviceUri, Jugador.Id))
            {
                Content = new StringContent(updateJugador, Encoding.UTF8, "application/json")
            };
            var data = await _cliente.SendAsync(request);
            return data.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteJugador(string id)
        {
            var data = await _cliente.DeleteAsync(string.Format("{0}/Jugador/{1}", _serviceUri, id));
            return data.IsSuccessStatusCode;
        }
    }
}