using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Controllers
{
    public class HomeController : Controller
    {
        IJobsService js;
        ICoursesService cs;
        ICompaniesService com;
        private IJobsService job;
        public HomeController(IJobsService js, ICoursesService cs, ICompaniesService com, IJobsService job)
        {
            this.js = js;
            this.cs = cs;
            this.com = com;
            this.job = job;
        }
        // GET: Home
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

        public ActionResult Companies()
        {
            List<CompanyView> companies = this.com.GetCompanies().Take(10).ToList();
            return View(companies);
        }

        public ActionResult Jobs()
        {
            List<JobView> jobs = this.job.GetJobs().Take(10).ToList();
            return View(jobs);
        }
    }
}