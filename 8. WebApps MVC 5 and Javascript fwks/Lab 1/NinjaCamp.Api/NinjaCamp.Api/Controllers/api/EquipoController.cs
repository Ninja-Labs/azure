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
    public class EquipoController : ApiController
    {
        private ninjacampsoccerEntities db = new ninjacampsoccerEntities();

        // GET: api/Equipo
        public IQueryable<Equipo> GetEquipoes()
        {
            return db.Equipoes;
        }

        // GET: api/Equipo/5
        [ResponseType(typeof(Equipo))]
        public IHttpActionResult GetEquipo(int id)
        {
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return NotFound();
            }

            return Ok(equipo);
        }

        // PUT: api/Equipo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEquipo(int id, Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipo.Id)
            {
                return BadRequest();
            }

            db.Entry(equipo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(id))
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

        // POST: api/Equipo
        [ResponseType(typeof(Equipo))]
        public IHttpActionResult PostEquipo(Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Equipoes.Add(equipo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equipo.Id }, equipo);
        }

        // DELETE: api/Equipo/5
        [ResponseType(typeof(Equipo))]
        public IHttpActionResult DeleteEquipo(int id)
        {
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return NotFound();
            }

            db.Equipoes.Remove(equipo);
            db.SaveChanges();

            return Ok(equipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipoExists(int id)
        {
            return db.Equipoes.Count(e => e.Id == id) > 0;
        }
    }
}