using System.Collections.Generic;
using FitnessTracker.BLL.DTO;

namespace FitnessTracker.BLL.Interfaces
{
    public interface IProfileService
    {
        ProfileDto Get(int id);
        IEnumerable<ProfileDto> GetAll();
        void Create(ProfileDto profileDto);
        void Edit(ProfileDto profileDto);
        void Delete(int id);
    }
}
