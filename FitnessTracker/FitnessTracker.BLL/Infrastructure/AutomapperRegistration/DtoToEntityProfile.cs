using FitnessTracker.BLL.DTO;
using FitnessTracker.DAL.Entities;
using FitnessTracker.DAL.Entities.Statistics;
using Profile = AutoMapper.Profile;

namespace FitnessTracker.BLL.Infrastructure.AutomapperRegistration
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<WatchStatisticDto, WatchStatistic>();
            CreateMap<MotionStatisticDto, MotionStatistic>();
            CreateMap<BalanceStatisticDto, BalanceStatistic>();
        }
    }
}