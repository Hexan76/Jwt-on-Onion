using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICRUD
    {
        /// <summary>
        /// Find the Class object using predicate paramteres by lambda and return it.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        /// <summary>
        /// return a collection of entity.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        ICollection<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null) where TEntity : class;
        /// <summary>
        /// input entity will create.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Create<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// Input entity will Delete ! , you must get it first and pass it.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// Input entity will Update, before update you must get it .
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        ICollection<TEntity> GetPageList<TEntity>(int pagesize, int pageindex, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null) where TEntity : class;

    }
}
