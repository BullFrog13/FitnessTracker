using System.Collections.Generic;
using FitnessTracker.BLL.DTO;

namespace FitnessTracker.BLL.Interfaces
{
    public interface IBalanceStatisticService
    {
        IEnumerable<BalanceStatisticDto> GetAllUserStatistics(string email);

        void Create(BalanceStatisticDto balanceStatisticDto);
    }
}