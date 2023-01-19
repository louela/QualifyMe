using Q.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ViewModels
{
    public class Model
    {
        public Applicant applicant { get; set; }
        public Student student { get; set; }
        public Job job { get; set; }
        public Company company { get; set; }
        public Department department { get; set; }
        public Course course { get; set; }
        public Tag tag { get; set; }
        public StudentSkillSet StudentSkillSet { get; set; }
        public SkillTag skilltag { get; set; }
    }
}
