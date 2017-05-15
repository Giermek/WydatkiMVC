using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WydatkiMVC.Models;

namespace WydatkiMVC.Controllers
{
    public class MoneysController : Controller
    {
        private MoneyContext db = new MoneyContext();

        // GET: Moneys
        public ActionResult Index()
        {
            return View(db.Moneys.ToList());
        }

        // GET: Moneys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Money money = db.Moneys.Find(id);
            if (money == null)
            {
                return HttpNotFound();
            }
            return View(money);
        }

        // GET: Moneys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moneys/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoneyId,Amount,Details,Category")] Money money)
        {
            if (ModelState.IsValid)
            {
                db.Moneys.Add(money);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(money);
        }

        // GET: Moneys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Money money = db.Moneys.Find(id);
            if (money == null)
            {
                return HttpNotFound();
            }
            return View(money);
        }

        // POST: Moneys/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoneyId,Amount,Details,Category")] Money money)
        {
            if (ModelState.IsValid)
            {
                db.Entry(money).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(money);
        }

        // GET: Moneys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Money money = db.Moneys.Find(id);
            if (money == null)
            {
                return HttpNotFound();
            }
            return View(money);
        }

        // POST: Moneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Money money = db.Moneys.Find(id);
            db.Moneys.Remove(money);
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
