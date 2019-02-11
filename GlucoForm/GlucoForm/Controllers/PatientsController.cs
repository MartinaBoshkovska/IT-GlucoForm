using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlucoForm.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GlucoForm.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Patient"))
            {
                 return RedirectToAction("Index", "Home");
            }
            return View(db.Patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            PatientViewModel viewModel = new PatientViewModel();
            if (patient == null)
            {
                return HttpNotFound();
            }
            viewModel.patient = patient;
            viewModel.MyReports = db.Reports.Where(m => m.PatientId == patient.Id).ToList();
            
            return View(viewModel);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            PatientViewModel vm = new PatientViewModel();
            return View(vm);
        }

        //[Bind(Include = "Id,Name,Surname,DateOfBirth,Gender,Email,TelephoneNumber,Weight,Height,DateOfInclusionInTheStudy,profession")] 
        //POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var store = new UserStore<ApplicationUser>(db);
                var user = new ApplicationUser { UserName = model.patient.Email, Email = model.patient.Email };
                var manager = new UserManager<ApplicationUser, string>(store);
                var result = manager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    model.patient.UserId = user.Id;
                    db.Patients.Add(model.patient);
                    manager.AddToRole(user.Id, "Patient");
                    db.SaveChanges();
                    TempData["message"] = "The user with username: " + model.patient.Email + "has been created. Please edit the user's profile";
                    return RedirectToAction("Edit", new { id = model.patient.Id });
                }
                //else
                //{
                //    throw new ApplicationException("Unable to create a user.");
                //}
                AddErrors(result);

            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if(TempData["message"]!= null)
                ViewBag.Message = TempData["message"].ToString();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Patients", new { id = patient.Id});
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
