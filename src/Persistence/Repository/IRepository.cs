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

        public Task AddAnEntityAsync(TEntity entity);

        public void Delete(TEntity entity);

        public void Update(TEntity entity);
        
        public Task<int> Save();
    }
}
