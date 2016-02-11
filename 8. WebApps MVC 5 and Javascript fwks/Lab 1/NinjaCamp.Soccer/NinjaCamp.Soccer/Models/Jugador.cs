using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjaCamp.Soccer.Models
{
 
    public class Jugador
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [JsonProperty("Apodo")]
        public string Apodo { get; set; }
        [JsonProperty("Nacionalidad")]
        public string Nacionalidad { get; set; }
        [JsonProperty("Estatura")]
        public double Estatura { get; set; }
        [JsonProperty("Peso")]
        public int Peso { get; set; }
        [JsonProperty("Posicion")]
        public string Posicion { get; set; }
        [JsonProperty("IdEquipo")]
        public int IdEquipo { get; set; }
    }
}