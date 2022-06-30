using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Admin.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: Admin/Companies
        private ICompaniesService cs;
        public CompaniesController(ICompaniesService cs)
        {
            this.cs = cs;
        }
        public ActionResult AddCompany()
        {

            CompanyRegister acm = new CompanyRegister();
            return View(acm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCompany(CompanyRegister acm)
        {


            if (ModelState.IsValid)
            {
                int cid = this.cs.InsertCompany(acm);
                Session["CurrentCompanyID"] = cid;
                Session["CurrentCompanyName"] = acm.CompanyName;
                Session["CurrentCompanyEmail"] = acm.Email;
                Session["CurrentCompanyPassword"] = acm.Password;
                Session["CurrentCompanyAddress"] = acm.CompanyAddress;
                Session["CurrentCompanyDescription"] = acm.CompanyDescription;
                Session["CurrentCompanyIsAdmin"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }
        }
    }
}