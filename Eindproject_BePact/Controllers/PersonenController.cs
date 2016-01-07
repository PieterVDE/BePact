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
    public class PersonenController : Controller
    {
        private BePactContext db = new BePactContext();

        // GET: Personen
        public ActionResult Index()
        {
            return View(db.Personen.ToList());
        }

        // GET: Personen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persoon persoon = db.Personen.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        // GET: Personen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Voornaam,Achternaam,Email,Telefoonnr")] Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.Personen.Add(persoon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persoon);
        }

        // GET: Personen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persoon persoon = db.Personen.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        // POST: Personen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Voornaam,Achternaam,Email,Telefoonnr")] Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persoon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persoon);
        }

        // GET: Personen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persoon persoon = db.Personen.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        // POST: Personen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persoon persoon = db.Personen.Find(id);
            db.Personen.Remove(persoon);
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
