using System.Web.Http;
using System.Web.Mvc;
using QualifyMe.ServiceLayer;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;

namespace QualifyMe
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			container.RegisterType<IStudentsService, StudentsService>();
			container.RegisterType<ICompaniesService, CompaniesService>();
			container.RegisterType<ICoursesService, CoursesService>();
			container.RegisterType<IDepartmentsService, DepartmentsService>();
			container.RegisterType<IJobsService, JobsService>();
			container.RegisterType<ITagsService, TagsService>();
			container.RegisterType<ISkillService, SkillService>();
			container.RegisterType<IApplicantsService, ApplicantsService>();
			DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
		}
	}
}