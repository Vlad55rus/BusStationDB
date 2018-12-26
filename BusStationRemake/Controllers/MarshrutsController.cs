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
    public class MarshrutsController : Controller
    {
        private BusStationEntities db = new BusStationEntities();

        // GET: Marshruts
        public ActionResult Index()
        {
            return View(db.Marshrut.ToList());
        }

        // GET: Marshruts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marshrut marshrut = db.Marshrut.Find(id);
            if (marshrut == null)
            {
                return HttpNotFound();
            }
            return View(marshrut);
        }

        // GET: Marshruts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marshruts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bilet_price,destination")] Marshrut marshrut)
        {
            if (ModelState.IsValid)
            {
                db.Marshrut.Add(marshrut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marshrut);
        }

        // GET: Marshruts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marshrut marshrut = db.Marshrut.Find(id);
            if (marshrut == null)
            {
                return HttpNotFound();
            }
            return View(marshrut);
        }

        // POST: Marshruts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bilet_price,destination")] Marshrut marshrut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marshrut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marshrut);
        }

        // GET: Marshruts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marshrut marshrut = db.Marshrut.Find(id);
            if (marshrut == null)
            {
                return HttpNotFound();
            }
            return View(marshrut);
        }

        // POST: Marshruts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marshrut marshrut = db.Marshrut.Find(id);
            db.Marshrut.Remove(marshrut);
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
