                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.DomainModels;

namespace QualifyMe.Repositories
{
    public interface IStudentsDetailRepository
    {
        void UpdateStudentDetails(StudentDetail s);
        List<StudentDetail> GetStudentsByUserID(int UserID);
    }
    public class StudentsDetailRepository: IStudentsDetailRepository
    {
        QualifyMeDbContext db;
        public void UpdateStudentDetails(StudentDetail s)
        {
            StudentDetail sd = db.StudentDetails.Where(temp => temp.UserID == s.UserID).FirstOrDefault();
            if (sd != null)
            {
                sd.StudentGender = s.StudentGender;
                sd.StudentAddress = s.StudentAddress;
                sd.StudentBirthday = s.StudentBirthday;
                sd.StudentMobile = s.StudentMobile;
                // st.StudentMobile = s.StudentMobile;

                db.SaveChanges();
            }
        }

        public List<StudentDetail> GetStudentsByUserID(int UserID)
        {
            List<StudentDetail> st = db.StudentDetails.Where(temp => temp.UserID == UserID).ToList();
            return st;
        }
    }

 
}
