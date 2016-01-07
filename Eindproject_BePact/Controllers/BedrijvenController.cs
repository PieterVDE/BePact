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
    public class BedrijvenController : Controller
    {
        private BePactContext db = new BePactContext();

        // GET: Bedrijven
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NaamSortParm = String.IsNullOrEmpty(sortOrder) ? "naam_desc" : "";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "email_desc" : "Email";
            ViewBag.TelnrSortParm = sortOrder == "Telefoonnr" ? "telnr_desc" : "Telefoonnr";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var bedrijven = from b in db.Bedrijven
                            select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                bedrijven = bedrijven.Where(b => b.Naam.Contains(searchString)
                                    || b.Email.Contains(searchString)
                                    || b.Telefoonnr.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "naam_desc":
                    bedrijven = bedrijven.OrderByDescending(b => b.Naam);
                    break;
                case "Email":
                    bedrijven = bedrijven.OrderBy(b => b.Email);
                    break;
                case "email_desc":
                    bedrijven = bedrijven.OrderByDescending(b => b.Email);
                    break;
                case "Telefoonnr":
                    bedrijven = bedrijven.OrderBy(b => b.Telefoonnr);
                    break;
                case "telnr_desc":
                    bedrijven = bedrijven.OrderByDescending(b => b.Telefoonnr);
                    break;
                default:
                    bedrijven = bedrijven.OrderBy(b => b.ID);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(bedrijven.ToPagedList(pageNumber, pageSize));
        }

        // GET: Bedrijven/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bedrijf bedrijf = db.Bedrijven.Find(id);
            if (bedrijf == null)
            {
                return HttpNotFound();
            }
            return View(bedrijf);
        }

        // GET: Bedrijven/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bedrijven/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naam,Email,Telefoonnr")] Bedrijf bedrijf)
        {
            if (ModelState.IsValid)
            {
                db.Bedrijven.Add(bedrijf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bedrijf);
        }

        // GET: Bedrijven/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bedrijf bedrijf = db.Bedrijven.Find(id);
            if (bedrijf == null)
            {
                return HttpNotFound();
            }
            return View(bedrijf);
        }

        // POST: Bedrijven/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naam,Email,Telefoonnr")] Bedrijf bedrijf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bedrijf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bedrijf);
        }

        // GET: Bedrijven/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bedrijf bedrijf = db.Bedrijven.Find(id);
            if (bedrijf == null)
            {
                return HttpNotFound();
            }
            return View(bedrijf);
        }

        // POST: Bedrijven/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bedrijf bedrijf = db.Bedrijven.Find(id);
            db.Bedrijven.Remove(bedrijf);
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
