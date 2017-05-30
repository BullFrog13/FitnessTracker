using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.WEB.ViewModels;
using FitnessTracker.WEB.ViewModels.AuthModels;

namespace FitnessTracker.WEB.AutomapperRegistrations
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserDto, User>();
            CreateMap<WatchStatisticDto, WatchStatisticViewModel>();
            CreateMap<BalanceStatisticDto, BalanceStatisticViewModel>();
            CreateMap<MotionStatisticDto, MotionStatisticViewModel>();
        }
    }
}