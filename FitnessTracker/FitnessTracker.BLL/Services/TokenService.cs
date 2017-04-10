using System;
using System.Configuration;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.DAL.Entities;
using FitnessTracker.DAL.Interfaces;

namespace FitnessTracker.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Token> _tokenRepository;

        public TokenService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Token> tokenRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenRepository = tokenRepository;
        }

        public TokenDto GenerateToken(int userId)
        {
            var tokenId = Guid.NewGuid();
            var issuedOn = DateTime.UtcNow;
            var expiredOn = DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));

            var token = new Token
            {
                UserId = userId,
                TokenId = tokenId,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            _tokenRepository.Create(token);
            _unitOfWork.Save();

            return _mapper.Map<TokenDto>(token);
        }

        public bool ValidateToken(Guid tokenId)
        {
            var token = _tokenRepository.FindOne(x => x.TokenId == tokenId && x.ExpiresOn > DateTime.UtcNow);
            if (token == null)
            {
                return false;
            }

            token.ExpiresOn  = DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            _tokenRepository.Update(token);
            _unitOfWork.Save();

            return true;
        }

        public void Kill(Guid tokenId)
        {
            _tokenRepository.Delete(x => x.TokenId == tokenId);
            _unitOfWork.Save();
        }

        public void DeleteByUserId(int userId)
        {
            _tokenRepository.Delete(x => x.UserId == userId);
            _unitOfWork.Save();
        }
    }
}