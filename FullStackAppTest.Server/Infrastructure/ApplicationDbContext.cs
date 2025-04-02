using FullStackAppTest.Server.Application.Dtos;
using FullStackAppTest.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace FullStackAppTest.Server.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TestObject> TestObjects { get; set; }
    }
}
