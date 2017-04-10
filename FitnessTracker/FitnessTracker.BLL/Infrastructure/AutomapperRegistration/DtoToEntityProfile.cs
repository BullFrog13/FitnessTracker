using FitnessTracker.BLL.DTO;
using FitnessTracker.DAL.Entities;
using Profile = AutoMapper.Profile;

namespace FitnessTracker.BLL.Infrastructure.AutomapperRegistration
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>();

            CreateMap<ProfileDto, Profile>();

            CreateMap<StatisticDto, Statistic>();
        }
    }
}