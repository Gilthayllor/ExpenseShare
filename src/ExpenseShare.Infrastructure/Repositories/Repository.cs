using ExpenseShare.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExpenseShare.Infrastructure.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {
        private readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual void Add(T entity)
        {
            Context.Add(entity);
        }
    }
}
