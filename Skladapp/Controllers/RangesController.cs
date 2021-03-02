using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Skladapp.Models;

namespace Skladapp.Controllers
{
    public class RangesController : Controller
    {
        private SKLADEntities db = new SKLADEntities();

        // GET: Ranges
        public ActionResult Index()
        {
            var ranges = db.Ranges.Include(r => r.Unit_of_measurement1);
            return View(ranges.ToList());
        }

        // GET: Ranges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ranges ranges = db.Ranges.Find(id);
            if (ranges == null)
            {
                return HttpNotFound();
            }
            return View(ranges);
        }

        // GET: Ranges/Create
        public ActionResult Create()
        {
            ViewBag.Unit_of_measurement = new SelectList(db.Unit_of_measurement, "ID_Unit_of_measurement", "Short_title");
            return View();
        }

        // POST: Ranges/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_product,Names_range,Price,Unit_of_measurement")] Ranges ranges)
        {
            if (ModelState.IsValid)
            {
                db.Ranges.Add(ranges);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Unit_of_measurement = new SelectList(db.Unit_of_measurement, "ID_Unit_of_measurement", "Short_title", ranges.Unit_of_measurement);
            return View(ranges);
        }

        // GET: Ranges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ranges ranges = db.Ranges.Find(id);
            if (ranges == null)
            {
                return HttpNotFound();
            }
            ViewBag.Unit_of_measurement = new SelectList(db.Unit_of_measurement, "ID_Unit_of_measurement", "Short_title", ranges.Unit_of_measurement);
            return View(ranges);
        }

        // POST: Ranges/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_product,Names_range,Price,Unit_of_measurement")] Ranges ranges)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ranges).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Unit_of_measurement = new SelectList(db.Unit_of_measurement, "ID_Unit_of_measurement", "Short_title", ranges.Unit_of_measurement);
            return View(ranges);
        }

        // GET: Ranges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ranges ranges = db.Ranges.Find(id);
            if (ranges == null)
            {
                return HttpNotFound();
            }
            return View(ranges);
        }

        // POST: Ranges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ranges ranges = db.Ranges.Find(id);
            db.Ranges.Remove(ranges);
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
