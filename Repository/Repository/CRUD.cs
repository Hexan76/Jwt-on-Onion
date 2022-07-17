using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repository
{
    public class CRUD : ICRUD
    {
        private MainDBContext _dbContext;

        public CRUD(MainDBContext mainDBContext)
        {
            _dbContext = mainDBContext;
        }

        public bool Create<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

#nullable disable
        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }
#nullable enable
        public ICollection<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null) where TEntity : class
        {
            IQueryable<TEntity> eQuery = _dbContext.Set<TEntity>();
            eQuery = orderBy == null ? eQuery : orderBy(eQuery);
            var list = eQuery.
                ToList();
            return list;
        }

        public ICollection<TEntity> GetPageList<TEntity>(int pagesize, int pageindex, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null) where TEntity : class
        {
            IQueryable<TEntity> eQuery = _dbContext.Set<TEntity>();
            eQuery = orderBy == null ? eQuery : orderBy(eQuery);
            var pageList = eQuery.
                Skip((pageindex - 1) * pagesize).
                Take(pagesize).
                ToList();

            return pageList;
        }

        public bool Update<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
