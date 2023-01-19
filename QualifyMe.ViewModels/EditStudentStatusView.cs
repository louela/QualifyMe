using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class EditStudentStatusView
    {

        public int UserID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string StudentFirstName { get; set; }
        
        public string StudentLastName { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }
        [Required]
        public int IsApproved { get; set; }
    }
}
