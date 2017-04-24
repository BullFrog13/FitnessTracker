using FitnessTracker.BLL.DTO;
using FitnessTracker.DAL.Entities;
using Profile = AutoMapper.Profile;

namespace FitnessTracker.BLL.Infrastructure.AutomapperRegistration
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}