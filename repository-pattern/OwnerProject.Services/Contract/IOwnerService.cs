using OwnerProject.Domain.Entities;

namespace OwnerProject.Services.Contract
{
    public interface IOwnerService
    {
        public IEnumerable<Owner> GetAllOwner();
        public void AddOwner(Owner owner);

        public void UpdateOwner(Owner owner);

        public void DeleteOwner(int id);
    }
}