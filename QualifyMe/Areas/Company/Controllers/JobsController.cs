using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Company.Controllers
{
    public class JobsController : Controller
    {
        IJobsService js;
        IApplicantsService asr;
        ICoursesService cs;

        public JobsController(IJobsService js, IApplicantsService asr, ICoursesService cs)
        {
            this.js = js;
            this.asr = asr;
            this.cs = cs;
        }

        public ActionResult Create()
        {
            List<CourseView> courses = this.cs.GetCourses();
            ViewBag.courses = courses;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(NewJob qvm)
        {
            if (ModelState.IsValid)
            {
                qvm.ApplicantsCount = 0;

                qvm.JobDateAndTime = DateTime.Now;
                qvm.CompanyID = Convert.ToInt32(Session["CurrentCompanyID"]);
                this.js.InsertJob(qvm);
                return RedirectToAction("Jobs", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }

        public ActionResult View(int id)
        {
           
            int uid = Convert.ToInt32(Session["CurrentCompanyID"]);
            JobView qvm = this.js.GetJobByJobID(id);
            return View(qvm);
        }

        public ActionResult CreateJob()
        {
            return View();
        }
    }
}