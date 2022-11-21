using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class DepartmentView
    {
  
        public int DepartmentID { get; set; }
  
        public string DepartmentName { get; set; }
        public virtual List<CourseView> Courses { get; set; }

    }
}
