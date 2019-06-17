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
    public class CustomerController : Controller
    {
        private lmv9Model db = new lmv9Model();

        // GET: Customer
        public ActionResult Index()
        {
            var customers = db.customers.Include(c => c.person);
            return View(customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            //ViewBag.people_id = new SelectList(db.people, "people_id", "name");
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "custumer_id,people_id,Name,Phone,company_id,gender")] customer customer)
        {
            if (ModelState.IsValid)
            {
                person people = new person { name = customer.Name };
                phone cel = new phone { phone1 = customer.Phone };
                people.phones.Add(cel);
                customer.person = people;
                db.customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.people_id = new SelectList(db.people, "people_id", "name", customer.people_id);
            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = db.customers.Find(id);
            person people = db.people.Find(customer.people_id);
            var tel = db.phones.Where(p => p.people_id == customer.people_id).First();
            customer.Phone = tel.phone1;
            people.phones.Add(tel);
            customer.person = people;
            customer.Name = people.name;
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.people_id = new SelectList(db.people, "people_id", "name", customer.people_id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(customer customer)
        {
            if (ModelState.IsValid)
            {
                //var people = new person { people_id = customer.people_id, name = customer.Name };
                //phone cel = new phone { phone1 = customer.Phone, people_id = customer.people_id };
                //people.phones.FirstOrDefault().phone1 = customer.Phone;
                db.Entry(customer).State = EntityState.Modified;
                //db.(cel).State = EntityState.Modified;
                //db.Entry(people).State = EntityState.Modified;
                var people = db.people.Where(x => x.people_id == customer.people_id).FirstOrDefault();
                var cel = db.phones.Where(c => c.people_id == customer.people_id).FirstOrDefault();
                cel.phone1 = customer.Phone;
                people.name = customer.Name;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.people_id = new SelectList(db.people, "people_id", "name", customer.people_id);
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customer customer = db.customers.Find(id);
            db.customers.Remove(customer);
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
