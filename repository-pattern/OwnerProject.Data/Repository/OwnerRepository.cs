using OwnerProject.Data.Contract;
using OwnerProject.Domain.Entities;

namespace OwnerProject.Data.Repository
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(OwnerDBContext repositoryContext)
                    : base(repositoryContext)
        {
        }
    }
}