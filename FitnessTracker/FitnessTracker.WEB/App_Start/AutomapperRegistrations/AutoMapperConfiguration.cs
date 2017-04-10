using AutoMapper;
using FitnessTracker.BLL.Infrastructure.AutomapperRegistration;

namespace FitnessTracker.WEB.AutomapperRegistrations
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToDtoProfile());
                cfg.AddProfile(new DtoToViewModelProfile());

                cfg.AddProfile(new DtoToEntityProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });

            return config;
        }
    }
}