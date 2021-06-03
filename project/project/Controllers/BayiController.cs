using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project;

namespace project.Controllers
{
    public class BayiController : Controller
    {
        private prEntities db = new prEntities();

        // GET: Bayi
        public ActionResult Index()
        {
            return View(db.Bayi.ToList());
        }

        // GET: Bayi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bayi bayi = db.Bayi.Find(id);
            if (bayi == null)
            {
                return HttpNotFound();
            }
            return View(bayi);
        }

        // GET: Bayi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bayi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,BayiAdi,BayiKodu,Adres")] Bayi bayi)
        {
            if (ModelState.IsValid)
            {
                db.Bayi.Add(bayi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bayi);
        }

        // GET: Bayi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bayi bayi = db.Bayi.Find(id);
            if (bayi == null)
            {
                return HttpNotFound();
            }
            return View(bayi);
        }

        // POST: Bayi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,BayiAdi,BayiKodu,Adres")] Bayi bayi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bayi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bayi);
        }

        // GET: Bayi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bayi bayi = db.Bayi.Find(id);
            if (bayi == null)
            {
                return HttpNotFound();
            }
            return View(bayi);
        }

        // POST: Bayi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bayi bayi = db.Bayi.Find(id);
            db.Bayi.Remove(bayi);
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
