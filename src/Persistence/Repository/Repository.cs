using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using src.Data;
using src.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ILogger<Repository<TEntity>> _logger;
        private readonly MyContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public Repository(ILogger<Repository<TEntity>> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(int id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            return entity;
        }
        public async Task<int> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            TEntity entity = await GetSingleAsync(id);
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
