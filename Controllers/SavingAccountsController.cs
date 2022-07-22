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
    public class SavingAccountsController : Controller
    {
        private EasyCreditEntities db = new EasyCreditEntities();

        // GET: SavingAccounts
        public ActionResult Index()
        {
            var savingAccounts = db.SavingAccounts.Include(s => s.Clients).Include(s => s.PayMethodes);
            return View(savingAccounts.ToList());
        }

        // GET: SavingAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingAccounts savingAccounts = db.SavingAccounts.Find(id);
            if (savingAccounts == null)
            {
                return HttpNotFound();
            }
            return View(savingAccounts);
        }

        // GET: SavingAccounts/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName");
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod");
            return View();
        }

        // POST: SavingAccounts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdClient,DateOpeningAccount,DepositAmount,PayMethodeId,RegisteredBy")] SavingAccounts savingAccounts)
        {
            if (ModelState.IsValid)
            {
                db.SavingAccounts.Add(savingAccounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", savingAccounts.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", savingAccounts.PayMethodeId);
            return View(savingAccounts);
        }

        // GET: SavingAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingAccounts savingAccounts = db.SavingAccounts.Find(id);
            if (savingAccounts == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", savingAccounts.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", savingAccounts.PayMethodeId);
            return View(savingAccounts);
        }

        // POST: SavingAccounts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdClient,DateOpeningAccount,DepositAmount,PayMethodeId,RegisteredBy")] SavingAccounts savingAccounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(savingAccounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", savingAccounts.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", savingAccounts.PayMethodeId);
            return View(savingAccounts);
        }

        // GET: SavingAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingAccounts savingAccounts = db.SavingAccounts.Find(id);
            if (savingAccounts == null)
            {
                return HttpNotFound();
            }
            return View(savingAccounts);
        }

        // POST: SavingAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SavingAccounts savingAccounts = db.SavingAccounts.Find(id);
            db.SavingAccounts.Remove(savingAccounts);
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
