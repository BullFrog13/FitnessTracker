using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Exceptions;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.DAL.Interfaces;
using Profile = FitnessTracker.DAL.Entities.Profile;

namespace FitnessTracker.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Profile> _profileRepository;

        public ProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _profileRepository = _unitOfWork.Repository<Profile>();
        }
        
        public ProfileDto Get(int id)
        {
            var profile = _profileRepository.Get(id);
            var profileDto = _mapper.Map<ProfileDto>(profile);

            return profileDto;
        }

        public IEnumerable<ProfileDto> GetAll()
        {
            var profiles = _profileRepository.GetAll().ToList();
            var profilesDto = _mapper.Map<IEnumerable<ProfileDto>>(profiles);

            return profilesDto;
        }

        public void Create(ProfileDto profileDto)
        {
            var profile = _mapper.Map<Profile>(profileDto);

            _profileRepository.Create(profile);
            _unitOfWork.Save();
        }

        public void Edit(ProfileDto profileDto)
        {
            var updatingProfile = _profileRepository.Get(profileDto.Id);

            if (updatingProfile == null)
            {
                throw new EntityNotFoundException($"There is no Profile with id { profileDto.Id } in the database.", "Profile");
            }

            _mapper.Map(profileDto, updatingProfile);

            _profileRepository.Update(updatingProfile);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _profileRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}