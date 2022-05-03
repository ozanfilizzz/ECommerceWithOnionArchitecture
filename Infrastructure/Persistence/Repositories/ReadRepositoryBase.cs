using Application.Repositories;
using Domain.Entites.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReadRepositoryBase<T> : IReadRepository<T> where T : Entity
    {
        private readonly ECommerceAPIDbContext _context;

        public ReadRepositoryBase(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
               query = query.AsNoTracking();
            return query;
  
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.Where(predicate);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

        }
            
        
    }
}
