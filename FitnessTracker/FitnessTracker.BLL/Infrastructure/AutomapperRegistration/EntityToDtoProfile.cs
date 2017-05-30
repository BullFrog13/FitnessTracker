using FitnessTracker.BLL.DTO;
using FitnessTracker.DAL.Entities;
using FitnessTracker.DAL.Entities.Statistics;
using Profile = AutoMapper.Profile;

namespace FitnessTracker.BLL.Infrastructure.AutomapperRegistration
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<WatchStatistic, WatchStatisticDto>();
            CreateMap<BalanceStatistic, BalanceStatisticDto>();
            CreateMap<MotionStatistic, MotionStatisticDto>();
        }
    }
}