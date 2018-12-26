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
    public class Station_from_marshrutController : Controller
    {
        private BusStationEntities db = new BusStationEntities();

        // GET: Station_from_marshrut
        public ActionResult Index()
        {
            var station_from_marshrut = db.Station_from_marshrut.Include(s => s.Marshrut).Include(s => s.Station);
            return View(station_from_marshrut.ToList());
        }

        // GET: Station_from_marshrut/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station_from_marshrut station_from_marshrut = db.Station_from_marshrut.Find(id);
            if (station_from_marshrut == null)
            {
                return HttpNotFound();
            }
            return View(station_from_marshrut);
        }

        // GET: Station_from_marshrut/Create
        public ActionResult Create()
        {
            ViewBag.id_marshruta = new SelectList(db.Marshrut, "id", "destination");
            ViewBag.id_stancii = new SelectList(db.Station, "id", "station_name");
            return View();
        }

        // POST: Station_from_marshrut/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_stancii,id_marshruta,vremya_otpravleniya")] Station_from_marshrut station_from_marshrut)
        {
            if (ModelState.IsValid)
            {
                db.Station_from_marshrut.Add(station_from_marshrut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_marshruta = new SelectList(db.Marshrut, "id", "destination", station_from_marshrut.id_marshruta);
            ViewBag.id_stancii = new SelectList(db.Station, "id", "station_name", station_from_marshrut.id_stancii);
            return View(station_from_marshrut);
        }

        // GET: Station_from_marshrut/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station_from_marshrut station_from_marshrut = db.Station_from_marshrut.Find(id);
            if (station_from_marshrut == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_marshruta = new SelectList(db.Marshrut, "id", "destination", station_from_marshrut.id_marshruta);
            ViewBag.id_stancii = new SelectList(db.Station, "id", "station_name", station_from_marshrut.id_stancii);
            return View(station_from_marshrut);
        }

        // POST: Station_from_marshrut/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_stancii,id_marshruta,vremya_otpravleniya")] Station_from_marshrut station_from_marshrut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(station_from_marshrut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_marshruta = new SelectList(db.Marshrut, "id", "destination", station_from_marshrut.id_marshruta);
            ViewBag.id_stancii = new SelectList(db.Station, "id", "station_name", station_from_marshrut.id_stancii);
            return View(station_from_marshrut);
        }

        // GET: Station_from_marshrut/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station_from_marshrut station_from_marshrut = db.Station_from_marshrut.Find(id);
            if (station_from_marshrut == null)
            {
                return HttpNotFound();
            }
            return View(station_from_marshrut);
        }

        // POST: Station_from_marshrut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Station_from_marshrut station_from_marshrut = db.Station_from_marshrut.Find(id);
            db.Station_from_marshrut.Remove(station_from_marshrut);
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
