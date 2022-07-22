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
    public class TypeTransactionsController : Controller
    {
        private EasyCreditEntities db = new EasyCreditEntities();

        // GET: TypeTransactions
        public ActionResult Index()
        {
            return View(db.TypeTransaction.ToList());
        }

        // GET: TypeTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeTransaction typeTransaction = db.TypeTransaction.Find(id);
            if (typeTransaction == null)
            {
                return HttpNotFound();
            }
            return View(typeTransaction);
        }

        // GET: TypeTransactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeTransactions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeTransId")] TypeTransaction typeTransaction)
        {
            if (ModelState.IsValid)
            {
                db.TypeTransaction.Add(typeTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeTransaction);
        }

        // GET: TypeTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeTransaction typeTransaction = db.TypeTransaction.Find(id);
            if (typeTransaction == null)
            {
                return HttpNotFound();
            }
            return View(typeTransaction);
        }

        // POST: TypeTransactions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeTransId")] TypeTransaction typeTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeTransaction);
        }

        // GET: TypeTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeTransaction typeTransaction = db.TypeTransaction.Find(id);
            if (typeTransaction == null)
            {
                return HttpNotFound();
            }
            return View(typeTransaction);
        }

        // POST: TypeTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeTransaction typeTransaction = db.TypeTransaction.Find(id);
            db.TypeTransaction.Remove(typeTransaction);
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
