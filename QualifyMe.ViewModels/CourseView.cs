using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class CourseView
    {
       
        public int CourseID { get; set; }
        
        public int DepartmentID { get; set; }
        
        public string CourseName { get; set; }

       
    }
}
