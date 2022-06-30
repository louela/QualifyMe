using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QualifyMe.ServiceLayer;

namespace QualifyMe.ApiControllers
{
    public class AccountController : ApiController
    {
        IStudentsService ss;

        public AccountController(IStudentsService ss)
        {
            this.ss = ss;
        }
        public string Get(string Email)
        {
            if (this.ss.GetStudentsByEmail(Email) != null)
            {
                return "Found";
            }
            else
            {
                return "Not Found";
            }
        }
    }
}
