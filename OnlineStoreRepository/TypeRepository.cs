using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreDomain;

namespace OnlineStoreRepository
{
    public interface ITypesRepository
    {
        IQueryable<TypeEntity> GetAll();
        TypeEntity Get(int id);
        TypeEntity Add(TypeEntity entity);
        void Delete(TypeEntity entity);
        void Update(TypeEntity entity);
        void Save();
    }
    public class TypeRepository : ITypesRepository
    {
        private readonly DbSet<TypeEntity> _entities;
        private readonly DbContext _context;

        public TypeRepository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TypeEntity>();
        }

        public TypeEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public IQueryable<TypeEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

        public TypeEntity Add(TypeEntity entity)
        {
            return _entities.Add(entity);
        }
        public void Delete(TypeEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Update(TypeEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
