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
        public ActionResult Create([Bind(Include = "Voornaam,Achternaam,Email,Telefoonnr")] Persoon persoon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Personen.Add(persoon);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "De wijzigingen konden niet opgeslagen worden. Probeer het opnieuw, als het probleem zich opnieuw voordoet contacteer je best de systeembeheerder.");
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
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var persoonToUpdate = db.Personen.Find(id);
            if (TryUpdateModel(persoonToUpdate, "",
               new string[] { "Voornaam", "Achternaam", "Email", "Telefoonnr" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "De wijzigingen konden niet opgeslagen worden. Probeer het opnieuw, als het probleem zich opnieuw voordoet contacteer je best de systeembeheerder.");
                }
            }
            return View(persoonToUpdate);
        }

        // GET: Personen/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Verwijderen is mislukt. Probeer het opnieuw, en als het probleem zich blijft voordoen contacteer je best de systeembeheerder.";
            }
            Persoon persoon = db.Personen.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        // POST: Personen/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                //Better performance than find & remove
                Persoon persoonToDelete = new Persoon() { ID = id };
                db.Entry(persoonToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
