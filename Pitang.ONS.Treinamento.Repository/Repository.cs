using Microsoft.EntityFrameworkCore;
using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IRepository;
using Pitang.ONS.Treinamento.IRepository.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pitang.ONS.Treinamento.Repository.Impl
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            return entity;
        }

        public T Delete(long id)
        {
            var entityToBeDeleted = _entities.AsQueryable().SingleOrDefault(e => e.Id == id);
            entityToBeDeleted.IsDeleted = true;
            return entityToBeDeleted;
        }

        public IEnumerable<T> FindAll()
        {
            var query = _entities.AsQueryable();
            query = query.Select(e => e);

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var query = _entities.AsQueryable();
            query = query.Select(e => e);
            
            return await query.ToListAsync();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _entities.AsQueryable();
            query = query.Where(predicate);

            return query.ToList();
        }
        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            var query = _entities.AsQueryable();
            query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public T FindById(long id)
        {
            return _entities.Find(id);
        }

        public async Task<T> FindByIdAsync(long id)
        {
            return await _entities.FindAsync(id); ;
        }

        public T UnDelete(long id)
        {
            var entityToBeDeleted = _entities.AsQueryable().SingleOrDefault(e => e.Id == id);
            entityToBeDeleted.IsDeleted = false;
            return entityToBeDeleted;
        }

        public T Updade(T entity)
        {
            _entities.Attach(entity).State = EntityState.Modified;
           
            return entity;
        }
    }
}
