using AutoMapper;
using Q.DomainModels;
using QualifyMe.Repositories;
using QualifyMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMe.ServiceLayer
{
    public interface IStudentsDetailService
    {
        StudentDetailsView GetStudentsByUserID(int UserID);
        void UpdateStudentDetails(StudentDetailsView sdv);
    }
    public class StudentsDetailService: IStudentsDetailService
    {
        IStudentsDetailRepository usr;

        public void UpdateStudentDetails(StudentDetailsView sdv)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<StudentDetailsView,StudentDetail>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            StudentDetail sd = mapper.Map<StudentDetailsView, StudentDetail>(sdv);
            usr.UpdateStudentDetails(sd);
        }

        public StudentDetailsView GetStudentsByUserID(int UserID)
        {
            StudentDetail u = usr.GetStudentsByUserID(UserID).FirstOrDefault();
            StudentDetailsView uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<StudentDetail, StudentDetailsView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<StudentDetail, StudentDetailsView>(u);
            }
            return uvm;
        }
    }

}



