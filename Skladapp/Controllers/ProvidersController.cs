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
    public class ProvidersController : Controller
    {
        private SKLADEntities db = new SKLADEntities();

        // GET: Providers
        public ActionResult Index()
        {
            var providers = db.Providers.Include(p => p.Employees);
            return View(providers.ToList());
        }

        // GET: Providers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Providers providers = db.Providers.Find(id);
            if (providers == null)
            {
                return HttpNotFound();
            }
            return View(providers);
        }

        // GET: Providers/Create
        public ActionResult Create()
        {
            ViewBag.ID_Receiving_employee = new SelectList(db.Employees, "ID_Employee", "Sername");
            return View();
        }

        // POST: Providers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Provider,Dates,ID_Receiving_employee")] Providers providers)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(providers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Receiving_employee = new SelectList(db.Employees, "ID_Employee", "Sername", providers.ID_Receiving_employee);
            return View(providers);
        }

        // GET: Providers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Providers providers = db.Providers.Find(id);
            if (providers == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Receiving_employee = new SelectList(db.Employees, "ID_Employee", "Sername", providers.ID_Receiving_employee);
            return View(providers);
        }

        // POST: Providers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Provider,Dates,ID_Receiving_employee")] Providers providers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Receiving_employee = new SelectList(db.Employees, "ID_Employee", "Sername", providers.ID_Receiving_employee);
            return View(providers);
        }

        // GET: Providers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Providers providers = db.Providers.Find(id);
            if (providers == null)
            {
                return HttpNotFound();
            }
            return View(providers);
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Providers providers = db.Providers.Find(id);
            db.Providers.Remove(providers);
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
