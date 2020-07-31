using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBLL<T> where T : class
    {
        BaseDAL<T> _dal = null;

        public BaseBLL(BaseDAL<T> dal) {
            _dal = dal;
        }
        /// <summary>
        /// 根据条件返回实体集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual List<T> GetEntitysWhere(Expression<Func<T, bool>> predicate)
        {
            return _dal.GetEntitysWhere(predicate);
        }
        
        public virtual List<T> GetEntitysWhereAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _dal.GetEntitysWhereAsNoTracking(predicate);
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll()
        {
            return _dal.GetAll();
        }
        /// <summary>
        /// 查询一个实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetEntity(object Id)
        {
            return _dal.GetEntity(Id);
        }
        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(T entity)
        {
            return _dal.Insert(entity);
        }
        /// <summary>
        /// 新增多个实体
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool Inserts(List<T> entitys)
        {
            return _dal.Inserts(entitys);
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(object Id)
        {
            return _dal.Delete(Id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            return _dal.Update(entity);
        }
    }
}
