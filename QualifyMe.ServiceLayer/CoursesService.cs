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
    public interface ICoursesService
    {
        void InsertCourse(CourseView cvm);
        void UpdateCourse(CourseView cvm);
        void DeleteCourse(int cid);
        List<CourseView> GetCourses();
        CourseView GetCourseByCourseID(int CourseID);
    }
    public class CoursesService : ICoursesService
    {
        ICoursesRepository cr;

        public CoursesService()
        {
            cr = new CoursesRepository();
        }

        public void InsertCourse(CourseView cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CourseView, Course>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Course c = mapper.Map<CourseView, Course>(cvm);
            cr.InsertCourse(c);
        }

        public void UpdateCourse(CourseView cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CourseView, Course>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Course c = mapper.Map<CourseView, Course>(cvm);
            cr.UpdateCourse(c);
        }

        public void DeleteCourse(int cid)
        {
            cr.DeleteCourse(cid);
        }

        public List<CourseView> GetCourses()
        {
            List<Course> c = cr.GetCourses();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Course, CourseView>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<CourseView> cvm = mapper.Map<List<Course>, List<CourseView>>(c);
            return cvm;
        }

        public CourseView GetCourseByCourseID(int CourseID)
        {
            Course c = cr.GetCoursesByCourseID(CourseID).FirstOrDefault();
            CourseView cvm = null;
            if (c != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Course, CourseView>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<Course, CourseView>(c);
            }
            return cvm;
        }
    }
}
