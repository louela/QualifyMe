using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {
        private ICoursesService cos;

        public CoursesController(ICoursesService cos)
        {
            this.cos = cos;
        }

        // GET: Admin/Courses
        public ActionResult AddCourse()
        {
            AddCourseView acm = new AddCourseView();
            return View(acm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(AddCourseView acm)
        {
            if (ModelState.IsValid)
            {
                acm.DepartmentID = Convert.ToInt32(Session["CurrentDepartmentID"]);
                Session["CurrentCourseName"] = acm.CourseName;
                this.cos.InsertCourse(acm);
                return RedirectToAction("ViewDepartment", "Departments", new { id = acm.DepartmentID });
                
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }
        }
    }
}
