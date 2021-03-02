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
    public class DispatchesController : Controller
    {
        private SKLADEntities db = new SKLADEntities();

        // GET: Dispatches
        public ActionResult Index()
        {
            var dispatch = db.Dispatch.Include(d => d.Employees).Include(d => d.Klients);
            return View(dispatch.ToList());
        }

        // GET: Dispatches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispatch dispatch = db.Dispatch.Find(id);
            if (dispatch == null)
            {
                return HttpNotFound();
            }
            return View(dispatch);
        }

        // GET: Dispatches/Create
        public ActionResult Create()
        {
            ViewBag.ID_employee = new SelectList(db.Employees, "ID_Employee", "Sername");
            ViewBag.ID_klients = new SelectList(db.Klients, "ID_Klients", "Sername");
            return View();
        }

        // POST: Dispatches/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_dispatch,Dates,ID_employee,ID_klients")] Dispatch dispatch)
        {
            if (ModelState.IsValid)
            {
                db.Dispatch.Add(dispatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_employee = new SelectList(db.Employees, "ID_Employee", "Sername", dispatch.ID_employee);
            ViewBag.ID_klients = new SelectList(db.Klients, "ID_Klients", "Sername", dispatch.ID_klients);
            return View(dispatch);
        }

        // GET: Dispatches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispatch dispatch = db.Dispatch.Find(id);
            if (dispatch == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_employee = new SelectList(db.Employees, "ID_Employee", "Sername", dispatch.ID_employee);
            ViewBag.ID_klients = new SelectList(db.Klients, "ID_Klients", "Sername", dispatch.ID_klients);
            return View(dispatch);
        }

        // POST: Dispatches/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_dispatch,Dates,ID_employee,ID_klients")] Dispatch dispatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_employee = new SelectList(db.Employees, "ID_Employee", "Sername", dispatch.ID_employee);
            ViewBag.ID_klients = new SelectList(db.Klients, "ID_Klients", "Sername", dispatch.ID_klients);
            return View(dispatch);
        }

        // GET: Dispatches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispatch dispatch = db.Dispatch.Find(id);
            if (dispatch == null)
            {
                return HttpNotFound();
            }
            return View(dispatch);
        }

        // POST: Dispatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dispatch dispatch = db.Dispatch.Find(id);
            db.Dispatch.Remove(dispatch);
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
