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
    public class InvestmentAccountsController : Controller
    {
        private EasyCreditEntities db = new EasyCreditEntities();

        // GET: InvestmentAccounts
        public ActionResult Index()
        {
            var investmentAccount = db.InvestmentAccount.Include(i => i.Clients).Include(i => i.PayMethodes);
            return View(investmentAccount.ToList());
        }

        // GET: InvestmentAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentAccount investmentAccount = db.InvestmentAccount.Find(id);
            if (investmentAccount == null)
            {
                return HttpNotFound();
            }
            return View(investmentAccount);
        }

        // GET: InvestmentAccounts/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName");
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod");
            return View();
        }

        // POST: InvestmentAccounts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdClient,Code,InvestementAmount,MonthlyRevenue,PayMethodeId,Especificaciones,DateInvestment,RegisteredBy")] InvestmentAccount investmentAccount)
        {
            if (ModelState.IsValid)
            {
                db.InvestmentAccount.Add(investmentAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", investmentAccount.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", investmentAccount.PayMethodeId);
            return View(investmentAccount);
        }

        // GET: InvestmentAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentAccount investmentAccount = db.InvestmentAccount.Find(id);
            if (investmentAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", investmentAccount.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", investmentAccount.PayMethodeId);
            return View(investmentAccount);
        }

        // POST: InvestmentAccounts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdClient,Code,InvestementAmount,MonthlyRevenue,PayMethodeId,Especificaciones,DateInvestment,RegisteredBy")] InvestmentAccount investmentAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investmentAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", investmentAccount.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", investmentAccount.PayMethodeId);
            return View(investmentAccount);
        }

        // GET: InvestmentAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentAccount investmentAccount = db.InvestmentAccount.Find(id);
            if (investmentAccount == null)
            {
                return HttpNotFound();
            }
            return View(investmentAccount);
        }

        // POST: InvestmentAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestmentAccount investmentAccount = db.InvestmentAccount.Find(id);
            db.InvestmentAccount.Remove(investmentAccount);
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
