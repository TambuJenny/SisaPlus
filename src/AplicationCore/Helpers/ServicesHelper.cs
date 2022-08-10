using AplicationCore.Services;
using AutoMapper;
using DomainService.Interface;
using DomainService.Models;
using DomainService.Models.Interface;
using DomainService.Request;
using DomainService.Response;
using Services.Person;

namespace AplicationCore.Helpers
{
    public class ServicesHelper
    {
        public static void RegisterBusinesses(IServiceCollection services)
        {
            services.AddScoped<IPerson, PersonServices>();
            services.AddScoped<IStudent, StudentServices>();

            //AutoMapper
            var mapperConfig = new MapperConfiguration(
                conf =>
                {
                    conf.CreateMap<PersonModel, PersonRequest>().ReverseMap();
                    conf.CreateMap<PersonModel, PersonResponse>().ReverseMap();
                    conf.CreateMap<StudentModel, StudentResponse>().ReverseMap();
                    conf.CreateMap<StudentModel, StudentRequest>().ReverseMap();
                    conf.CreateMap<CourseModel, CourseRequest>().ReverseMap();
                    conf.CreateMap<CourseModel, CourseResponse>().ReverseMap();
                }
            );
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
