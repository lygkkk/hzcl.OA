using System;
using System.Linq;
using System.Linq.Expressions;
using hzcl.OA.IDAL;

namespace hzcl.OA.IBLL
{
    public interface IBaseService<T> where T:class, new()
    {
        IDBSession CurrentDbSession { get; }
        IDAL.IBaseDal<T> CurrentDal { get; set; }
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int pageCount,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);

        bool DeleteEntity(T entity);

        bool EditEntity(T entity);

        T AddEntity(T entity);
    }
}