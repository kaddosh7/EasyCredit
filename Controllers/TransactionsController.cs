using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetCore.Reporting;
using EasyCredit.Models;
using Microsoft.AspNet.Identity;

namespace EasyCredit.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private EasyCreditEntities db = new EasyCreditEntities();

        // GET: Transactions
        public ActionResult Index(string Search)
        {
            var transactions = db.Transactions.Include(t => t.Clients).Include(t => t.PayMethodes).Include(t => t.TypeTransaction);

            if (!String.IsNullOrEmpty(Search))
            {
                //var mora = from mo in db.Transactions select mo;
                transactions = db.Transactions.Where(x => x.nivel_mora.ToString() == Search);

                var totalTransacciones = from tTransact in db.Transactions.Where(x => x.nivel_mora.ToString() == Search) select tTransact.TransactionAmount;
                var totalIntereses = from tIntereses in db.Transactions.Where(x => x.nivel_mora.ToString() == Search) select tIntereses.mora;

                ViewBag.TotalTransacciones = totalTransacciones.Sum();
                ViewBag.TotalIntereses = totalIntereses.Sum();
            } else
            {
                var totalTransacciones = from tTransact in db.Transactions select tTransact.TransactionAmount;
                var totalIntereses2 = from tIntereses in db.Transactions select tIntereses.mora;

                ViewBag.TotalTransacciones = totalTransacciones.Sum();
                ViewBag.TotalIntereses = totalIntereses2.Sum();
            }

            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // GET: Transactions/Create
        public ActionResult Create(int? id)
        {
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName");
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod");
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId");
            return View();
        }

        // POST: Transactions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdClient,TypeTransId,TransactionAmount,PayMethodeId,DepositDate,RegisteredBy")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transactions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", transactions.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", transactions.PayMethodeId);
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId", transactions.TypeTransId);
            return View(transactions);
        }


        public ActionResult AddLoanPay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName");
            ViewBag.LoanPaymentId = id;
            //ViewBag.Cliente = db.LoanAccount.Join(db.Clients, loan => loan.IdClient,
            //    cte => cte.Id, (loan, cte) => new { loan.IdClient, cte.Cte_FirstName, cte.Cte_LastName}).FirstOrDefault(x => x.IdClient == 102002);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod");
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId");

            return View();
        }

        // POST: Transactions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLoanPay(int? id, [Bind(Include = "Id,IdClient,TypeTransId,TransactionAmount,PayMethodeId,DepositDate,RegisteredBy, nivel_mora, mora, LoanId")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                {
                    if (transactions.nivel_mora == null)
                    {
                        transactions.nivel_mora = 0;
                        transactions.mora = 0.0m;
                    }
                    transactions.DepositDate = DateTime.Now;
                    transactions.RegisteredBy = User.Identity.GetUserName();
                    transactions.LoanId = id;
                }
                db.Transactions.Add(transactions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", transactions.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", transactions.PayMethodeId);
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId", transactions.TypeTransId);

            return View(transactions);
        }




        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", transactions.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", transactions.PayMethodeId);
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId", transactions.TypeTransId);
            return View(transactions);
        }

        // POST: Transactions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdClient,TypeTransId,TransactionAmount,PayMethodeId,DepositDate,RegisteredBy")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Cte_FirstName", transactions.IdClient);
            ViewBag.PayMethodeId = new SelectList(db.PayMethodes, "Id", "PayMethod", transactions.PayMethodeId);
            ViewBag.TypeTransId = new SelectList(db.TypeTransaction, "Id", "TypeTransId", transactions.TypeTransId);
            return View(transactions);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transactions transactions = db.Transactions.Find(id);
            db.Transactions.Remove(transactions);
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

        //private IWebHostEnvironment _webHostEnvironment;
        //private TransactionsController(IWebHostEnvironment webHostEnvironment)
        //{
        //    this._webHostEnvironment = webHostEnvironment;
        //}

        //public ActionResult Print()
        //{
        //    string mintype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnvironment}\\Transaction\\ReportePagoPrestamos.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("TimbreCrediFast", "Address");
        //    LocalReport localReport = new LocalReport(path);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mintype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //private interface IWebHostEnvironment
        //{
        //}
    }
}
