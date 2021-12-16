using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {

        public void Add(T entity)
        {
            using (AnındaKapındaContext _anındaKapındaContext = new AnındaKapındaContext())
            {
                var addedEntity = _anındaKapındaContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                _anındaKapındaContext.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (AnındaKapındaContext _anındaKapındaContext = new AnındaKapındaContext())
            {
                var addedEntity = _anındaKapındaContext.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                _anındaKapındaContext.SaveChanges();
            }

        }

        public T Get(Expression<Func<T, bool>> filter)
        {

            using (AnındaKapındaContext _anındaKapındaContext = new AnındaKapındaContext())
            {
                return _anındaKapındaContext.Set<T>().Where(filter).SingleOrDefault();
            }

        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (AnındaKapındaContext _anındaKapındaContext = new AnındaKapındaContext())
            {
                return filter == null ? _anındaKapındaContext.Set<T>().ToList() :
                      _anındaKapındaContext.Set<T>().Where(filter).ToList();
            }

        }

        public void Update(T entity)
        {
            using (AnındaKapındaContext _anındaKapındaContext = new AnındaKapındaContext())
            {
                var addedEntity = _anındaKapındaContext.Entry(entity);
                addedEntity.State = EntityState.Modified;
                _anındaKapındaContext.SaveChanges();
            }
        }
    }
}
