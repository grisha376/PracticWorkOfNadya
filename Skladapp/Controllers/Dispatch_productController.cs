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
    public class Dispatch_productController : Controller
    {
        private SKLADEntities db = new SKLADEntities();

        // GET: Dispatch_product
        public ActionResult Index()
        {
            var dispatch_product = db.Dispatch_product.Include(d => d.Dispatch).Include(d => d.Ranges);
            return View(dispatch_product.ToList());
        }

        // GET: Dispatch_product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispatch_product dispatch_product = db.Dispatch_product.Find(id);
            if (dispatch_product == null)
            {
                return HttpNotFound();
            }
            return View(dispatch_product);
        }

        // GET: Dispatch_product/Create
        public ActionResult Create()
        {
            ViewBag.ID_dispatch = new SelectList(db.Dispatch, "ID_dispatch", "ID_dispatch");
            ViewBag.ID_product = new SelectList(db.Ranges, "ID_product", "Names_range");
            return View();
        }

        // POST: Dispatch_product/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_dispatch,quantity,ID_product")] Dispatch_product dispatch_product)
        {
            if (ModelState.IsValid)
            {
                db.Dispatch_product.Add(dispatch_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_dispatch = new SelectList(db.Dispatch, "ID_dispatch", "ID_dispatch", dispatch_product.ID_dispatch);
            ViewBag.ID_product = new SelectList(db.Ranges, "ID_product", "Names_range", dispatch_product.ID_product);
            return View(dispatch_product);
        }

        // GET: Dispatch_product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispatch_product dispatch_product = db.Dispatch_product.Find(id);
            if (dispatch_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_dispatch = new SelectList(db.Dispatch, "ID_dispatch", "ID_dispatch", dispatch_product.ID_dispatch);
            ViewBag.ID_product = new SelectList(db.Ranges, "ID_product", "Names_range", dispatch_product.ID_product);
            return View(dispatch_product);
        }

        // POST: Dispatch_product/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_dispatch,quantity,ID_product")] Dispatch_product dispatch_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispatch_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_dispatch = new SelectList(db.Dispatch, "ID_dispatch", "ID_dispatch", dispatch_product.ID_dispatch);
            ViewBag.ID_product = new SelectList(db.Ranges, "ID_product", "Names_range", dispatch_product.ID_product);
            return View(dispatch_product);
        }

        // GET: Dispatch_product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispatch_product dispatch_product = db.Dispatch_product.Find(id);
            if (dispatch_product == null)
            {
                return HttpNotFound();
            }
            return View(dispatch_product);
        }

        // POST: Dispatch_product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dispatch_product dispatch_product = db.Dispatch_product.Find(id);
            db.Dispatch_product.Remove(dispatch_product);
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
