using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class EditJob
    {
        [Required]
        public int JobID { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public DateTime JobDateAndTime { get; set; }

        [Required]
        public int CourseID { get; set; }
    }
}
