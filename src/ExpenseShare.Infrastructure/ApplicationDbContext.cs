using ExpenseShare.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExpenseShare.Infrastructure
{
    public class ApplicationDbContext : DbContext, IUnityOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
