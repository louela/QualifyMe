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

        //AddSkill GetSkillByUserID (int userId);
        
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

      //public AddSkill GetSkillByUserID(int UserID)
      //  {
      //      SkillSet s = sr.GetSkillByUserID(UserID).FirstOrDefault();
      //      AddSkill skv = null;
      //      if(s != null)
      //      {
      //          var config = new MapperConfiguration(cfg => { cfg.CreateMap<SkillSet, AddSkill>(); cfg.IgnoreUnmapped(); });
      //          IMapper mapper = config.CreateMapper();
      //          skv = mapper.Map<SkillSet, AddSkill>(s);
      //      }
      //      return skv;
      //  } 
   

    }

   
}
