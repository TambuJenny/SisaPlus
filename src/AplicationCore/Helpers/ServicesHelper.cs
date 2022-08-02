using AplicationCore.Business;
using AutoMapper;
using DomainService.DTO;
using DomainService.Models;
using DomainService.Models.Interface;

namespace AplicationCore.Helpers
{
    public class ServicesHelper
    {
        public static void RegisterBusinesses(IServiceCollection services)
        {
            services.AddScoped<IPerson, PersonBusiness>();

            //AutoMapper
            var mapperConfig = new MapperConfiguration(
                conf =>
                {
                    conf.CreateMap<PersonModel, PersonDTO>().ReverseMap();
                }
            );
            AutoMapper.IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
