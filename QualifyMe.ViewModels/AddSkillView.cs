using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class AddSkillView
    {
        [RegularExpression(@"^[a-zA-Z ]*$")]
        [Required]
        public string SkillName { get; set; }

        public int UserID { get; set; }

    }
}
