using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NinjaLab.Redis.Models;
using NinjaLab.Redis.Helpers;

namespace NinjaLab.Redis.Controllers
{
    public class EventsController : Controller
    {
        private NinjaLabRedisContext db = new NinjaLabRedisContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = RedisHelper.GetAll();
            if (events.Count <= 0)
            {
                events = db.Events.ToList();
            }
            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = RedisHelper.Get(id.ToString());
            if (@event == null)
            {
                @event = db.Events.Find(id);
                if (@event == null)
                {
                    return HttpNotFound();
                }
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Comment,Date")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.Id = Guid.NewGuid();
                db.Events.Add(@event);
                db.SaveChanges();
                RedisHelper.Set(@event);
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = RedisHelper.Get(id.ToString());
            if (@event == null)
            {
                @event = db.Events.Find(id);
                if (@event == null)
                {
                    return HttpNotFound();
                }
            }

            return View(@event);
        }

        // POST: Events/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Comment,Date")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                RedisHelper.Set(@event);
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = RedisHelper.Get(id.ToString());
            if (@event == null)
            {
                @event = db.Events.Find(id);
                if (@event == null)
                {
                    return HttpNotFound();
                }
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            RedisHelper.Remove(id.ToString());
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
