using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjaCamp.Soccer.Models
{
 
    public class Jugador
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty("Nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string Nombre { get; set; }
        [JsonProperty("Apodo", NullValueHandling = NullValueHandling.Ignore)]
        public string Apodo { get; set; }
        [JsonProperty("Nacionalidad", NullValueHandling = NullValueHandling.Ignore)]
        public string Nacionalidad { get; set; }
        [JsonProperty("Estatura", NullValueHandling = NullValueHandling.Ignore)]
        public double Estatura { get; set; }
        [JsonProperty("Peso", NullValueHandling = NullValueHandling.Ignore)]
        public int Peso { get; set; }
        [JsonProperty("Posicion", NullValueHandling = NullValueHandling.Ignore)]
        public string Posicion { get; set; }
        [JsonProperty("IdEquipo", NullValueHandling = NullValueHandling.Ignore)]
        public int IdEquipo { get; set; }
    }
}