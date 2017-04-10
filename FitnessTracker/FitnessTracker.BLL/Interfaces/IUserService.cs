using System.Collections.Generic;
using FitnessTracker.BLL.DTO;

namespace FitnessTracker.BLL.Interfaces
{
    public interface IUserService
    {
        UserDto Get(int id);

        UserDto Get(string login);

        IEnumerable<UserDto> GetAll();

        void Create(UserDto userDto);

        void Edit(UserDto userDto);

        void Delete(int id);

        UserDto Login(string userName, string password);
    }
}