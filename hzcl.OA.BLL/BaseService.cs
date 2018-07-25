using System;
using System.Linq;
using System.Linq.Expressions;
using hzcl.OA.DALFactory;
using hzcl.OA.IDAL;

namespace hzcl.OA.BLL
{
    public abstract class BaseService<T> where T:class, new()
    {
        public IDBSession CurrentDbSession
        {
            get
            {
                //return new DBSession();
                return DBSessionFactory.CreateDbSession();
            }
        }

        public IDAL.IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();

        public BaseService()
        {
            SetCurrentDal();
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int pageCount,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<s>(pageIndex, pageSize, out pageCount, whereLambda, orderbyLambda, isAsc);
        }


        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return CurrentDbSession.SaveChanges();
        }

        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return CurrentDbSession.SaveChanges();
        }

        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            CurrentDbSession.SaveChanges();
            return entity;
        }
    }
}