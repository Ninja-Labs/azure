namespace NinjaLab.Azure.Dto
{
    /// <summary>
    /// Entidad que permite transportar los datos correspondientes a un jugador.
    /// </summary>
    public class Jugador
    {
        /// <summary>
        /// Obtiene o establece el identificador único del jugador.
        /// </summary>
        public int Id { get; set; }

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
    }
}
