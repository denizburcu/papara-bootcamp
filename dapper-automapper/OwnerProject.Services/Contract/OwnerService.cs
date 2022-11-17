using AutoMapper;
using OwnerProject.Data.Contract;
using OwnerProject.Domain.Models;
using OwnerProject.Services.Helpers;

namespace OwnerProject.Services.Contract
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository<Owner> _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerService(IRepository<Owner> repository, IMapper mapper)
        {
            _ownerRepository = repository;
            _mapper = mapper;
        }
        public void AddOwner(OwnerDto ownerDto)
        {
            var mappedOwner = _mapper.Map<Owner>(ownerDto);
            _ownerRepository.Create(mappedOwner);
        }

        public void DeleteOwner(int id)
        {
            var owner = _ownerRepository.Retrive(id);
            if (owner == null)
                throw new OwnerNotFoundException($"{id} owner couldnt find");

            _ownerRepository.Delete(id);
        }

        public List<OwnerDto> GetAllOwners()
        {
            var ownerList = _ownerRepository.RetrieveAll();
            IEnumerable<OwnerDto> allOwners = _mapper.Map<IEnumerable<Owner>, IEnumerable<OwnerDto>>(ownerList);
            return allOwners.ToList();
        }

        public OwnerDto GetOwner(int id)
        {
            var owner = _ownerRepository.Retrive(id);
            var ownerDto = _mapper.Map<OwnerDto>(owner);
            return ownerDto;
        }

        public void UpdateOwner(OwnerDto ownerDto)
        {
            var owner = _ownerRepository.Retrive(ownerDto.Guid);
            if (owner == null)
                throw new OwnerNotFoundException("Update owner couldnt find");

            owner = _mapper.Map<Owner>(ownerDto);
            _ownerRepository.Update(owner);
        }
    }
}