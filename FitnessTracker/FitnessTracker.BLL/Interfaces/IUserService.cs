using System.Collections.Generic;
using FitnessTracker.BLL.DTO;

namespace FitnessTracker.BLL.Interfaces
{
    public interface IUserService
    {
        UserDto Get(int id);

        IEnumerable<UserDto> GetAll();

        void Create(UserDto userDto);

        void Edit(UserDto userDto);

        void Delete(int id);

        int Authenticate(string userName, string password);
    }
}