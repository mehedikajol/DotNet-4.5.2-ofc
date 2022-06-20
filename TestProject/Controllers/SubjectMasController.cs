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
    public class SubjectMasController : Controller
    {
        private Model1 db = new Model1();

        // GET: SubjectMas
        public ActionResult Index()
        {
            var subjectMas = db.SubjectMas.Include(s => s.Student);
            return View(subjectMas.ToList());
        }

        // GET: SubjectMas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMa subjectMa = db.SubjectMas.Find(id);
            if (subjectMa == null)
            {
                return HttpNotFound();
            }
            return View(subjectMa);
        }

        // GET: SubjectMas/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentName");
            return View();
        }

        // POST: SubjectMas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId")] SubjectMa subjectMa)
        {
            if (ModelState.IsValid)
            {
                db.SubjectMas.Add(subjectMa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentName", subjectMa.StudentId);
            return View(subjectMa);
        }

        // GET: SubjectMas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMa subjectMa = db.SubjectMas.Find(id);
            if (subjectMa == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentName", subjectMa.StudentId);
            return View(subjectMa);
        }

        // POST: SubjectMas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId")] SubjectMa subjectMa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectMa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentName", subjectMa.StudentId);
            return View(subjectMa);
        }

        // GET: SubjectMas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMa subjectMa = db.SubjectMas.Find(id);
            if (subjectMa == null)
            {
                return HttpNotFound();
            }
            return View(subjectMa);
        }

        // POST: SubjectMas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectMa subjectMa = db.SubjectMas.Find(id);
            db.SubjectMas.Remove(subjectMa);
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
