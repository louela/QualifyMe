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
        IDepartmentsService ds;

        public JobsController(IJobsService js, IApplicantsService asr, ICoursesService cs,IDepartmentsService ds)
        {
            this.js = js;
            this.asr = asr;
            this.cs = cs;
            this.ds = ds;
        }

        public ActionResult Create()
        {
            List<CourseView> courses = this.cs.GetCourses();
            ViewBag.courses = courses;
            List<DepartmentView> departments = this.ds.GetDepartments();
            ViewBag.departments = departments;
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
                int jid = js.InsertJob(qvm);
                Session["CurrentJobID"] = jid;
                Session["CurrentJobTitle"] = qvm.JobTitle;
                Session["CurrentJobDescription"] = qvm.JobDescription;
                Session["JobCurrentQualification"] = qvm.JobQualification;
                Session["CurrentJobTypes"] = qvm.JobTypes;
                Session["CurrentJobStatus"] = qvm.JobStatus;
                return RedirectToAction("AddTag", "Tags");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }

        public ActionResult View(int id)
        {

        
            JobView qvm = this.js.GetJobByJobID(id);
            return View(qvm);
        }

        public ActionResult CreateJob()
        {
            return View();
        }
    }
}
