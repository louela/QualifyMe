using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.CustomFilters;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Controllers
{
    public class AccountController : Controller
    {
        private IStudentsService ss;
        private ICompaniesService cs;

        public AccountController(StudentsService ss, CompaniesService cs)
        {
            this.ss = ss;
            this.cs = cs;
        }

        // GET: Account


        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(StudentRegister rvm)
         {
            if (ModelState.IsValid)
            {
                int uid = this.ss.InsertStudent(rvm);
                Session["CurrentUserID"] = uid;
                Session["CurrentStudentID"] = rvm.StudentID;
                Session["CurrentUserName"] = rvm.StudentName;
                Session["CurrentUserEmail"] = rvm.Email;
                Session["CurrentUserPassword"] = rvm.Password;
                Session["CurrentUserIsAdmin"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }

        }

        public ActionResult Login()
        {
            LoginView lvm = new LoginView();
            return View(lvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginView lvm)
        {
            if (ModelState.IsValid)
            {
                StudentView uvm = this.ss.GetStudentsByEmailAndPassword(lvm.Email, lvm.Password);
                if (uvm != null)
                {
                    Session["CurrentUserID"] = uvm.UserID;
                    Session["CurrentStudentID"] = uvm.StudentID;
                    Session["CurrentUserName"] = uvm.StudentName;
                    Session["CurrentUserEmail"] = uvm.Email;
                    Session["CurrentUserMobile"] = uvm.StudentMobile;
                    Session["CurrentUserPassword"] = uvm.Password;
                    Session["CurrentUserIsAdmin"] = uvm.IsAdmin;

                    if (uvm.IsAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });


                    }
                    else
                        return RedirectToAction("Homepage", "Home");
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Email / Password");
                    return View(lvm);
                }

            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(lvm);
            }


        }

        public ActionResult CompanyLogin()
        {
            CompanyLoginView cvm = new CompanyLoginView();
            return View(cvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyLogin(CompanyLoginView clm)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                CompanyView cvm = this.cs.GetCompaniesByEmailAndPassword(clm.Email, clm.Password);
                if (cvm != null)
                {
                    Session["CurrentCompanyID"] = cvm.CompanyID;
                    Session["CurrentCompanyName"] = cvm.CompanyName;
                    Session["CurrentCompanyEmail"] = cvm.Email;
                    Session["CurrentCompanyPassword"] = cvm.Password;
                    Session["CurrentCompanyMobile"] = cvm.CompanyMobile;
                    Session["CurrentCompanyAddress"] = cvm.CompanyAddress;
                    Session["CurrentCompanyDescription"] = cvm.CompanyDescription;
                    Session["CurrentCompanyIsApproved"] = 0;
                    Session["CurrentUserIsAdmin"] = cvm.IsAdmin;

                    if (cvm.IsAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });


                    }
                    else
                    {
                        if (cvm.IsApproved == 0)
                        {
                            return RedirectToAction("Message", "Account", new { msg = "AccountNotVerified"});
                        }
                        else if (cvm.IsApproved == 1)
                        {
                            return RedirectToAction("Index", "Home", new { area = "Company" });
                        }

                        return RedirectToAction("CompanyLogin", "Account");

                    }

                   
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Email / Password");
                    return View(clm);
                }

            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(clm);
            }
        }

       

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [UserAuthorizationFilterAttribute]
        
        public ActionResult ChangeProfile()
        {

            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            StudentView uvm = this.ss.GetStudentsByUserID(uid);
            EditStudent es = new EditStudent() { StudentName = uvm.StudentName, StudentMobile = uvm.StudentMobile, Email = uvm.Email, UserID = uvm.UserID, StudentID = uvm.StudentID };
            return View(es);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilterAttribute]
        public ActionResult ChangeProfile(EditStudent es)
        {
            if (ModelState.IsValid)
            {
                es.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.ss.UpdateStudentDetails(es);
                Session["CurrentUserName"] = es.StudentName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View(es);
            }
        }

        [UserAuthorizationFilterAttribute]
        public ActionResult Profile()
        {
            StudentView uvm = new StudentView();
            return View();
        }

    
        public ActionResult CompanyRegister()
        {

            CompanyRegister acm = new CompanyRegister();
            return View(acm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult CompanyRegister(CompanyRegister acm)
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
                Session["CurrentCompanyIsApproved"] = 0;
                Session["CurrentCompanyIsAdmin"] = false;
                return RedirectToAction("Index", "Home" , new { area = "Company" });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }
        }


        public ActionResult Message()
        {
            return View();
        }


    }
}