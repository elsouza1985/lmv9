using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lmv9.Models;

namespace lmv9.Controllers
{
    public class AppointmentController : Controller
    {
        private lmv9Model db = new lmv9Model();

        // GET: Appointment
        public ActionResult Index()
        {
            var appointments = db.appointments.Include(a => a.company).Include(a => a.customer);
            return View(appointments.ToList());
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appointment appointment = db.appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            ViewBag.people = new SelectList(db.customers, "custumer_id", "person.name");//new SelectList(db.customers.Join(db.people, t => t.people_id, peop => peop.people_id, (t, peop) => new { customer = peop, person = t }) , "people.people_id", "people.name");
            //ViewBag.customer_id = new SelectList(db.customers, "custumer_id", "gender");
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( string dataEntrada, string people)
        {
            if (ModelState.IsValid)
            {
                CultureInfo culture = new CultureInfo("pt-BR");

                AgendaNovo agendamento = new AgendaNovo{ clientID = int.Parse(people), dataEntrada = dataEntrada} ;
                appointment app1 = new appointment();
                app1.appointment_date_in = Convert.ToDateTime(agendamento.dataEntrada, culture);
                customer client = db.customers.Where(t => t.custumer_id == agendamento.clientID).FirstOrDefault();
                app1.customer_id = client.people_id;
                app1.company_id = 1;
                db.appointments.Add(app1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.company_id = new SelectList(db.companies, "company_id", "address", appointment.company_id);
            //ViewBag.customer_id = new SelectList(db.customers, "custumer_id", "gender", appointment.customer_id);
            return View();
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appointment appointment = db.appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.company_id = new SelectList(db.companies, "company_id", "address", appointment.company_id);
            ViewBag.customer_id = new SelectList(db.customers, "custumer_id", "gender", appointment.customer_id);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "appointment_id,appointment_date_in,appointment_date_out,customer_id,company_id")] appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.company_id = new SelectList(db.companies, "company_id", "address", appointment.company_id);
            ViewBag.customer_id = new SelectList(db.customers, "custumer_id", "gender", appointment.customer_id);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appointment appointment = db.appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appointment appointment = db.appointments.Find(id);
            db.appointments.Remove(appointment);
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
