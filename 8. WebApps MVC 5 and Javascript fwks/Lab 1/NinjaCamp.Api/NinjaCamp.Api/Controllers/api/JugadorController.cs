using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NinjaCamp.Api.Models;

namespace NinjaCamp.Api.Controllers.api
{
    public class JugadorController : ApiController
    {
        private ninjacampsoccerEntities db = new ninjacampsoccerEntities();

        // GET: api/Jugador
        public IQueryable<Jugador> GetJugadors()
        {
            return db.Jugadors;
        }

        // GET: api/Jugador/5
        [ResponseType(typeof(Jugador))]
        public IHttpActionResult GetJugador(int id)
        {
            Jugador jugador = db.Jugadors.Find(id);
            if (jugador == null)
            {
                return NotFound();
            }

            return Ok(jugador);
        }

        // PUT: api/Jugador/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJugador(int id, Jugador jugador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jugador.Id)
            {
                return BadRequest();
            }

            db.Entry(jugador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JugadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Jugador
        [ResponseType(typeof(Jugador))]
        public IHttpActionResult PostJugador(Jugador jugador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jugadors.Add(jugador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jugador.Id }, jugador);
        }

        // DELETE: api/Jugador/5
        [ResponseType(typeof(Jugador))]
        public IHttpActionResult DeleteJugador(int id)
        {
            Jugador jugador = db.Jugadors.Find(id);
            if (jugador == null)
            {
                return NotFound();
            }

            db.Jugadors.Remove(jugador);
            db.SaveChanges();

            return Ok(jugador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JugadorExists(int id)
        {
            return db.Jugadors.Count(e => e.Id == id) > 0;
        }
    }
}