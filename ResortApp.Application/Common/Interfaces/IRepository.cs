using ResortApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResortApp.Application.Common.Interfaces
{
    // It is generic repository. Watch 87 episode in the course to understand
    public interface IRepository<T> where T : class
    {
        //retrive all the villa
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        // Get one individual villa
        T Get(Expression<Func<T, bool>>? filter, string? includeProperties = null);
        void Add(T entity);
        bool Any(Expression<Func<T, bool>> filter);
        void Remove(T entity);
    }
}
