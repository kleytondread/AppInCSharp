using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.ONS.Treinamento.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T FindById(long id);
        Task<T> FindByIdAsync(long id);
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        T Updade(T entity);
        void Delete(long id);
        void UnDelete(long id);
    }
}
