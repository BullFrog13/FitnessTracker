using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.WEB.ViewModels;
using FitnessTracker.WEB.ViewModels.AuthModels;

namespace FitnessTracker.WEB.AutomapperRegistrations
{
    public class ViewModelToDtoProfile : Profile
    {
        public ViewModelToDtoProfile()
        {
            CreateMap<UserViewModel, UserDto>();
            CreateMap<RegisterViewModel, UserDto>();
            CreateMap<WatchStatisticViewModel, WatchStatisticDto>();
            CreateMap<BalanceStatisticViewModel, BalanceStatisticDto>();
            CreateMap<MotionStatisticViewModel, MotionStatisticDto>();
        }
    }
}