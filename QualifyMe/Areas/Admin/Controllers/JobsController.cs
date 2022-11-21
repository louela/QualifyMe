using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Admin.Controllers
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
        // GET: Admin/Jobs
        public ActionResult View(int id)
        {
           
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            JobView qvm = this.js.GetJobByJobID(id);
            return View(qvm);
        }
    }
}