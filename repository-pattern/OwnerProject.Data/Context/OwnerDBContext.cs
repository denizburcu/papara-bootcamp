using Microsoft.EntityFrameworkCore;
using OwnerProject.Domain.Entities;

namespace OwnerProject.Data
{
    public class OwnerDBContext : DbContext
    {
        public OwnerDBContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Owner>? Owners { get; set; }
    }
}