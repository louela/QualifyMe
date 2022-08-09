using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Q.DomainModels;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Company.Controllers
{
    public class ApplicantsController : Controller
    {
        IApplicantsService asr;
        IJobsService js;
        // GET: Company/Applicants

        public ApplicantsController(IApplicantsService asr, IJobsService js)
        {
            this.asr = asr;
            this.js = js;
        }
        public ActionResult List(int id)
        {

            //List<ApplicantView> applicants = this.asr.GetApplicantsByJobID(id);
            //return View(applicants);
            using (QualifyMeDbContext db = new QualifyMeDbContext())
            {
                //int jid = Convert.ToInt32(Session["CurrentJobID"]);
                List<Student> students = db.Students.ToList();
                List<Applicant> applicants = db.Applicants.ToList();
                List<Job> jobs = db.Jobs.ToList();
                List<Course> courses = db.Courses.ToList();
                // List<Company> companies = db.Companies.ToList();

                var AppliedJobsList = from a in applicants
                                      join s in students on a.UserID equals s.UserID into Applicants
                                      from s in Applicants.ToList()
                                   
                                      join j in jobs on a.JobID equals j.JobID into Jobs
                                      from j in Jobs.ToList()
                                      where j.JobID == id
                                      //  join c in companies on j.CompanyID equals c.CompanyID into Companies
                                      //  from c in Companies.ToList()
                                      select new Model
                                      {
                                          applicant = a,
                                          student = s,
                                          job = j,
                                         //company = c
                                      };
                return View(AppliedJobsList);
            }
        }
    }
}
