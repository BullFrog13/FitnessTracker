using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.AutomapperRegistrations
{
    public class ViewModelToDtoProfile : Profile
    {
        public ViewModelToDtoProfile()
        {
            CreateMap<UserViewModel, UserDto>();

            CreateMap<ProfileViewModel, ProfileDto>();

            CreateMap<StatisticViewModel, StatisticDto>();
        }
    }
}