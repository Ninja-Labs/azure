namespace NinjaLab.Azure.Domain
{
    /// <summary>
    /// Entidad que permite mapear objetualmente la tabla Jugadores de la base de datos.
    /// </summary>
    public class Jugador
    {
        /// <summary>
        /// Obtiene o establece el identificador único del jugador.
        /// </summary>
        public int IdJugador { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del jugador.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apodo del jugador.
        /// </summary>
        public string Apodo { get; set; }

        /// <summary>
        /// Obtiene o establece la nacionalidad del jugador.
        /// </summary>
        public string Nacionalidad { get; set; }

        /// <summary>
        /// Obtiene o establece la estatura del jugador.
        /// </summary>
        public decimal Estatura { get; set; }

        /// <summary>
        /// Obtiene o establece el peso del jugador.
        /// </summary>
        public int Peso { get; set; }

        /// <summary>
        /// Obtiene o establece la posición en la cancha del jugador (Delantero, Defensa, etc)
        /// </summary>
        public string Posicion { get; set; }

        /// <summary>
        /// Obtiene o establece el Id del equipo al cual pertenece el jugador.
        /// </summary>
        public int IdEquipo { get; set; }

        /// <summary>
        /// Obtiene o establece el equipo al cual pertenece el jugador.
        /// </summary>
        public Equipo Equipo { get; set; }
    }
}
