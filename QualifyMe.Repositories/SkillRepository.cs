using Q.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.Repositories
{
    public interface ISkillRepository
    {
        void InsertSkill(StudentSkillSet s);

        List<StudentSkillSet> GetSkillByUserID(int UserID);
    }
    public class SkillRepository : ISkillRepository
    {
        QualifyMeDbContext db;
        public SkillRepository()
        {
            db = new QualifyMeDbContext();
           
        }
        public void InsertSkill(StudentSkillSet s)
        {          
            db.StudentSkillSets.Add(s);
            db.SaveChanges();
            
        }

        public List<StudentSkillSet> GetSkillByUserID(int UserID)
        {
            List<StudentSkillSet> sk = db.StudentSkillSets.Where(temp => temp.UserID == UserID).ToList();
            return sk;
        }
    }

  
}
