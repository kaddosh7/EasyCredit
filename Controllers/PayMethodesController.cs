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
    public class PayMethodesController : Controller
    {
        private EasyCreditEntities db = new EasyCreditEntities();

        // GET: PayMethodes
        public ActionResult Index()
        {
            return View(db.PayMethodes.ToList());
        }

        // GET: PayMethodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayMethodes payMethodes = db.PayMethodes.Find(id);
            if (payMethodes == null)
            {
                return HttpNotFound();
            }
            return View(payMethodes);
        }

        // GET: PayMethodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PayMethodes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PayMethod")] PayMethodes payMethodes)
        {
            if (ModelState.IsValid)
            {
                db.PayMethodes.Add(payMethodes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payMethodes);
        }

        // GET: PayMethodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayMethodes payMethodes = db.PayMethodes.Find(id);
            if (payMethodes == null)
            {
                return HttpNotFound();
            }
            return View(payMethodes);
        }

        // POST: PayMethodes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PayMethod")] PayMethodes payMethodes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payMethodes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payMethodes);
        }

        // GET: PayMethodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayMethodes payMethodes = db.PayMethodes.Find(id);
            if (payMethodes == null)
            {
                return HttpNotFound();
            }
            return View(payMethodes);
        }

        // POST: PayMethodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PayMethodes payMethodes = db.PayMethodes.Find(id);
            db.PayMethodes.Remove(payMethodes);
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
