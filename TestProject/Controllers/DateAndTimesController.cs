using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class DateAndTimesController : Controller
    {
        private Model2 db = new Model2();

        // GET: DateAndTimes
        public ActionResult Index()
        {
            return View(db.DateAndTimes.ToList());
        }

        // GET: DateAndTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateAndTime dateAndTime = db.DateAndTimes.Find(id);
            if (dateAndTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.DateOfBirth = new SelectList(db.DateAndTimes, "Id", "Id", dateAndTime.Id);
            return View(dateAndTime);
        }

        // GET: DateAndTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DateAndTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOfBirth,Name")] DateAndTime dateAndTime)
        {
            if (ModelState.IsValid)
            {
                db.DateAndTimes.Add(dateAndTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dateAndTime);
        }

        // GET: DateAndTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateAndTime dateAndTime = db.DateAndTimes.Find(id);
            if (dateAndTime == null)
            {
                return HttpNotFound();
            }
            return View(dateAndTime);
        }

        // POST: DateAndTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOfBirth,Name")] DateAndTime dateAndTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dateAndTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dateAndTime);
        }

        // GET: DateAndTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateAndTime dateAndTime = db.DateAndTimes.Find(id);
            if (dateAndTime == null)
            {
                return HttpNotFound();
            }
            return View(dateAndTime);
        }

        // POST: DateAndTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DateAndTime dateAndTime = db.DateAndTimes.Find(id);
            db.DateAndTimes.Remove(dateAndTime);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult CalculatesAge(string date)
        {
            DateTime startTime = DateTime.Parse(date, CultureInfo.CreateSpecificCulture("en-US"));
            DateTime endTime = DateTime.Today;
            TimeSpan timespan = endTime.Subtract(startTime);
            DateTime Age = DateTime.MinValue.AddDays(timespan.Days);
            var calculatedAge = string.Format(" {0} Years {1} Month {2} Days", Age.Year - 1, Age.Month - 1, Age.Day - 1);

            var json = Json(new
            {
                calculatedAge
            });
            return json;
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
