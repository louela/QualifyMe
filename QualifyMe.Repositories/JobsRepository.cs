using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.DomainModels;

namespace QualifyMe.Repositories
{
    public interface IJobsRepository
    {
        void InsertJob(Job j);
        void UpdateJobDetails(Job j);
       
        void UpdateApplicantsCount(int jid, int value);
        void DeleteJob(int jid);
       
        List<Job> GetJobs();
        List<Job> GetJobByJobID(int JobID);
    }
    public class JobsRepository: IJobsRepository
    {
        QualifyMeDbContext db;

        public JobsRepository()
        {
            db = new QualifyMeDbContext();
        }

        public void InsertJob(Job j)
        {
            db.Jobs.Add(j);
            db.SaveChanges();
        }

        public void UpdateJobDetails(Job j)
        {
            Job jb = db.Jobs.Where(temp => temp.JobID == j.JobID).FirstOrDefault();
            if (jb != null)
            {
                jb.JobTitle = j.JobTitle;
                jb.JobDateAndTime = j.JobDateAndTime;
                jb.CourseID = j.CourseID;
                db.SaveChanges();
            }
        }

        public void UpdateApplicantsCount(int jid, int value)
        {
            Job jb = db.Jobs.Where(temp => temp.JobID == jid).FirstOrDefault();
            if (jb != null)
            {
                jb.ApplicantsCount += value;
                db.SaveChanges();
            }
        }

        public void DeleteJob(int jid)
        {
            Job jb = db.Jobs.Where(temp => temp.JobID == jid).FirstOrDefault();
            if (jb != null)
            {
                db.Jobs.Remove(jb);
                db.SaveChanges();
            }
        }

        public List<Job> GetJobs()
        {
            List<Job> jb = db.Jobs.OrderByDescending(temp => temp.JobDateAndTime).ToList();
            return jb;
        }

        public List<Job> GetJobByJobID(int JobID)
        {
            List<Job> jb = db.Jobs.Where(temp => temp.JobID == JobID).ToList();
            return jb;
        }
    }
}
