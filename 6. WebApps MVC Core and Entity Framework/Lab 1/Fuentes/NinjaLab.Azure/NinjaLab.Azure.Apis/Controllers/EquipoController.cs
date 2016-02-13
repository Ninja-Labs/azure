using AutoMapper;
using NinjaLab.Azure.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace NinjaLab.Azure.Apis.Controllers
{
    public class EquipoController : ApiController
    {
        /// <summary>
        /// Permite obtener los equipos existentes.
        /// </summary>
        /// <returns>Listado de equipos.</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<NinjaLab.Azure.Dto.Equipo>))]
        public IHttpActionResult ObtenerEquipos()
        {
            var contexto = new FutbolModel();
            var equipos = from c in contexto.Equipos
                          select new NinjaLab.Azure.Dto.Equipo
                          {
                              Id = c.IdEquipo,
                              Nombre = c.Nombre,
                              Apodo = c.Apodo,
                              Entrenador = c.Entrenador,
                              Estadio = c.Estadio,
                              Presidente = c.Presidente
                          };
            return Ok(equipos.ToList());
        }

        /// <summary>
        /// Permite obtener un equipo en específico a través de su Id.
        /// </summary>
        /// <param name="id">Id del equipo.</param>
        /// <returns>Equipo.</returns>
        [HttpGet]
        [ResponseType(typeof(NinjaLab.Azure.Dto.Equipo))]
        public IHttpActionResult ObtenerEquipo(int id)
        {
            using (var contexto = new FutbolModel())
            {
                var equipo = contexto.Equipos.FirstOrDefault(c => c.IdEquipo == id);
                return Ok(equipo);
            }
        }

        /// <summary>
        /// Permite agregar un nuevo equipo.
        /// </summary>
        /// <param name="equipo">Equipo a ingresar.</param>
        [HttpPost]
        public void AgregarEquipo([FromBody]NinjaLab.Azure.Dto.Equipo equipo)
        {
            using (var contexto = new FutbolModel())
            {
                var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<NinjaLab.Azure.Dto.Equipo, Equipo>());
                var mapper = mapperConfig.CreateMapper();
                var equipoBd = mapper.Map<Equipo>(equipo);

                contexto.Equipos.Add(equipoBd);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Permite actualizar un equipo existente.
        /// </summary>
        /// <param name="equipo">Equipo a actualizar.</param>
        [HttpPut]
        public void ActualizarEquipo([FromBody]NinjaLab.Azure.Dto.Equipo equipo)
        {
            var contexto = new FutbolModel();
            var equipoBd = contexto.Equipos.FirstOrDefault(c => c.IdEquipo == equipo.Id);

            if (equipoBd != null)
            {
                equipoBd.Nombre = equipo.Nombre;
                equipoBd.Apodo = equipo.Apodo;
                equipoBd.Entrenador = equipo.Entrenador;
                equipoBd.Estadio = equipo.Estadio;
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Permite eliminar un equipo existente.
        /// </summary>
        /// <param name="id">Id del equipo a eliminar.</param>
        [HttpDelete]
        public void EliminarEquipo(int id)
        {
            using (var contexto = new FutbolModel())
            {
                var equipoBd = contexto.Equipos.FirstOrDefault(c => c.IdEquipo == id);
                contexto.Equipos.Remove(equipoBd);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Permite obtener todos los jugadores que pertenecen a un equipo en específico.
        /// </summary>
        /// <param name="idEquipo">Id del equipo.</param>
        /// <returns>Listado de jugadores.</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<NinjaLab.Azure.Dto.Jugador>))]
        [Route("Api/ObtenerJugadoresEquipo/{idEquipo}")]
        public IHttpActionResult ObtenerJugadoresEquipo(int idEquipo)
        {
            var contexto = new FutbolModel();
            var jugadores = from c in contexto.Equipos
                            join d in contexto.Jugadores on c.IdEquipo equals d.IdEquipo
                            where c.IdEquipo == idEquipo
                            select new NinjaLab.Azure.Dto.Jugador
                            {
                                Id = d.IdJugador,
                                Nombre = d.Nombre,
                                Apodo = d.Apodo,
                                Estatura = d.Estatura,
                                Nacionalidad = d.Nacionalidad,
                                Peso = d.Peso,
                                Posicion = d.Posicion
                            };
            return Ok(jugadores);
        }
    }
}
