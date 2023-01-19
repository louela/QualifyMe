using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Q.DomainModels;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Controllers
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
        // GET: Jobs
        public ActionResult View(int id)
        {

            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            JobView jv = this.js.GetJobByJobID(id);

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
        public ActionResult ApplyJob(NewApplicant na, int JobID/*,int ApplicantID*/)
        {
            if (ModelState.IsValid)
            {
                na.ApplicantDateAndTime = DateTime.Now;
                na.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                // int id = 
                // this.asr.GetApplicantByApplicantID(ApplicantID);
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

        //public ActionResult RecommendedJobs()
        //{

        //    using (QualifyMeDbContext db = new QualifyMeDbContext())
        //    {
        //        int uid = Convert.ToInt32(Session["CurrentUserID"]);
        //        List<Applicant> applicants = db.Applicants.ToList();
        //        List<Course> courses = db.Courses.ToList();
        //        List<Job> jobs = db.Jobs.ToList();
        //        List<Student> students = db.Students.ToList();
        //        List<Department> departments = db.Departments.ToList();
        //        List<Company> companies = db.Companies.ToList();

        //        var recommendedjobs = from s in students
        //                              join c in courses on s.CourseID equals c.CourseID into Courses
        //                              from c in Courses.ToList()
        //                              join j in jobs on c.CourseID equals j.CourseID into Jobs
        //                              from j in Jobs.ToList()
        //                              join d in departments on j.CourseID equals d.DepartmentID into Departments
        //                              from d in Departments.ToList()
        //                              join cmp in companies on j.CompanyID equals cmp.CompanyID into Companies
        //                              from cmp in companies.ToList()
        //                              where s.UserID == uid && s.CourseID == j.CourseID && j.CompanyID == cmp.CompanyID
        //                              select new Model
        //                              {
        //                                  department = d,
        //                                  student = s,
        //                                  job = j,
        //                                  course = c,
        //                                  company = cmp

        //                              };





        //        return View(recommendedjobs);
        //    }

        //}

        //// GET: Home
        //[HttpGet]
        //public ActionResult Upload()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Upload(Employee employee)
        //{
        //    using (QualifyMeEntities2 entity = new QualifyMeEntities2())
        //    {
        //        var candidate = new Candidate()
        //        {
        //            ContactNo = employee.ContactNo,
        //            EmailID = employee.EmailID,
        //            FirstName = employee.FirstName,
        //            LastName = employee.LastName,
        //            Position = employee.Position,
        //            Resume = SaveToPhysicalLocation(employee.Resume),
        //            Skills = employee.Skills,
        //            CreatedOn = DateTime.Now
        //        };
        //        entity.Candidates.Add(candidate);
        //        entity.SaveChanges();
        //    }
        //    return View(employee);
        //}


        //private string SaveToPhysicalLocation(HttpPostedFileBase file)
        //{
        //    if (file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
        //        file.SaveAs(path);
        //        return path;
        //    }
        //    return string.Empty;
        //}

    }
}