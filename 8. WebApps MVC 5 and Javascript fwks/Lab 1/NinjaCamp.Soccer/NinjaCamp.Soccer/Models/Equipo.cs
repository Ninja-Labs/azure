using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjaCamp.Soccer.Models
{
    /// <summary>
    /// Entidad que permite transportar los datos correspondientes a un equipo.
    /// </summary>
    public class Equipo
    {
        /// <summary>
        /// Obtiene o establece El identificador único del equipo.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre del equipo.
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Obtiene o establece el apodo del equipo ej: merengues, catalanes, diablos rojos, etc.
        /// </summary>
        public string Apodo { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre del presidente del equipo.
        /// </summary>
        public string Presidente { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre del entrenador del equipo.
        /// </summary>
        public string Entrenador { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre del estadio del equipo.
        /// </summary>
        public string Estadio { get; set; }
    }
}