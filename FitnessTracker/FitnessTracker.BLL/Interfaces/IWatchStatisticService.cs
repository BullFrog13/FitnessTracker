using System.Collections.Generic;
using FitnessTracker.BLL.DTO;

namespace FitnessTracker.BLL.Interfaces
{
    public interface IWatchStatisticService
    {
        IEnumerable<WatchStatisticDto> GetAllUserStatistics(string email);

        void Create(WatchStatisticDto watchStatisticDto);
    }
}