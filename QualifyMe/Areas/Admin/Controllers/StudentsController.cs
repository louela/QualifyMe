using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Admin/Students
        private IStudentsService st;
        public StudentsController (IStudentsService st)
        {
           this.st = st;
        }

        public ActionResult EditStudentStatus(int id)
        {

            StudentView uvm = this.st.GetStudentsByUserID(id);
            EditStudentStatusView eudvm = new EditStudentStatusView() { StudentFirstName = uvm.StudentFirstName,StudentLastName = uvm.StudentLastName, Email = uvm.Email, IsApproved = uvm.IsApproved,StudentID = uvm.StudentID,UserID = uvm.UserID };
            return View(eudvm);

        }




        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EditStudentStatus(EditStudentStatusView ecm)
        {


            if (ModelState.IsValid)
            {

                this.st.UpdateStudentStatus(ecm);
                Session["CurrentStudentFirstName"] = ecm.StudentFirstName;
                Session["CurrentStudentLastName"] = ecm.StudentLastName; 
                Session["CurrentStudentEmail"] = ecm.Email;
                Session["CurrentStudentIsApproved"] = ecm.IsApproved;
                return RedirectToAction("Students", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View(ecm);
            }


        }
    }
}