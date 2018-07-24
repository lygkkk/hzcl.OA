using System;
using System.Linq;
using System.Linq.Expressions;


namespace hzcl.OA.IDAL
{
    public interface IBaseDal<T> where T : class ,new()
    {
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int pageCount,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda,
            bool isAsc);

        bool DeleteEntity(T entity);
        bool EditEntity(T entity);
        T AddEntity(T entity);
    }
}