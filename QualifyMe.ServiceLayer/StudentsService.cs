using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Q.DomainModels;
using QualifyMe.Repositories;
using QualifyMe.ViewModels;

namespace QualifyMe.ServiceLayer
{
    public interface IStudentsService
    {
        int InsertStudent(StudentRegister sr);
        void UpdateStudentDetails(EditStudent es);
      
        void UpdateStudentPassword(EditPassword ep);
        void DeleteStudent(int sid);
        //List<StudentView> GetStudents();
        StudentView GetStudentsByEmailAndPassword(string Email, string Password);
        StudentView GetStudentsByEmail(string Email);
        StudentView GetStudentsByUserID(int UserID);
    }
    public class StudentsService : IStudentsService
    {
        IStudentsRepository usr;

        public StudentsService()
        {
            usr = new StudentsRepository();
        }

        public int InsertStudent(StudentRegister sr)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<StudentRegister, Student>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Student s = mapper.Map<StudentRegister, Student>(sr);
            s.Password = SHA256HashGenerator.GenerateHash(sr.Password);
            usr.InsertStudent(s);
            int uid = usr.GetLatestStudentID();
            return uid;
        }

        public void UpdateStudentDetails(EditStudent es)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditStudent, Student>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Student s = mapper.Map<EditStudent, Student>(es);
            usr.UpdateStudentDetails(s);
        }
       
        public void UpdateStudentPassword(EditPassword ep)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditPassword, Student>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Student s = mapper.Map<EditPassword, Student>(ep);
            s.Password = SHA256HashGenerator.GenerateHash(ep.Password);
            usr.UpdateStudentPassword(s);
        }

        public void DeleteStudent(int sid)
        {
            usr.DeleteStudent(sid);
        }

        //public List<StudentView> GetStudents()
        //{
        //    List<Student> s = usr.GetStudents();
        //    var config = new MapperConfiguration(cfg => { cfg.CreateMap<Student, StudentView>(); cfg.IgnoreUnmapped(); });
        //    IMapper mapper = config.CreateMapper();
        //    List<StudentView> sv = mapper.Map<List<Student>, List<StudentView>>(s);
        //    return sv;
        //}

        public StudentView GetStudentsByEmailAndPassword(string Email, string Password)
        {
            Student s = usr.GetStudentsByEmailAndPassword(Email, SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            StudentView sv = null;
            if (s != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Student, StudentView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                sv = mapper.Map<Student, StudentView>(s);
            }
            return sv;
        }

        public StudentView GetStudentsByEmail(string Email)
        {
            Student s = usr.GetStudentsByEmail(Email).FirstOrDefault();
            StudentView sv = null;
            if (s != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Student, StudentView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                sv = mapper.Map<Student, StudentView>(s);
            }
            return sv;
        }

        public StudentView GetStudentsByUserID(int UserID)
        {
            Student u = usr.GetStudentsByUserID(UserID).FirstOrDefault();
            StudentView uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Student, StudentView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Student, StudentView>(u);
            }
            return uvm;
        }
    }
}
