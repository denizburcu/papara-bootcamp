using FakeUserProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeUserProject.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

         public DbSet<User>? Users { get; set; }
    }

    public static class ApplicationDbContextExtensions
    {
    }
}