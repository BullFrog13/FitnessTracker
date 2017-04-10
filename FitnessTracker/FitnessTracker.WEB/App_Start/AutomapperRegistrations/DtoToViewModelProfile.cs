using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.AutomapperRegistrations
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile()
        {
            CreateMap<UserDto, UserViewModel>();

            CreateMap<ProfileDto, ProfileViewModel>();

            CreateMap<StatisticDto, StatisticViewModel>();

        }
    }
}