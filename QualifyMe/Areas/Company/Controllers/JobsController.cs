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
    public class JobsController : Controller
    {
        IJobsService js;
        IApplicantsService asr;
        ICoursesService cs;
        IDepartmentsService ds;

        public JobsController(IJobsService js, IApplicantsService asr, ICoursesService cs, IDepartmentsService ds)
        {
            this.js = js;
            this.asr = asr;
            this.cs = cs;
            this.ds = ds;
        }

        public ActionResult Create()
        {
            List<DepartmentView> departments = this.ds.GetDepartments();
            ViewBag.Departments = departments;
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
                Session["CurretJobTypes"] = qvm.JobTypes;
                Session["CurrentJobStatus"] = qvm.JobStatus;
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
           
           // int uid = Convert.ToInt32(Session["CurrentCompanyID"]);
            JobView qvm = this.js.GetJobByJobID(id/*, uid*/);
            return View(qvm);
        }

      
        public ActionResult CreateJob()
        {
            return View();
        }

        //public ActionResult Applicants()
        //{

        //    int jid = Convert.ToInt32(Session["CurrentJobID"]);
        //   // List<ApplicantView> applicants = this.asr.GetApplicantsByJobID(jid);
        //    List<ApplicantView> applicants = this.asr.GetApplicantsByCompanyID(jid);
        //    return View(applicants);
        //    // this.js.GetJobByJobID(jid/*, uid*/);
        //    //using (QualifyMeDbContext db = new QualifyMeDbContext())
        //    //{
        //    //    //int jid = Convert.ToInt32(Session["CurrentJobID"]);
        //    //    List<Student> students = db.Students.ToList();
        //    //    List<Applicant> applicants = db.Applicants.ToList();
        //    //    List<Job> jobs = db.Jobs.ToList();
        //    //   // List<Company> companies = db.Companies.ToList();

        //    //    var AppliedJobsList = from a in applicants
        //    //                          join s in students on a.UserID equals s.UserID into Applicants
        //    //                          from s in Applicants.ToList()
        //    //                          join j in jobs on a.JobID equals j.JobID into Jobs
        //    //                          from j in Jobs.ToList()
        //    //                          where j.JobID == jid
        //    //                        //  join c in companies on j.CompanyID equals c.CompanyID into Companies
        //    //                        //  from c in Companies.ToList()
        //    //                          select new Model
        //    //                          {
        //    //                              applicant = a,
        //    //                              student = s,
        //    //                              job = j,
        //    //                          //    company = c
        //    //                          };
        //    //    return View(AppliedJobsList);

        //    //}
        //}
    }
}