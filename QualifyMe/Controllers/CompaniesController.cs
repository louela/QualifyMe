using Q.DomainModels;
using QualifyMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;

namespace QualifyMe.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: Companies
        ICompaniesService cs;
        IJobsService js;

        public CompaniesController(ICompaniesService cs,IJobsService js)
        {
           this.cs = cs;
            this.js = js;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProfile(int id)
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            CompanyView cv = this.cs.GetCompaniesByCompanyID(id);
            List<JobView> jv = this.js.GetJobsByCompanyID(id);
            return View(cv);
        }
    }
}