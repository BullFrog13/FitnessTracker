using System;
using FitnessTracker.BLL.DTO;

namespace FitnessTracker.BLL.Interfaces
{
    public interface ITokenService
    {
        TokenDto GenerateToken(int userId);

        bool ValidateToken(Guid tokenId);

        void Kill(Guid tokenId);

        void DeleteByUserId(int userId);
    }
}