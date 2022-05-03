using Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : Entity
    {
        Task<int> SaveAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Update(T entity);
        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        Task<bool> RemoveAsync(string id);
    }
}
