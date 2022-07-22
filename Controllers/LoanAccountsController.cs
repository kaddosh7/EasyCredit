using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyCredit.Models;
using Microsoft.AspNet.Identity;

namespace EasyCredit.Controllers
{
    [Authorize]
    public class LoanAccountsController : Controller
    {
        private EasyCreditEntities db = new EasyCreditEntities();

        // GET: LoanAccounts
        public ActionResult Index()
        {
            var loanAccount = db.LoanAccount.Include(l => l.Clients).Include(l => l.Clients1).Include(l => l.Warranty).Include(l => l.PayMethodes).Include(l => l.TypeTransaction);
            return View(loanAccount.ToList());
        }

        // GET: LoanAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanAccount loanAccount = db.LoanAccount.Find(id);
            if (loanAccount == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Pagos = db.Transactions.Select(x => new { x.Id, x.TransactionAmount }).ToList();
            var montoPagos = from mPagos in db.Transactions.Where(x => x.LoanId == id) select mPagos.TransactionAmount;
            var montoMora = from mMoras in db.Transactions.Where(m => m.LoanId == id) select mMoras.mora;

            if (montoPagos.Count() > 0 && montoMora.Count() > 0)
            {
                ViewBag.MontoPagado = montoPagos.Sum() + montoMora.Sum();
            } else
            {
                ViewBag.MontoPagado = 0;
            }

            ViewBag.IdTransaccion = db.Transactions.ToList();
            return View(loanAccount);
        }

        // GET: LoanAccounts/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName");
            ViewBag.IdWarrant = new SelectList(db.Clients, "Id", "Cte_FirstName");
            ViewBag.IdWarranty = new SelectList(db.Warranty, "Id", "TypeWarranty");
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod");
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId");
            return View();
        }

        // POST: LoanAccounts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdClient,TypeTransId,RequiredAmount,PayMethodeId,IdWarranty,IdWarrant,CuotesQuantity,CuotesAmount,MonthlyInterest,RequirementDate,AproveDate,InitialPayDate,FinalPayDate,RegisteredBy,Aprobacion")] LoanAccount loanAccount)
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                {
                    loanAccount.RequirementDate = DateTime.Now;
                    loanAccount.RegisteredBy = User.Identity.GetUserName();
                    loanAccount.Aprobacion = 0;
                }
                db.LoanAccount.Add(loanAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdClient);
            ViewBag.IdWarrant = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdWarrant);
            ViewBag.IdWarranty = new SelectList(db.Warranty, "Id", "TypeWarranty", loanAccount.IdWarranty);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", loanAccount.PayMethodeId);
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId", loanAccount.TypeTransId);
            return View(loanAccount);
        }

        // GET: LoanAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanAccount loanAccount = db.LoanAccount.Find(id);
            if (loanAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdClient);
            ViewBag.IdWarrant = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdWarrant);
            ViewBag.IdWarranty = new SelectList(db.Warranty, "Id", "TypeWarranty", loanAccount.IdWarranty);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", loanAccount.PayMethodeId);
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId", loanAccount.TypeTransId);

            loanAccount.RequirementDate.ToString("yyyy-mm-dd");

            if (User.Identity.GetUserName() != "kaddosh77@gmail.com")
            {
                return RedirectToAction("Index");
            }
            return View(loanAccount);
        }

        // POST: LoanAccounts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdClient,TypeTransId,RequiredAmount,PayMethodeId,IdWarranty,IdWarrant,CuotesQuantity,CuotesAmount,MonthlyInterest,RequirementDate,AproveDate,InitialPayDate,FinalPayDate,RegisteredBy, Aprobacion")] LoanAccount loanAccount)
        {
            if (ModelState.IsValid)
            {
                loanAccount.AproveDate = DateTime.Now;
                loanAccount.Aprobacion = 1;
                db.Entry(loanAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdClient);
            ViewBag.IdWarrant = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdWarrant);
            ViewBag.IdWarranty = new SelectList(db.Warranty, "Id", "TypeWarranty", loanAccount.IdWarranty);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", loanAccount.PayMethodeId);
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId", loanAccount.TypeTransId);
            return View(loanAccount);
        }

        //
        // APROBACIONES DE PRESTAMOS
        //
        // GET: LoanAccounts/Edit/5
        public ActionResult LoanAprov(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanAccount loanAccount = db.LoanAccount.Find(id);
            if (loanAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdClient);
            ViewBag.IdWarrant = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdWarrant);
            ViewBag.IdWarranty = new SelectList(db.Warranty, "Id", "TypeWarranty", loanAccount.IdWarranty);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", loanAccount.PayMethodeId);
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId", loanAccount.TypeTransId);

            loanAccount.RequirementDate.ToString("yyyy-mm-dd");

            if (User.Identity.GetUserName() != "kaddosh77@gmail.com")
            {
                return RedirectToAction("Index");
            }
            return View(loanAccount);
        }

        // POST: LoanAccounts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoanAprov([Bind(Include = "Id,IdClient,TypeTransId,RequiredAmount,PayMethodeId,IdWarranty,IdWarrant,CuotesQuantity,CuotesAmount,MonthlyInterest,RequirementDate,AproveDate,InitialPayDate,FinalPayDate,RegisteredBy,Aprobacion")] LoanAccount loanAccount)
        {
            if (ModelState.IsValid)
            {
                loanAccount.AproveDate = DateTime.Now;
                loanAccount.Aprobacion = 1;
                db.Entry(loanAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdClient);
            ViewBag.IdWarrant = new SelectList(db.Clients, "Id", "Cte_FirstName", loanAccount.IdWarrant);
            ViewBag.IdWarranty = new SelectList(db.Warranty, "Id", "TypeWarranty", loanAccount.IdWarranty);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", loanAccount.PayMethodeId);
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId", loanAccount.TypeTransId);
            return View(loanAccount);
        }




        // GET: LoanAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanAccount loanAccount = db.LoanAccount.Find(id);
            if (loanAccount == null)
            {
                return HttpNotFound();
            }
            return View(loanAccount);
        }

        // POST: LoanAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanAccount loanAccount = db.LoanAccount.Find(id);
            db.LoanAccount.Remove(loanAccount);
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
