using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL<T> where T:class
    {
        /// <summary>
        /// 根据条件返回实体集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> GetEntitysWhere(Expression<Func<T, bool>> predicate) {
            DAVES db = new DAVES();
            return db.Set<T>().Where(predicate).ToList();
        }
        public List<T> GetEntitysWhereAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            DAVES db = new DAVES();
            return db.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            DAVES db = new DAVES();
            return db.Set<T>().ToList();
        }
        /// <summary>
        /// 查询一个实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetEntity(object Id)
        {
            DAVES db = new DAVES();
            return db.Set<T>().Find(Id);
        }
        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(T entity)
        {
            DAVES db = new DAVES();
            db.Set<T>().Add(entity);
            return db.SaveChanges()>0;
        }
        /// <summary>
        /// 新增多个实体
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool Inserts(List<T> entitys)
        {
            DAVES db = new DAVES();
            db.Set<T>().AddRange(entitys);
            return db.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(object Id)
        {
            DAVES db = new DAVES();
            T entity = db.Set<T>().Find(Id);
            db.Set<T>().Remove(entity);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            DAVES db = new DAVES();
            db.Entry<T>(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

    }
}
