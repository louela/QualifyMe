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
    public interface ISkillService
    {
        void InsertSkill(AddSkillView ass);

        //List<StudentSkillSetView> GetSkillsByUserID (int UserId);
        StudentSkillSetView GetStudentsBySkillName(string SkillName);
        List<StudentSkillSetView> GetSkills();


    }


    public class SkillService : ISkillService
    {
        ISkillRepository sr;

        public SkillService()
        {
            sr = new SkillRepository();
        }
      public void InsertSkill(AddSkillView ass)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AddSkillView, StudentSkillSet>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            StudentSkillSet s = mapper.Map<AddSkillView, StudentSkillSet>(ass);
            sr.InsertSkill(s);
        }

        //public List<StudentSkillSetView> GetSkillsByUserID(int UserID)
        //{
        //    List<StudentSkillSet> sss = sr.GetSkillsByUserID(UserID);
        //    var config = new MapperConfiguration(cfg => { cfg.CreateMap<StudentSkillSet,StudentSkillSetView(); cfg.IgnoreUnmapped(); });
        //    IMapper mapper = config.CreateMapper();
        //    List<StudentSkillSetView> ss = mapper.Map<List<StudentSkillSet>, List<StudentSkillSetView>>(sss);
        //    return ss;


        //}

        public StudentSkillSetView GetStudentsBySkillName(string SkillName)
        { StudentSkillSet s = sr.GetStudentSkillSetsBySkillName(SkillName).FirstOrDefault();
            StudentSkillSetView cvm = null; if (s != null)
            { var config = new MapperConfiguration(cfg => 
            { cfg.CreateMap<StudentSkillSet, StudentSkillSetView>(); 
                cfg.IgnoreUnmapped(); }); IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<StudentSkillSet, StudentSkillSetView>(s); 
            } 
            return cvm; }

        public List<StudentSkillSetView> GetSkills()
        {
            List<StudentSkillSet> s = sr.GetSkills();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<StudentSkillSet, StudentSkillSetView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<StudentSkillSetView> sssv = mapper.Map<List<StudentSkillSet>, List<StudentSkillSetView>>(s);
            return sssv;
        }
    }


}
