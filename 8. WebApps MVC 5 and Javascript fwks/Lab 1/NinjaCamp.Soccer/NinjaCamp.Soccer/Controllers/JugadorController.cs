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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateEdit()
        {
            return View();
        }
        async public Task<JsonResult> GetJugadores()
        {
            JugadorService service = new JugadorService();
            return Json(await service.GetJugadores(), JsonRequestBehavior.AllowGet);
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
