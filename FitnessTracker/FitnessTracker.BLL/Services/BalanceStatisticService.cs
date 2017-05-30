using System.Collections.Generic;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Exceptions;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.DAL.Entities.Statistics;
using FitnessTracker.DAL.Interfaces;

namespace FitnessTracker.BLL.Services
{
    public class BalanceStatisticService : IBalanceStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BalanceStatisticService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<BalanceStatisticDto> GetAllUserStatistics(string email)
        {
            var user = _unitOfWork.Users.FindOne(x => x.Email.Equals(email));

            if(user == null)
            {
                throw new EntityNotFoundException($"There is no User with email { email } in the database.", "User");
            }

            var balanceStatistics = _unitOfWork.BalanceStatistics.Find(x => x.UserId == user.Id);
            var balanceStatisticDtos = _mapper.Map<IEnumerable<BalanceStatisticDto>>(balanceStatistics);

            return balanceStatisticDtos;
        }

        public void Create(BalanceStatisticDto balanceStatisticDto)
        {
            var balanceStatistic = _mapper.Map<BalanceStatistic>(balanceStatisticDto);

            _unitOfWork.BalanceStatistics.Create(balanceStatistic);
            _unitOfWork.Save();
        }
    }
}