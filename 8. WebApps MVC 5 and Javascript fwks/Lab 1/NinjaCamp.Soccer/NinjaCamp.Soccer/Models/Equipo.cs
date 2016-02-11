using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjaCamp.Soccer.Models
{

    public class Equipo
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }
        [JsonProperty("Apodo")]
        public string Apodo { get; set; }
        [JsonProperty("Presidente")]
        public string Presidente { get; set; }
        [JsonProperty("Entrenador")]
        public string Entrenador { get; set; }
        [JsonProperty("Estadio")]
        public string Estadio { get; set; }
    }
}