using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Admin.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentsService dos;
        private ICoursesService cos;

        public DepartmentsController(IDepartmentsService dos , ICoursesService cos)
        {
            this.dos = dos;
            this.cos = cos;
        }
        // GET: Admin/Departments
        public ActionResult AddDepartment()
        {

            AddDepartmentView dcm = new AddDepartmentView();
            return View(dcm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(AddDepartmentView dcm)
        {

            if (ModelState.IsValid)
            {



                int did = this.dos.InsertDepartment(dcm);
                Session["CurrentDepartmentID"] = did;
                Session["CurrentDepartmentName"] = dcm.DepartmentName;

                return RedirectToAction("Departments", "Home", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }
        }

        public ActionResult ViewDepartment(int id )
        {

            
            DepartmentView qvm = this.dos.GetDepartmentByDepartmentID(id);
            return View(qvm);
        }


        public ActionResult AddCourse(AddCourseView navm)
        {
            
            if (ModelState.IsValid)
            {
                this.cos.InsertCourse(navm);
                return RedirectToAction("ViewDepartment", "Departments", new { id = navm.DepartmentID });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                
                return View("ViewDepartment");
            }
        }



        public ActionResult DeleteDepartment(int did)
        {
            
            return View();
        }
    }
}

