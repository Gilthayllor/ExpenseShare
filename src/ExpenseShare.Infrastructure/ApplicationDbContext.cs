using ExpenseShare.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExpenseShare.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnityOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }
    }
}
