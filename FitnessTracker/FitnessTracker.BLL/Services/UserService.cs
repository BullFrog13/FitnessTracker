using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Exceptions;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.DAL.Entities;
using FitnessTracker.DAL.Interfaces;

namespace FitnessTracker.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = _unitOfWork.Repository<User>();
        }
        
        public UserDto Get(int id)
        {
            var user = _userRepository.Get(id);
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public UserDto Get(string login)
        {
            var user = _userRepository.FindOne(x => x.UserName.Equals(login));
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userRepository.GetAll().ToList();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDto;
        }

        public void Create(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _userRepository.Create(user);
            _unitOfWork.Save();
        }

        public void Edit(UserDto userDto)
        {
            var updatingUser = _userRepository.Get(userDto.Id);

            if (updatingUser == null)
            {
                throw new EntityNotFoundException($"There is no User with id { userDto.Id } in the database.", "User");
            }

            _mapper.Map(userDto, updatingUser);

            _userRepository.Update(updatingUser);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
            _unitOfWork.Save();
        }

        public UserDto Login(string userName, string password)
        {
            var user = _userRepository.Find(u => u.UserName == userName && u.Password == password).FirstOrDefault();
            if (user == null)
            {
                throw new InvalidLoginException("User failed to login", userName);
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}