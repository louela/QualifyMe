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
        [Required]
        public int DepartmentID { get; set; }

        [Required]
        public string DepartmentName { get; set; }

      
    }
}
