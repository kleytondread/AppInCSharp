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
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
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
            _context.SaveChanges();

            return _entities.Find(entity.Id);
        }

        public Task<T> AddAsync(T entity)
        {
            //tá dando erro no 'return'
            //var newEntity = _entities.AddAsync(entity).AsTask();
            //_context.SaveChanges();
            //return newEntity;

            _entities.AddAsync(entity);
            _context.SaveChanges();
            return Task.FromResult(_entities.Find(entity.Id));
        }

        public void Delete(long id)
        {
            var entityToBeDeleted = FindBy(e => e.Id == id).ToList()[0];
            //talvez uma validação?
            _entities.Remove(entityToBeDeleted);
            _context.SaveChanges();
        }

        public IEnumerable<T> FindAll()
        {
            var query = _entities.AsQueryable();
            query.Select(e => e);

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var query = _entities.AsQueryable();
            query.Select(e => e);
            
            return await query.ToListAsync();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _entities.AsQueryable();
            query.Where(predicate);

            return query.ToList();
        }
        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            var query = _entities.AsQueryable();
            query.Where(predicate);

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

        public void UnDelete(long id)
        {
            //será que o isDeleted teria que tá no baseEntity, ou eu devia usar o auditEntity aqui?
        }

        public T Updade(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();

            return _entities.Find(entity.Id);
        }
    }
}
