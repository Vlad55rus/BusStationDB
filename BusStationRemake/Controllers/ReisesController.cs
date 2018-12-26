using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusStationRemake;

namespace BusStationRemake.Controllers
{
    public class ReisesController : Controller
    {
        private BusStationEntities db = new BusStationEntities();

        // GET: Reises
        public ActionResult Index()
        {
            var reis = db.Reis.Include(r => r.Bus).Include(r => r.Marshrut);
            return View(reis.ToList());
        }

        // GET: Reises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reis reis = db.Reis.Find(id);
            if (reis == null)
            {
                return HttpNotFound();
            }
            return View(reis);
        }

        // GET: Reises/Create
        public ActionResult Create()
        {
            ViewBag.id_bus = new SelectList(db.Bus, "id", "registr_number");
            ViewBag.id_marshruta = new SelectList(db.Marshrut, "id", "destination");
            return View();
        }

        // POST: Reises/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_marshruta,id_bus,vremya_opravleniya,vremya_pribitiya")] Reis reis)
        {
            if (ModelState.IsValid)
            {
                db.Reis.Add(reis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_bus = new SelectList(db.Bus, "id", "registr_number", reis.id_bus);
            ViewBag.id_marshruta = new SelectList(db.Marshrut, "id", "destination", reis.id_marshruta);
            return View(reis);
        }

        // GET: Reises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reis reis = db.Reis.Find(id);
            if (reis == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_bus = new SelectList(db.Bus, "id", "registr_number", reis.id_bus);
            ViewBag.id_marshruta = new SelectList(db.Marshrut, "id", "destination", reis.id_marshruta);
            return View(reis);
        }

        // POST: Reises/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_marshruta,id_bus,vremya_opravleniya,vremya_pribitiya")] Reis reis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_bus = new SelectList(db.Bus, "id", "registr_number", reis.id_bus);
            ViewBag.id_marshruta = new SelectList(db.Marshrut, "id", "destination", reis.id_marshruta);
            return View(reis);
        }

        // GET: Reises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reis reis = db.Reis.Find(id);
            if (reis == null)
            {
                return HttpNotFound();
            }
            return View(reis);
        }

        // POST: Reises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reis reis = db.Reis.Find(id);
            db.Reis.Remove(reis);
            db.SaveChanges();
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
