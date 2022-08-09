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
    public interface IJobsService
    {
        int InsertJob(NewJob qvm);
        void UpdateJobDetails(EditJob qvm);
        void UpdateApplicantsCount(int qid, int value);
        void DeleteJob(int qid);
        List<JobView> GetJobs();
        JobView GetJobByJobID(int JobID);
       
        List<JobView> GetJobsByCompanyID(int CompanyID);
        List<JobView> GetJobsByUserID(int UserID);
    }
    public class JobsService : IJobsService
    {
        IJobsRepository jr;

        public JobsService()
        {
            jr = new JobsRepository();
        }

        public int InsertJob(NewJob qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewJob, Job>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Job q = mapper.Map<NewJob, Job>(qvm);
            jr.InsertJob(q);
            int jid = jr.GetLatestJobID();
            return jid;
        }

        public void UpdateJobDetails(EditJob qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditJob, Job>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Job q = mapper.Map<EditJob, Job>(qvm);
            jr.UpdateJobDetails(q);
        }

        public void UpdateApplicantsCount(int qid, int value)
        {
            jr.UpdateApplicantsCount(qid, value);
        }

        public void DeleteJob(int qid)
        {
            jr.DeleteJob(qid);
        }

        public List<JobView> GetJobs()
        {
            List<Job> q = jr.GetJobs();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Job, JobView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<JobView> qvm = mapper.Map<List<Job>, List<JobView>>(q);
            return qvm;
        }

        public JobView GetJobByJobID(int JobID/*, int UserID = 0*/)
        {
            Job q = jr.GetJobByJobID(JobID).FirstOrDefault();
            JobView qvm = null;
            if (q != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Job, JobView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                qvm = mapper.Map<Job, JobView>(q);

                //foreach (var item in qvm.Applicants)
                //{

                //    ApplicantView applic = item.Applicants.Where(temp => temp.UserID == UserID).FirstOrDefault();

                //}
            }
            return qvm;


        }
      
        public List<JobView> GetJobsByCompanyID(int CompanyID)
        {
            List<Job> j = jr.GetJobsByCompanyID(CompanyID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Job, JobView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<JobView> jm = mapper.Map<List<Job>, List<JobView>>(j);
            return jm;


        }

        public List<JobView> GetJobsByUserID(int UserID)
        {
            List<Job> j = jr.GetJobsByUserID(UserID);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Job, JobView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<JobView> jm = mapper.Map<List<Job>, List<JobView>>(j);
            return jm;


        }

    }
}
