using System.Collections.Generic;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Exceptions;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.DAL.Entities.Statistics;
using FitnessTracker.DAL.Interfaces;

namespace FitnessTracker.BLL.Services
{
    public class WatchStatisticService : IWatchStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WatchStatisticService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<WatchStatisticDto> GetAllUserStatistics(string email)
        {
            var user = _unitOfWork.Users.FindOne(x => x.Email.Equals(email));

            if(user == null)
            {
                throw new EntityNotFoundException($"There is no User with email { email } in the database.", "User");
            }

            var watchStatistics = _unitOfWork.WatchStatistics.Find(x => x.UserId == user.Id);
            var watchStatisticDtos = _mapper.Map<IEnumerable<WatchStatisticDto>>(watchStatistics);

            return watchStatisticDtos;
        }

        public void Create(WatchStatisticDto watchStatisticDto)
        {
            var watchStatistic = _mapper.Map<WatchStatistic>(watchStatisticDto);

            _unitOfWork.WatchStatistics.Create(watchStatistic);
            _unitOfWork.Save();
        }
    }
}