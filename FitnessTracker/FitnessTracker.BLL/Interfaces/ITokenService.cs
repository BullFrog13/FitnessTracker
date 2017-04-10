using FitnessTracker.BLL.DTO;

namespace FitnessTracker.BLL.Interfaces
{
    public interface ITokenService
    {
        TokenDto GenerateToken(int userId);

        bool ValidateToken(string tokenId);

        bool Kill(string tokenId);

        bool DeleteByUserId(int userId);
    }
}
