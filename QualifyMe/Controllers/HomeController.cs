using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Q.DomainModels;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Controllers
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

        

        public ActionResult RecommendedJobs()
        {
            List<JobView> jobs = this.job.GetJobs().Take(10).ToList();
            return View(jobs);
        }
        [Route("myapplications")]
        public ActionResult MyApplications()
        {
            using (QualifyMeDbContext db = new QualifyMeDbContext())
            {
                int cid = Convert.ToInt32(Session["CurrentUserID"]);
                List<Student> students = db.Students.ToList();
                List<Applicant> applicants = db.Applicants.ToList();
                List<Job> jobs = db.Jobs.ToList();
                List<Company> companies = db.Companies.ToList();

                

                var AppliedJobsList = from a in applicants
                                      join s in students on a.UserID equals s.UserID into Applicants
                                      from s in Applicants.ToList()
                                      join j in jobs on a.JobID equals j.JobID into Jobs
                                      from j in Jobs.ToList()
                                      join c in companies on j.CompanyID equals c.CompanyID into Companies
                                      from c in Companies.ToList()
                                      where s.UserID == cid && j.JobID == a.JobID
                                      select new Model
                                      {
                                          applicant = a,
                                          student = s,
                                          job = j,
                                          company = c
                                      };
                return View(AppliedJobsList);
            }
        }

        public ActionResult Homepage()
        {
            List<JobView> jobs = this.js.GetJobs().Take(10).ToList();
            return View(jobs);
        }


    }
}