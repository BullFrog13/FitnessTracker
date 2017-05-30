using System.Collections.Generic;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Exceptions;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.DAL.Entities.Statistics;
using FitnessTracker.DAL.Interfaces;

namespace FitnessTracker.BLL.Services
{
    public class MotionStatisticService : IMotionStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MotionStatisticService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MotionStatisticDto> GetAllUserStatistics(string email)
        {
            var user = _unitOfWork.Users.FindOne(x => x.Email.Equals(email));

            if (user == null)
            {
                throw new EntityNotFoundException($"There is no User with email {email} in the database.", "User");
            }

            var motionStatistics = _unitOfWork.MotionStatistics.Find(x => x.UserId == user.Id);
            var motionStatisticDtos = _mapper.Map<IEnumerable<MotionStatisticDto>>(motionStatistics);

            return motionStatisticDtos;
        }

        public void Create(MotionStatisticDto motionStatisticDto)
        {
            var motionStatistic = _mapper.Map<MotionStatistic>(motionStatisticDto);

            _unitOfWork.MotionStatistics.Create(motionStatistic);
            _unitOfWork.Save();
        }
    }
}