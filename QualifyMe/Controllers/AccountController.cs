using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                Session["CurrentStudentName"] = rvm.StudentName;
                Session["CurrentStudentEmail"] = rvm.Email;
                Session["CurrentStudentPassword"] = rvm.Password;
                Session["CurrentStudentIsAdmin"] = false;
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
                    Session["CurrentStudentName"] = uvm.StudentName;
                    Session["CurrentStudentEmail"] = uvm.Email;
                    Session["CurrentStudentMobile"] = uvm.StudentMobile;
                    Session["CurrentStudentPassword"] = uvm.Password;
                    Session["CurrentStudentIsAdmin"] = uvm.IsAdmin;

                    if (uvm.IsAdmin)
                    {
                        return RedirectToRoute(new { controller = "Home", action = "Index" });


                    }
                    else
                        return RedirectToAction("Index", "Home");
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
                    Session["CurrentUserIsAdmin"] = cvm.IsAdmin;

                    if (cvm.IsAdmin)
                    {
                        return RedirectToRoute(new { controller = "Home", action = "Index" });


                    }
                    else
                        return RedirectToAction("Index", "Home");
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

        public ActionResult ChangeProfile()
        {

            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            StudentView uvm = this.ss.GetStudentsByUserID(uid);
            EditStudent eudvm = new EditStudent() { StudentName = uvm.StudentName, StudentMobile = uvm.StudentMobile, Email = uvm.Email, UserID = uvm.UserID, StudentID = uvm.StudentID };
            return View(eudvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult ChangeProfile(EditStudent eudvm)
        {
            if (ModelState.IsValid)
            {
                eudvm.UserID = Convert.ToInt32(Session["CurrentStudentID"]);
                this.ss.UpdateStudentDetails(eudvm);
                Session["CurrentStudentName"] = eudvm.StudentName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View(eudvm);
            }
        }

        public ActionResult Profile()
        {
            StudentView uvm = new StudentView();
            return View();
        }

      


    }
}