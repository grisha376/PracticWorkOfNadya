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
    public class Product_on_warehouseController : Controller
    {
        private SKLADEntities db = new SKLADEntities();

        // GET: Product_on_warehouse
        public ActionResult Index()
        {
            var product_on_warehouse = db.Product_on_warehouse.Include(p => p.Ranges).Include(p => p.Warehouse);
            return View(product_on_warehouse.ToList());
        }

        // GET: Product_on_warehouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_on_warehouse product_on_warehouse = db.Product_on_warehouse.Find(id);
            if (product_on_warehouse == null)
            {
                return HttpNotFound();
            }
            return View(product_on_warehouse);
        }

        // GET: Product_on_warehouse/Create
        public ActionResult Create()
        {
            ViewBag.ID_Product = new SelectList(db.Ranges, "ID_product", "Names_range");
            ViewBag.ID_Warehouse = new SelectList(db.Warehouse, "ID_Warehouse", "Names");
            ViewBag.kakdela = "E=mc^2  " + DateTime.Now.ToShortDateString();
            return View();
        }

        // POST: Product_on_warehouse/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Product_on_warehouse,ID_Product,ID_Warehouse,quantity")] Product_on_warehouse product_on_warehouse)
        {
            if (ModelState.IsValid)
            {
                db.Product_on_warehouse.Add(product_on_warehouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Product = new SelectList(db.Ranges, "ID_product", "Names_range", product_on_warehouse.ID_Product);
            ViewBag.ID_Warehouse = new SelectList(db.Warehouse, "ID_Warehouse", "Names", product_on_warehouse.ID_Warehouse);
            return View(product_on_warehouse);
        }

        // GET: Product_on_warehouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_on_warehouse product_on_warehouse = db.Product_on_warehouse.Find(id);
            if (product_on_warehouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Product = new SelectList(db.Ranges, "ID_product", "Names_range", product_on_warehouse.ID_Product);
            ViewBag.ID_Warehouse = new SelectList(db.Warehouse, "ID_Warehouse", "Names", product_on_warehouse.ID_Warehouse);
            return View(product_on_warehouse);
        }

        // POST: Product_on_warehouse/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Product_on_warehouse,ID_Product,ID_Warehouse,quantity")] Product_on_warehouse product_on_warehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_on_warehouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Product = new SelectList(db.Ranges, "ID_product", "Names_range", product_on_warehouse.ID_Product);
            ViewBag.ID_Warehouse = new SelectList(db.Warehouse, "ID_Warehouse", "Names", product_on_warehouse.ID_Warehouse);
            return View(product_on_warehouse);
        }

        // GET: Product_on_warehouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_on_warehouse product_on_warehouse = db.Product_on_warehouse.Find(id);
            if (product_on_warehouse == null)
            {
                return HttpNotFound();
            }
            return View(product_on_warehouse);
        }

        // POST: Product_on_warehouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_on_warehouse product_on_warehouse = db.Product_on_warehouse.Find(id);
            db.Product_on_warehouse.Remove(product_on_warehouse);
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
