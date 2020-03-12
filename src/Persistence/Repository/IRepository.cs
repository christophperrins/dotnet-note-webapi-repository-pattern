using src.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Persistence.Repository
{
    public interface IRepository<TEntity>
    {
        public Task<List<TEntity>> GetAllAsync();

        public Task<TEntity> GetSingleAsync(int id);

        public Task<int> AddAsync(TEntity entity);

        public Task<int> DeleteAsync(int id);

        public Task<int> UpdateAsync(TEntity entity);
        
    }
}
