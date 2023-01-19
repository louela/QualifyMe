using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.DomainModels
{
    public class SkillTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillTagID { get; set; }
        public int SkillID { get; set; }
        public int TagID { get; set; }


        [ForeignKey("SkillID")]
        public virtual StudentSkillSet StudentSkillSet { get; set; }
        [ForeignKey("TagID")]
        public virtual Tag Tag { get; set; }
    }
}
