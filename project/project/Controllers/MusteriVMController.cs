using project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class MusteriVMController : Controller
    {
        prEntities db = new prEntities();
       

        // GET: MusteriView
        public ActionResult Index()
        {
            List<Bayi> bayi = db.Bayi.ToList();
            List<Musteri> musteri = db.Musteri.ToList(); ;
            var MusModel = from b in bayi
                           join m in musteri on b.id equals m.BayiID
                                   select new MusteriVM { bayiVM = b, musteriVM = m };
            return View(MusModel.ToList());

        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            ViewBag.BayiID = new SelectList(db.Bayi, "id", "BayiAdi", musteri.BayiID);
            return View(musteri);
        }

        // POST: Musteris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,BayiID,Adi,Soyadi,VergiNo")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BayiID = new SelectList(db.Bayi, "id", "BayiAdi", musteri.BayiID);
            return View(musteri);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Musteris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteri musteri = db.Musteri.Find(id);
            db.Musteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.BayiID = new SelectList(db.Bayi, "id", "BayiAdi");
            return View();
        }

        // POST: Musteris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,BayiID,Adi,Soyadi,VergiNo")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Musteri.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BayiID = new SelectList(db.Bayi, "id", "BayiAdi", musteri.BayiID);
            return View(musteri);
        }
    }
}