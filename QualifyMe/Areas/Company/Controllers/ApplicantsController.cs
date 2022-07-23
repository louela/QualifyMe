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
            //int uid = Convert.ToInt32(Session["CurrentCompanyID"]); 
            JobView jb = this.js.GetJobByJobID(id/*,uid*/);
            
            return View(jb);
        }
    }
    }
