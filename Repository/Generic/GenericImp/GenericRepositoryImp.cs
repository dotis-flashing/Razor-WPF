using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Generic.GenericImp
{
    public class GenericRepositoryImp<T> : IGenericRepository<T> where T : class
    {
        public readonly FUCarRentingManagementContext _context;

        // Privated use DB in class 
        private readonly DbSet<T> _entitiySet;

        public GenericRepositoryImp(FUCarRentingManagementContext context)
        {
            _context = context;
            _entitiySet = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _context.Add(entity);
            return entity;
        }

        public void Remove(T entity)
              => _context.Remove(entity);

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
