using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using hzcl.OA.Model;

namespace hzcl.OA.DAL
{
    public class BaseDal<T> where T : class, new()

    {
        //hzclEntities db = new hzclEntities();
        DbContext db = DAL.DBContextFactory.CreateDbContext();
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            db.Set<T>().Add(entity);
            //db.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Deleted;
            return true;
            //return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public bool EditEntity(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            return true;
            //return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 查询过滤
        /// </summary>
        /// <param name="whereLambda">lamabda表达式</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where<T>(whereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="s">需要排序的列名</typeparam>
        /// <param name="pageIndex">当前网页索引</param>
        /// <param name="pageSize">显示最大行数</param>
        /// <param name="pageCount">总页数</param>
        /// <param name="whereLambda">lambda条件表达式</param>
        /// <param name="orderbyLambda">lambda排序表达式</param>
        /// <param name="isAsc">升序</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int pageCount,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            pageCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize)
                    .Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize)
                    .Take<T>(pageSize);
            }

            return temp;
        }
    }
}