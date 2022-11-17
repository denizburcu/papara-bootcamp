namespace OwnerProject.Services.Contract
{
    public interface IOwnerService
    {
        public List<OwnerDto> GetAllOwners();
        public void AddOwner(OwnerDto ownerDto);
        public OwnerDto GetOwner(int id);
        public void UpdateOwner(OwnerDto ownerDto);
        public void DeleteOwner(int id);
    }
}