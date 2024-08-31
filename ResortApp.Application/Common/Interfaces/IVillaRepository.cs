using ResortApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResortApp.Application.Common.Interfaces
{
    // In this interface, we will have all the methods to perform crud operations on villa
    public interface IVillaRepository : IRepository<Villa>
    {
        //retrive all the villa
        /*IEnumerable<Villa> GetAll(Expression<Func<Villa,bool>>? filter = null, string? includeProperties = null);*/

        // Get one individual villa


        /*Villa Get(Expression<Func<Villa, bool>>? filter, string? includeProperties = null);
        void Add(Villa entity);*/

        void Update(Villa entity);   


        //void Remove(Villa entity);

        //void Save(); because it is implemented in IUnitOfWork class. In save method ( unitofwork.villa.save()) is mentioned in controller class.
        //If above variable .villa have two entities , it is save both entities. It is wrong . so the method is moved to unit of work class.
    }
}
