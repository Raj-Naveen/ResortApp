using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResortApp.Application.Common.Interfaces;
using ResortApp.Domain.Entities;
using ResortApp.Infrastructure.Data;


namespace ResortApp.Infrastructure.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        // We implement a this method (common methods) in Repository class. Because it is used for many classes like  VillaRepository class, VillaNumberRepository class
        // IRepository class is generic.
        #region
        /* public void Add(Villa entity)
         {
             //_db.Villas.Add(entity);
             _db.Add(entity);
         }

         public Villa Get(Expression<Func<Villa, bool>>? filter, string? includeProperties = null)
         {
             IQueryable<Villa> query = _db.Set<Villa>();
             if (filter != null)
             {
                 query = query.Where(filter);
             }
             if (!string.IsNullOrEmpty(includeProperties))
             {
                 foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                 {
                     query = query.Include(includeProp);
                 }
             }
             return query.FirstOrDefault();
         }

         public IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? includeProperties = null)
         {
             IQueryable<Villa> query = _db.Set<Villa>();
             if (filter != null)
             {
                 query = query.Where(filter);
             }
             if (!string.IsNullOrEmpty(includeProperties))
             {
                 foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                 {
                     query = query.Include(includeProp);
                 }
             }
             return query.ToList();
         }

         public void Remove(Villa entity)
         {
             //_db.Villas.Remove(entity);
             _db.Remove(entity);
         }*/
        #endregion


        //Because Save method is implemented in UnitOfWork class. In save method(unitofwork.villa.save()) is mentioned in controller class.
        //If above variable .villa have two entities , it is save both entities. It is wrong . so the method is moved to unit of work class.

        /*public void Save()
        {
            _db.SaveChanges();
        }*/

        public void Update(Villa entity)
        {
            _db.Villas.Update(entity);
        }
    }
}
