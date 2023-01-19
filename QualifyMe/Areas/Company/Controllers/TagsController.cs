using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Areas.Company.Controllers
{
    public class TagsController : Controller
    {
        // GET: Company/Tags
        private ITagsService ts;

        public TagsController(ITagsService ts)
        {
            this.ts = ts;
        }
        public ActionResult AddTag()
        {
            AddTagView acm = new AddTagView();
            return View(acm);
        }

       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTag(AddTagView acm)
        {
            {
                if (ModelState.IsValid)
                {
                    acm.JobID = Convert.ToInt32(Session["CurrentJobID"]);
                    Session["CurrentTagName"] = acm.TagName;
                    this.ts.InsertTag(acm);
                    ViewData["Message"] = "The last record inserted is " + acm.JobID;
                    return RedirectToAction("AddTag", "Tags", new { id = acm.JobID }
                    );
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Data");
                    return View();
                }
            }
        }
    }
}


//public ActionResult AddTag(AddTagView acm)
//{
//    if (ModelState.IsValid)
//    {
//        acm.JobID = Convert.ToInt32(Session["CurrentJobID"]); 
//        Session["CurrentTagName"] = acm.TagName; 
//        this.ts.InsertTag(acm); 
//        ViewData["Message"] = "The last record inserted is " + acm.JobID; 
//        return RedirectToAction("AddTag", "Tags", new { id = acm.JobID }
//        );
//    } 
//    else
//    { ModelState.AddModelError("x", "Invalid Data");
//        return View(); }
//}