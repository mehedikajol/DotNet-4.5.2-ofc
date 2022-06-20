using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class SubjectDetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: SubjectDets
        public ActionResult Index()
        {
            var subjectDets = db.SubjectDets.Include(s => s.SubjectMa);
            return View(subjectDets.ToList());
        }

        // GET: SubjectDets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectDet subjectDet = db.SubjectDets.Find(id);
            if (subjectDet == null)
            {
                return HttpNotFound();
            }
            return View(subjectDet);
        }

        // GET: SubjectDets/Create
        public ActionResult Create()
        {
            ViewBag.SubjectMasId = new SelectList(db.SubjectMas, "Id", "Id");
            return View();
        }

        // POST: SubjectDets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubjectName,SubjectMasId")] SubjectDet subjectDet)
        {
            if (ModelState.IsValid)
            {
                db.SubjectDets.Add(subjectDet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectMasId = new SelectList(db.SubjectMas, "Id", "Id", subjectDet.SubjectMasId);
            return View(subjectDet);
        }

        // GET: SubjectDets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectDet subjectDet = db.SubjectDets.Find(id);
            if (subjectDet == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectMasId = new SelectList(db.SubjectMas, "Id", "Id", subjectDet.SubjectMasId);
            return View(subjectDet);
        }

        // POST: SubjectDets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubjectName,SubjectMasId")] SubjectDet subjectDet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectDet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectMasId = new SelectList(db.SubjectMas, "Id", "Id", subjectDet.SubjectMasId);
            return View(subjectDet);
        }

        // GET: SubjectDets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectDet subjectDet = db.SubjectDets.Find(id);
            if (subjectDet == null)
            {
                return HttpNotFound();
            }
            return View(subjectDet);
        }

        // POST: SubjectDets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectDet subjectDet = db.SubjectDets.Find(id);
            db.SubjectDets.Remove(subjectDet);
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
