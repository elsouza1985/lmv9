using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lmv9.Models;

namespace lmv9.Controllers
{
    public class CompanyController : Controller
    {
        private  lmv9Model db = new lmv9Model();

        // GET: Company
        public ActionResult Index()
        {
            var companies = db.companies.Include(c => c.person);
            return View(companies.ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company company = db.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            //ViewBag.people_id = new SelectList(db.people, "people_id", "name");
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "company_id,name,address")] company company)
        {
            if (ModelState.IsValid)
            {
                person people = new person { name = company.Name };
                company.person = people;
                db.companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.people_id = new SelectList(db.people, "people_id", "name", company.people_id);
            return View(company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company company = db.companies.Find(id);
            person people = db.people.Find(company.people_id);
            company.Name = people.name;
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.people_id = company.people_id;
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "company_id,people_id,Name,address")] company company)
        {
            if (ModelState.IsValid)
            {
                person people = new person { people_id = company.people_id, name = company.Name };
                db.Entry(company).State = EntityState.Modified;
                db.Entry(people).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.people_id = new SelectList(db.people, "people_id", "name", company.people_id);
            return View(company);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company company = db.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            company company = db.companies.Find(id);
            db.companies.Remove(company);
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
