using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Controllers
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
        // GET: Jobs
        public ActionResult View(int id)
        {
            //this.js.UpdateApplicantsCount(id, 1);
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            JobView jv = this.js.GetJobByJobID(id, uid);
            List<CourseView> courses = this.cs.GetCourses();
            ViewBag.courses = courses;
            return View(jv);
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
                int jid = this.js.InsertJob(qvm);
                //this.js.InsertJob(qvm);
                return RedirectToAction("Jobs", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }

        //public ActionResult ApplyJob(int id)
        //{
        //    int uid = Convert.ToInt32(Session["CurrentUserID"]);
        //    this.js.GetJobByJobID(id, uid);
        //    JobView jb = this.c(uid);
        //    List<CourseView> courses = this.cs.GetCourses();
        //    ViewBag.courses = courses;  
        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyJob(NewApplicant na,int JobID,int ApplicantID)
        {
            if (ModelState.IsValid)
            {
               
                na.ApplicantDateAndTime = DateTime.Now;
                na.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                // int id = 
                this.asr.GetApplicantByApplicantID(ApplicantID);
                this.asr.InsertApplicant(na);
                this.js.UpdateApplicantsCount(JobID, 1);
                return RedirectToAction("ApplicationMessage", "Jobs");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }

        public ActionResult ApplicationMessage()
        {
            return View();
        }
            
            
            
    }
}