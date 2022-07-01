using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualifyMe.CustomFilters
{
    public class CompanyAuthorizationFilterAttribute :FilterAttribute , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Session["CurrentCompanyName"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "Company", controller = "Home", action = "Index" }));
            }
        }
    }
}