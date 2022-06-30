using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class CompanyView
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyMobile { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyDescription { get; set; }
        public bool IsAdmin { get; set; }
    }
}
