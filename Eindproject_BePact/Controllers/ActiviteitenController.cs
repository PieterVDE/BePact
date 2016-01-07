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
using PagedList;

namespace Eindproject_BePact.Controllers
{
    public class ActiviteitenController : Controller
    {
        private BePactContext db = new BePactContext();

        // GET: Activiteiten
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var activiteiten = from a in db.Activiteiten
                           select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                activiteiten = activiteiten.Where(a => a.ActiviteitType.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "type_desc":
                    activiteiten = activiteiten.OrderByDescending(a => a.ActiviteitType);
                    break;
                default:
                    activiteiten = activiteiten.OrderBy(a => a.ID);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(activiteiten.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create([Bind(Include = "ActiviteitType")] Activiteit activiteit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Activiteiten.Add(activiteit);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "De wijzigingen konden niet opgeslagen worden. Probeer het opnieuw, als het probleem zich opnieuw voordoet contacteer je best de systeembeheerder.");
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
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var activiteitToUpdate = db.Personen.Find(id);
            if (TryUpdateModel(activiteitToUpdate, "",
               new string[] { "ActiviteitType" }))
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
            return View(activiteitToUpdate);
        }

        // GET: Activiteiten/Delete/5
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
            Activiteit activiteit = db.Activiteiten.Find(id);
            if (activiteit == null)
            {
                return HttpNotFound();
            }
            return View(activiteit);
        }

        // POST: Activiteiten/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                //Better performance than find & remove
                Activiteit activiteitToDelete = new Activiteit() { ID = id };
                db.Entry(activiteitToDelete).State = EntityState.Deleted;
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
