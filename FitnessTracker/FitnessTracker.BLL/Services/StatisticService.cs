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
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Statistic> _statisticRepository;

        public StatisticService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _statisticRepository = _unitOfWork.Repository<Statistic>();
        }
        
        public StatisticDto Get(int id)
        {
            var statistic = _statisticRepository.Get(id);
            var statisticDto = _mapper.Map<StatisticDto>(statistic);

            return statisticDto;
        }

        public IEnumerable<StatisticDto> GetAll()
        {
            var statistics = _statisticRepository.GetAll().ToList();
            var statisticsDto = _mapper.Map<IEnumerable<StatisticDto>>(statistics);

            return statisticsDto;
        }

        public void Create(StatisticDto statisticDto)
        {
            var statistic = _mapper.Map<Statistic>(statisticDto);

            _statisticRepository.Create(statistic);
            _unitOfWork.Save();
        }

        public void Edit(StatisticDto statisticDto)
        {
            var updatingStatistic = _statisticRepository.Get(statisticDto.Id);

            if (updatingStatistic == null)
            {
                throw new EntityNotFoundException($"There is no Statistic with id { statisticDto.Id } in the database.", "Statistic");
            }

            _mapper.Map(statisticDto, updatingStatistic);

            _statisticRepository.Update(updatingStatistic);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _statisticRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}