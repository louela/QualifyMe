using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            List<JobView> applicants = this.js.GetApplicantsByJobID(id).Take(10).ToList();
            return View(applicants);
        }
    }
    }
