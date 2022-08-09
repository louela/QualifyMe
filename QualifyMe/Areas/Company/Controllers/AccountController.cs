using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QualifyMe.CustomFilters;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Company.Controllers
{
    public class AccountController : Controller
    {
        
        private ICompaniesService cs;

        public AccountController( CompaniesService cs)
        {
        
            this.cs = cs;
        }

        // GET: Company/Account
        
        public ActionResult Profile()
        {
            CompanyView cvm = new CompanyView();
            return View();
        }

     

        public ActionResult ChangeProfile()
        {

            int uid = Convert.ToInt32(Session["CurrentCompanyID"]);
            //CompanyView uvm = this.cs.GetCompaniesByCompanyID(uid);
            //EditCompany ec = new EditCompany() { CompanyName = uvm.CompanyName, CompanyMobile = uvm.CompanyMobile, Email = uvm.Email, CompanyAddress = uvm.CompanyAddress, CompanyDescription = uvm.CompanyDescription, CompanyID = uvm.CompanyID};
            return View();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CompanyAuthorizationFilter]
        public ActionResult ChangeProfile(EditCompany es)
        {
            if (ModelState.IsValid)
            {
                es.CompanyID = Convert.ToInt32(Session["CurrentCompanyID"]);
                this.cs.UpdateCompanyDetails(es);
                Session["CurrentCompanyName"] = es.CompanyName;
                Session["CurrentCompanyMobile"] = es.CompanyMobile;
                Session["CurrentCompanyAddress"] = es.CompanyAddress;
                Session["CurrentCompanyDescription"] = es.CompanyDescription;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View(es);
            }
        }

    }
}