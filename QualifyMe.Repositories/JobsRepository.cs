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

        int GetLatestJobID();
        List<Job> GetJobs();
        List<Job> GetJobByJobID(int JobID);
       //List<Job> GetApplicantsByJobID(int JobID);
        List<Job> GetJobsByCompanyID(int CompanyID);
        List<Job>  GetJobsByUserID(int UserID);
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
            int[] arr = Job.Select(x => int.Parse(x.GetProperty("Ranking"))).ToArray();
            InsertionSort(arr);
            db.Jobs.Add(j);
            db.SaveChanges();
        }

        public void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i;
                while (j > 0 && key < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = key;
            }
        }
        public void UpdateJobDetails(Job j)
        {
            Job jb = db.Jobs.Where(temp => temp.JobID == j.JobID).FirstOrDefault();
            if (jb != null)
            {
                jb.JobTitle = j.JobTitle;
                jb.JobDescription = j.JobDescription;
                jb.JobQualification = j.JobQualification;
                jb.JobTypes = j.JobTypes;
                jb.JobStatus = j.JobStatus;
                jb.JobDateAndTime = j.JobDateAndTime;
              //  jb.JobSalary = j.JobSalary;
                 jb.DepartmentID = j.DepartmentID;
               // jb.CourseID = j.CourseID;
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

        public int GetLatestJobID()
        {
            int jid = db.Jobs.Select(temp => temp.JobID).Max();
            return jid;
        }
        //public List<Job> GetApplicantsByJobID(int JobID)
        //{
        //    List<Job> ap = db.Jobs.Where(temp => temp.JobID == JobID).OrderByDescending(temp => temp.JobDateAndTime).ToList();
        //    return ap;
        //}

        public List<Job> GetJobsByCompanyID(int CompanyID)
        {

            List<Job> ap = db.Jobs.Where(temp => temp.CompanyID ==CompanyID).OrderByDescending(temp => temp.JobDateAndTime).ToList();

            return ap;
        }
        //public List<Job> GetApplicantsByUserID(int UserID)
        //{
        //    List<Job> a = db.Jobs.Where(temp => temp.ApplicantID == UserID).ToList();
        //    return a;
        //}
        public List<Job> GetJobsByUserID(int UserID)
        {

            List<Job> ap = db.Jobs.Where(temp => temp.JobID == UserID).OrderByDescending(temp => temp.JobDateAndTime).ToList();

            return ap;
        }
    }
}
