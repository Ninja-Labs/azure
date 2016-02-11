using NinjaCamp.Soccer.Models;
using NinjaCamp.Soccer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NinjaCamp.Soccer.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index()
        {
            return View();
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





        async public Task<JsonResult> GetJugadores()
        {
            JugadorService service = new JugadorService();
            return Json(await service.GetJugadors(), JsonRequestBehavior.AllowGet);
        }
        async public Task<JsonResult> GetJugador(string Id)
        {
            JugadorService service = new JugadorService();
            return Json(await service.GetJugador(Id), JsonRequestBehavior.AllowGet);
        }
        async public Task<string> UpdateJugador(Jugador entity)
        {
            JugadorService service = new JugadorService();
            return await service.AddJugador(entity) ? "registro guardado." : "Error guardando el registro.";
        }
        async public Task<string> AddJugador(Jugador entity)
        {
            JugadorService service = new JugadorService();
            return await service.AddJugador(entity) ? "registro guardado." : "Error guardando el registro.";
        }
        async public Task<string> DeleteJugador(string Id)
        {
            JugadorService service = new JugadorService();
            return await service.DeleteJugador(Id) ? "registro eliminado." : "Error eliminando el registro.";
        }





    }
}
