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
    public class Accepted_productController : Controller
    {
        private SKLADEntities db = new SKLADEntities();

        // GET: Accepted_product
        public ActionResult Index()
        {
            var accepted_product = db.Accepted_product.Include(a => a.Dispatch).Include(a => a.Ranges);
            return View(accepted_product.ToList());
        }

        // GET: Accepted_product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accepted_product accepted_product = db.Accepted_product.Find(id);
            if (accepted_product == null)
            {
                return HttpNotFound();
            }
            return View(accepted_product);
        }

        // GET: Accepted_product/Create
        public ActionResult Create()
        {
            ViewBag.ID_dispatch = new SelectList(db.Dispatch, "ID_dispatch", "ID_dispatch");
            ViewBag.ID_product = new SelectList(db.Ranges, "ID_product", "Names_range");
            return View();
        }

        // POST: Accepted_product/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_dispatch,quantity,ID_product")] Accepted_product accepted_product)
        {
            if (ModelState.IsValid)
            {
                db.Accepted_product.Add(accepted_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_dispatch = new SelectList(db.Dispatch, "ID_dispatch", "ID_dispatch", accepted_product.ID_dispatch);
            ViewBag.ID_product = new SelectList(db.Ranges, "ID_product", "Names_range", accepted_product.ID_product);
            return View(accepted_product);
        }

        // GET: Accepted_product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accepted_product accepted_product = db.Accepted_product.Find(id);
            if (accepted_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_dispatch = new SelectList(db.Dispatch, "ID_dispatch", "ID_dispatch", accepted_product.ID_dispatch);
            ViewBag.ID_product = new SelectList(db.Ranges, "ID_product", "Names_range", accepted_product.ID_product);
            return View(accepted_product);
        }

        // POST: Accepted_product/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_dispatch,quantity,ID_product")] Accepted_product accepted_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accepted_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_dispatch = new SelectList(db.Dispatch, "ID_dispatch", "ID_dispatch", accepted_product.ID_dispatch);
            ViewBag.ID_product = new SelectList(db.Ranges, "ID_product", "Names_range", accepted_product.ID_product);
            return View(accepted_product);
        }

        // GET: Accepted_product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accepted_product accepted_product = db.Accepted_product.Find(id);
            if (accepted_product == null)
            {
                return HttpNotFound();
            }
            return View(accepted_product);
        }

        // POST: Accepted_product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accepted_product accepted_product = db.Accepted_product.Find(id);
            db.Accepted_product.Remove(accepted_product);
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
