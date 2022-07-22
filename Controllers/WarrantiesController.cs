using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyCredit.Models;

namespace EasyCredit.Controllers
{
    [Authorize]
    public class WarrantiesController : Controller
    {
        private EasyCreditEntities db = new EasyCreditEntities();

        // GET: Warranties
        public ActionResult Index()
        {
            return View(db.Warranty.ToList());
        }

        // GET: Warranties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warranty warranty = db.Warranty.Find(id);
            if (warranty == null)
            {
                return HttpNotFound();
            }
            return View(warranty);
        }

        // GET: Warranties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warranties/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeWarranty,Especifications")] Warranty warranty)
        {
            if (ModelState.IsValid)
            {
                db.Warranty.Add(warranty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warranty);
        }

        // GET: Warranties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warranty warranty = db.Warranty.Find(id);
            if (warranty == null)
            {
                return HttpNotFound();
            }
            return View(warranty);
        }

        // POST: Warranties/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeWarranty,Especifications")] Warranty warranty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warranty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warranty);
        }

        // GET: Warranties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warranty warranty = db.Warranty.Find(id);
            if (warranty == null)
            {
                return HttpNotFound();
            }
            return View(warranty);
        }

        // POST: Warranties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warranty warranty = db.Warranty.Find(id);
            db.Warranty.Remove(warranty);
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
