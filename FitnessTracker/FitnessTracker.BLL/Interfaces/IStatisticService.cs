using System.Collections.Generic;
using FitnessTracker.BLL.DTO;

namespace FitnessTracker.BLL.Interfaces
{
    public interface IStatisticService
    {
        StatisticDto Get(int id);
        IEnumerable<StatisticDto> GetAll();
        void Create(StatisticDto statisticDto);
        void Edit(StatisticDto statisticDto);
        void Delete(int id);
    }
}
