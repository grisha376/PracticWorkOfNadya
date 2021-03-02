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
    public class KlientsController : Controller
    {
        private SKLADEntities db = new SKLADEntities();

        // GET: Klients
        public ActionResult Index()
        {
            return View(db.Klients.ToList());
        }

        // GET: Klients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klients klients = db.Klients.Find(id);
            if (klients == null)
            {
                return HttpNotFound();
            }
            return View(klients);
        }

        // GET: Klients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Klients,Sername,Names,Patronymic")] Klients klients)
        {
            if (ModelState.IsValid)
            {
                db.Klients.Add(klients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klients);
        }

        // GET: Klients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klients klients = db.Klients.Find(id);
            if (klients == null)
            {
                return HttpNotFound();
            }
            return View(klients);
        }

        // POST: Klients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Klients,Sername,Names,Patronymic")] Klients klients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klients);
        }

        // GET: Klients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klients klients = db.Klients.Find(id);
            if (klients == null)
            {
                return HttpNotFound();
            }
            return View(klients);
        }

        // POST: Klients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klients klients = db.Klients.Find(id);
            db.Klients.Remove(klients);
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
