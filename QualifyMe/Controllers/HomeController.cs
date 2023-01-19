using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Q.DomainModels;
using QualifyMe.ServiceLayer;
using QualifyMe.ViewModels;

namespace QualifyMe.Controllers
{
    public class HomeController : Controller
    {
        IJobsService js;
        ICoursesService cs;
        ICompaniesService com;
        IJobsService job;
        ISkillService skill;
        ITagsService tags;
        public HomeController(IJobsService js, ICoursesService cs, ICompaniesService com, IJobsService job,ISkillService skill,IJobsService jobs)
        {
            this.js = js;
            this.cs = cs;
            this.com = com;
            this.job = job;
            this.skill = skill;
            this.job = jobs;
        }
        // GET: Home
        public ActionResult Index()
        {
            List<JobView> jobs = this.js.GetJobs().Take(10).ToList();
            return View(jobs);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Courses()
        {
            List<CourseView> courses = this.cs.GetCourses().Take(10).ToList();
            return View(courses);
        }

        public ActionResult Companies()
        {
            List<CompanyView> companies = this.com.GetCompanies().Take(10).ToList();
            return View(companies);
        }



        public ActionResult RecommendedJobs()
        {
            using (QualifyMeDbContext db = new QualifyMeDbContext())
            {
                int uid = Convert.ToInt32(Session["CurrentUserID"]);
                List<Applicant> applicants = db.Applicants.ToList();
                List<Course> courses = db.Courses.ToList();
                List<Job> jobs = db.Jobs.ToList();
                List<Student> students = db.Students.ToList();
                List<Department> departments = db.Departments.ToList();
                List<Company> companies = db.Companies.ToList();
                List<Tag> tags = db.Tags.ToList();
                List<StudentSkillSet> studentSkillSets = db.StudentSkillSets.ToList();
                List<SkillTag> skillTags = db.SkillTags.ToList();
                var recommendedjobs = (from s in students
                                       join sss in studentSkillSets on s.UserID equals sss.UserID into StudentSkillsets
                                       from sss in StudentSkillsets.ToList()
                                       from t in tags
                                       join j in jobs on t.JobID equals j.JobID into Jobs
                                       from j in Jobs.ToList()
                                       join cmp in companies on j.CompanyID equals cmp.CompanyID into Companies
                                       from cmp in Companies.ToList()
                                       //join d in departments on j.DepartmentID equals d.DepartmentID into Departments
                                       //from d in Departments.ToList() 
                                       //join c in courses on s.CourseID equals c.CourseID into Courses
                                       //from c in Courses.ToList()
                                       where s.UserID == uid && t.TagName == sss.SkillName /*&& s.CourseID == c.CourseID*/



                                       select new Model
                                       {
                                            //department = d,
                                           student = s,
                                           job = j,
                                         //  course = c,
                                           company = cmp,
                                           tag = t,
                                           StudentSkillSet = sss

                                       }).Distinct();

                    foreach(Student student in students)
                    {
                    
                    string skillName = studentSkillSets[student.UserID].ToString();
                   
                    foreach (Job job in jobs)
                        {
                        string tagName = tags[job.JobID].ToString();
                        if (skillName == tagName || findSimilarity(skillName,tagName) > 0.5)
                            {
                                Model model = new Model();
                          //  List<Model> recommendedjobs = new List<Model>();
                            //model.department = d;
                             model.student = student;
                                model.job = job;
                               // model.course = c;
                               // model.company = cmp;
                                //model.tag = tags;
                               // model.StudentSkillSet = sss;

                           
                               }
                           
                        }
                    }
                return View(recommendedjobs);

               
            }
        }
        [Route("myapplications")]
        public ActionResult MyApplications()
        {
            using (QualifyMeDbContext db = new QualifyMeDbContext())
            {
                int cid = Convert.ToInt32(Session["CurrentUserID"]);
                List<Student> students = db.Students.ToList();
                List<Applicant> applicants = db.Applicants.ToList();
                List<Job> jobs = db.Jobs.ToList();
                List<Company> companies = db.Companies.ToList();

                

                var AppliedJobsList = from a in applicants
                                      join s in students on a.UserID equals s.UserID into Applicants
                                      from s in Applicants.ToList()
                                      join j in jobs on a.JobID equals j.JobID into Jobs
                                      from j in Jobs.ToList()
                                      join c in companies on j.CompanyID equals c.CompanyID into Companies
                                      from c in Companies.ToList()
                                      where s.UserID == cid && j.JobID == a.JobID

                                      
                                         select new Model
                                      {
                                          applicant = a,
                                          student = s,
                                          job = j,
                                          company = c
                                      };

                
                return View(AppliedJobsList);
            }
        }

        public ActionResult Homepage()
        {
            List<JobView> jobs = this.js.GetJobs().Take(10).ToList();
            return View(jobs);
        }

        public ActionResult Types()
        {
            List<JobView> jobs = this.js.GetJobs().Take(10).ToList();
            

            return View(jobs);
        }


        //public ActionResult RecommendedJobs(string SkillName,string Tagname)
        //{
        //    using (QualifyMeDbContext db = new QualifyMeDbContext())
        //    {
        //        List<StudentSkillSetView> skills = this.skill.GetSkills();
        //        List<TagView> tags = this.tags.GetTags();

        //        string s1 = SkillName;
        //        string s2 = Tagname;


        //        double similarity = findSimilarity(s1, s2);

        //        Console.WriteLine(similarity);


        //    } return View();
        //}






        public static int getEditDistance(string X, string Y)
        {
            int m = X.Length;
            int n = Y.Length;

            int[][] T = new int[m + 1][];
            for (int i = 0; i < m + 1; ++i)
            {
                T[i] = new int[n + 1];
            }

            for (int i = 1; i <= m; i++)
            {
                T[i][0] = i;
            }
            for (int j = 1; j <= n; j++)
            {
                T[0][j] = j;
            }

            int cost;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    cost = X[i - 1] == Y[j - 1] ? 0 : 1;
                    T[i][j] = Math.Min(Math.Min(T[i - 1][j] + 1, T[i][j - 1] + 1),
                            T[i - 1][j - 1] + cost);
                }
            }

            return T[m][n];
        }

        public static double findSimilarity(string x, string y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("Strings must not be null");
            }

            double maxLength = Math.Max(x.Length, y.Length);
            if (maxLength > 0)
            {
                // optionally ignore case if needed
                return (maxLength - getEditDistance(x, y)) / maxLength;
            }
            return 1.0;
        }
    }
}