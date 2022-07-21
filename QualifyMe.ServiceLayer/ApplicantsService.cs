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
    public interface IApplicantsService
    {
        int InsertApplicant(NewApplicant avm);
        void DeleteApplicant(int aid);
        List<ApplicantView> GetApplicantsByJobID(int jid);
        ApplicantView GetApplicantByApplicantID(int ApplicantID);
        //ApplicantView GetJobByApplicantID(int ApplicantID, int UserID, int jobID);

        //int GetLatestJobID(int JobID);
        //void UpdateApplicantsCount(int aid,int value);
      
    }
    public class ApplicantsService : IApplicantsService
    {
        IApplicantsRepository ar;

        public ApplicantsService()
        {
            ar = new ApplicantsRepository();
        }
        public int InsertApplicant(NewApplicant avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewApplicant, Applicant>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Applicant a = mapper.Map<NewApplicant, Applicant>(avm);
            ar.InsertApplicant(a);
            int aid = ar.GetLatestApplicantID();
            return aid;
        }

        public void DeleteApplicant(int aid)
        {
            ar.DeleteApplicant(aid);
        }

        public List<ApplicantView> GetApplicantsByJobID(int jid)
        {
            List<Applicant> a = ar.GetApplicantsByJobID(jid);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant,ApplicantView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<ApplicantView> avm = mapper.Map<List<Applicant>, List<ApplicantView>>(a);
            return avm;
        }

        public ApplicantView GetApplicantByApplicantID(int ApplicantID)
        {
            Applicant a = ar.GetApplicantsByApplicantID(ApplicantID).FirstOrDefault();
            ApplicantView avm = null;
            if (a != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant, ApplicantView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                avm = mapper.Map<Applicant, ApplicantView>(a);
            }
            return avm;
        }

       
        //public void UpdateApplicantsCount(int aid,int value)
        //{
        //    ar.UpdateApplicantsCount(aid,value);
        //}

        //public ApplicantView GetLatestJobID(int JobID)
        //{
        //    Applicant a = ar.GetLatestJobID(JobID).FirstOrDefault();
        //    ApplicantView av = null;
        //    if (a != null)
        //    {
        //        var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant, ApplicantView>(); cfg.IgnoreUnmapped(); });
        //        IMapper mapper = config.CreateMapper();
        //        av = mapper.Map<Applicant, ApplicantView>(a);
        //    }
        //    return av;
        //}

        //public ApplicantView GetJobByApplicantID (int ApplicantID,int UserID, int JobID )
        //{
        //    Applicant a = ar.GetJobByApplicantID(JobID,UserID).FirstOrDefault();
        //    ApplicantView av = null;
        //    if( a != null)
        //    {
        //        var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applicant, ApplicantView>(); cfg.IgnoreUnmapped(); });
        //        IMapper mapper= config.CreateMapper();
        //        av = mapper.Map<Applicant, ApplicantView>(a);

        //    }
        //    return av;
        //}



    }
}
