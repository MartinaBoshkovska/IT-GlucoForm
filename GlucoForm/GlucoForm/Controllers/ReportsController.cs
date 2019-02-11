using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlucoForm.Models;

namespace GlucoForm.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reports
        public ActionResult Index()
        {
            if (!User.IsInRole("Admin"))
            {
                if (User.IsInRole("Doctor"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            var reports = db.Reports.Include(r => r.Patient);
            return View(reports.ToList());
        }

        // GET: MyReports
        //public ActionResult MyReports()
        //{
        //    var currentUser = db.Patients.Where(l => l.Email == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault().Id;
        //    var reports = db.Reports.Where(m => m.PatientId == currentUser).Include(r => r.Patient);
        //    ViewBag.patId = currentUser;
        //    return View(reports.ToList());
        //}

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public ActionResult Create(int? patientId)
        {
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "UserId");
            if (patientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = new Report();
            report.PatientId = (int)patientId;
            return View(report);
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Report report)
        {
            if (ModelState.IsValid)
            {
                //db.Reports.Add(report);
                //db.SaveChanges();
                //return RedirectToAction("Details", "Patients", new { id = report.PatientId});

                return RedirectToAction("UploadFile", "Reports", report);
                
            }

            ViewBag.PatientId = new SelectList(db.Patients, "Id", "UserId", report.PatientId);
            return View(report);
        }

        public ActionResult UploadFile(Report report)
        {
            var rfvm = new ReportsFileViewModel();
            rfvm.report = report;
            return View(rfvm);
        }

        [HttpPost]
        public ActionResult UploadFile(ReportsFileViewModel rfvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (rfvm.file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(rfvm.file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/App_Data/uploads"), _FileName);
                        rfvm.file.SaveAs(_path);
                        rfvm.report.ECGfile = _path;
                        db.Reports.Add(rfvm.report);
                        db.SaveChanges();
                        //if (User.IsInRole("Patient")){
                        //    return RedirectToAction("MyReports", "Reports", new { id = rfvm.report.PatientId });
                        //}
                        return RedirectToAction("Details", "Patients", new { id = rfvm.report.PatientId });
                    }
                }
                catch
                {
                    ViewBag.Message = "File upload failed!!";
                    return View(rfvm);
                }
            }

            return View(rfvm);
        }


        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "UserId", report.PatientId);
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportId,PatientId,ReportDate,MeasurementTime,Period,MeasurementValue,Comment")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Patients", new { id = report.PatientId });
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "UserId", report.PatientId);
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report report = db.Reports.Find(id);
            db.Reports.Remove(report);
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
