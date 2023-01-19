using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class AddTagView
    {
        [RegularExpression(@"^[a-zA-Z ]*$")]
        [Required]
        public string TagName { get; set; }
        [Required]
        public int JobID { get; set; }
    }
}
