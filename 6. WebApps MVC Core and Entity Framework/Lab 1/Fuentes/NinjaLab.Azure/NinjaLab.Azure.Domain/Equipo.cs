using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NinjaLab.Azure.Domain
{
    /// <summary>
    /// Entidad que permite mapear objetualmente la tabla Equipos de la base de datos.
    /// </summary>
    public class Equipo
    {
        [Key]
        /// <summary>
        /// Obtiene o establece El identificador único del equipo.
        /// </summary>
        public int IdEquipo { get; set; }

        [Required]
        [MaxLength(200)]
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

        /// <summary>
        /// Obtiene o establece los jugadores del equipo.
        /// </summary>
        public List<Jugador> Jugadores { get; set; }
    }
}
