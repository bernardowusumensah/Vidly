using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using Vidly.App_Start;

namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                // Configure AutoMapper
                Mapper.Initialize(c => c.AddProfile<MappingProfile>());

                // Configure Web API
                GlobalConfiguration.Configure(WebApiConfig.Register);

                // Configure MVC
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
            catch (Exception ex)
            {
                // Log the error
                System.Diagnostics.Debug.WriteLine($"Application startup error: {ex.Message}");
                throw; // Re-throw to prevent application from starting with errors
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            // Log the error
            System.Diagnostics.Debug.WriteLine($"Application error: {ex?.Message}");
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Models.Customer, DTOs.CustomerDto>();
            CreateMap<Models.Movie, DTOs.MovieDto>();
            CreateMap<Models.MembershipType, DTOs.MembershipTypeDto>();
            CreateMap<Models.Genre, DTOs.GenreDto>();

            // Dto to Domain
            CreateMap<DTOs.CustomerDto, Models.Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<DTOs.MovieDto, Models.Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }

    public class AutoMapperDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IMapper _mapper;

        public AutoMapperDependencyResolver(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public object GetService(Type serviceType)
        {
            return serviceType == typeof(IMapper) ? _mapper : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }

        public void Dispose()
        {
            // Nothing to dispose
        }

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;
        }
    }
}
