using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eindproject_BePact.DAL;
using Eindproject_BePact.Models;

namespace Eindproject_BePact.Controllers
{
    public class ActiviteitenController : Controller
    {
        private BePactContext db = new BePactContext();

        // GET: Activiteiten
        public ActionResult Index()
        {
            return View(db.Activiteiten.ToList());
        }

        // GET: Activiteiten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activiteit activiteit = db.Activiteiten.Find(id);
            if (activiteit == null)
            {
                return HttpNotFound();
            }
            return View(activiteit);
        }

        // GET: Activiteiten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activiteiten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ActiviteitType")] Activiteit activiteit)
        {
            if (ModelState.IsValid)
            {
                db.Activiteiten.Add(activiteit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activiteit);
        }

        // GET: Activiteiten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activiteit activiteit = db.Activiteiten.Find(id);
            if (activiteit == null)
            {
                return HttpNotFound();
            }
            return View(activiteit);
        }

        // POST: Activiteiten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ActiviteitType")] Activiteit activiteit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activiteit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activiteit);
        }

        // GET: Activiteiten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activiteit activiteit = db.Activiteiten.Find(id);
            if (activiteit == null)
            {
                return HttpNotFound();
            }
            return View(activiteit);
        }

        // POST: Activiteiten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activiteit activiteit = db.Activiteiten.Find(id);
            db.Activiteiten.Remove(activiteit);
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
