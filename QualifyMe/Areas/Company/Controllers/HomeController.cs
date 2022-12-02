using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Company.Controllers
{
    public class HomeController : Controller
    {
        IJobsService js;
        ICoursesService cs;
        ICompaniesService com;
        IJobsService job;

        public HomeController(IJobsService js, ICoursesService cs, ICompaniesService com, IJobsService job)
        {
            this.js = js;
            this.cs = cs;
            this.com = com;
            this.job = job;
        }

        public ActionResult Index()
        {
            List<JobView> jobs = this.js.GetJobs().Take(10).ToList();
            return View(jobs);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Courses()
        {
            List<CourseView> courses = this.cs.GetCourses().Take(10).ToList();
            return View(courses);
        }

       

        public ActionResult Jobs()
        {
            int cid = Convert.ToInt32(Session["CurrentCompanyID"]);
            List<JobView> jvm = this.js.GetJobsByCompanyID(cid);
            return View(jvm);
        }
    }
}