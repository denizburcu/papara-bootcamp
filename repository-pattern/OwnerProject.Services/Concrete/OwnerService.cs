using OwnerProject.Domain.Entities;
using OwnerProject.Services.Contract;
using OwnerProject.Data.Contract;
using OwnerProject.Services.Helpers;

namespace OwnerProject.Services.Concrete
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public void AddOwner(Owner owner)
        {
            _ownerRepository.Create(owner);
            _ownerRepository.SaveChanges();
        }

        public void DeleteOwner(int id)
        {
            var ownerResult = _ownerRepository.FindByCondition(owner => owner.Id == id);
            if (ownerResult.FirstOrDefault() == null)
                throw new OwnerNotFoundException($"{id} no owner not found.");
            var owner = ownerResult.First();
            _ownerRepository.Delete(owner);
            _ownerRepository.SaveChanges();
        }

        public IEnumerable<Owner> GetAllOwner()
        {
            return _ownerRepository.FindAll();
        }

        public void UpdateOwner(Owner updatedOwner)
        {
            var ownerResult = _ownerRepository.FindByCondition(owner => owner.Id == updatedOwner.Id);
            if (ownerResult.FirstOrDefault() == null)
                throw new OwnerNotFoundException($"{updatedOwner.Id} no owner not found.");
            var owner = ownerResult.First();
            owner.Id = updatedOwner.Id != default ? updatedOwner.Id : owner.Id;
            owner.Name = updatedOwner.Name != default ? updatedOwner.Name : owner.Name;
            owner.Surname = updatedOwner.Surname != default ? updatedOwner.Surname : owner.Surname;
            owner.Date = updatedOwner.Date != default ? updatedOwner.Date : owner.Date;
            owner.Description = updatedOwner.Description != default ? updatedOwner.Description : owner.Description;
            owner.Type = updatedOwner.Type != default ? updatedOwner.Type : owner.Type;
            _ownerRepository.Update(owner);
            _ownerRepository.SaveChanges();
        }
    }
}