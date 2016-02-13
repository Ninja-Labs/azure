using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjaCamp.Soccer.Models
{

    public class Equipo
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty("Nombre", NullValueHandling = NullValueHandling.Ignore)]
        public string Nombre { get; set; }
        [JsonProperty("Apodo", NullValueHandling = NullValueHandling.Ignore)]
        public string Apodo { get; set; }
        [JsonProperty("Presidente", NullValueHandling = NullValueHandling.Ignore)]
        public string Presidente { get; set; }
        [JsonProperty("Entrenador", NullValueHandling = NullValueHandling.Ignore)]
        public string Entrenador { get; set; }
        [JsonProperty("Estadio", NullValueHandling = NullValueHandling.Ignore)]
        public string Estadio { get; set; }
    }
}