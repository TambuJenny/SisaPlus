using AplicationCore.Services;
using AutoMapper;
using DomainService.Models;
using DomainService.Models.Interface;
using DomainService.Request;
using DomainService.Response;

namespace AplicationCore.Helpers
{
    public class ServicesHelper
    {
        public static void RegisterBusinesses(IServiceCollection services)
        {
            services.AddScoped<IPerson, PersonServices>();

            //AutoMapper
            var mapperConfig = new MapperConfiguration(
                conf =>
                {
                    conf.CreateMap<PersonModel, PersonRequest>().ReverseMap();
                    conf.CreateMap<PersonModel, PersonResponse>().ReverseMap();
                }
            );
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
