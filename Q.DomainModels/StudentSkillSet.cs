using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.DomainModels
{
    public class StudentSkillSet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillID { get; set; }
        public int UserID { get; set; }
        public string SkillName { get; set; }



        [ForeignKey("UserID")]
        public virtual Student Student { get; set; }
        //[ForeignKey("SkillSetID")]
        //public virtual StudentSkillSet studentSkillSet { get; set; }
    }
}
