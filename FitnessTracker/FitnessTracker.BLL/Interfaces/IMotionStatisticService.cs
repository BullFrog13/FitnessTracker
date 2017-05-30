using System.Collections.Generic;
using FitnessTracker.BLL.DTO;

namespace FitnessTracker.BLL.Interfaces
{
    public interface IMotionStatisticService
    {
        IEnumerable<MotionStatisticDto> GetAllUserStatistics(string email);

        void Create(MotionStatisticDto motionStatisticDto);
    }
}