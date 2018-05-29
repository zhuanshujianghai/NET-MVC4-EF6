using CommonFrame.IRepository;
using CommonFrame.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrame.Repository
{
    public class SqlServerRepository_T<T> : IBaseRepository_T<T> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值</returns>
        public bool Insert(T entity)
        {
            bool result = false;
            using (CommonEntities db = new CommonEntities())
            {
                db.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        public T InsertReturnEntity(T entity)
        {
            using (CommonEntities db = new CommonEntities())
            {
                db.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return entity;
            }
        }
        /// <summary>
        /// 添加集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertIQueryable(List<T> lstentity)
        {
            bool result = false;
            using (CommonEntities db = new CommonEntities())
            {
                foreach (var item in lstentity)
                {
                    db.Entry<T>(item).State = System.Data.Entity.EntityState.Added;
                }
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public bool Update(T entity)
        {
            bool result = false;
            using (CommonEntities db = new CommonEntities())
            {
                db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }
        /// <summary>
        /// 修改集合
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        public bool UpdateIQueryable(List<T> entity)
        {
            bool result = false;
            using (CommonEntities db = new CommonEntities())
            {
                foreach (var item in entity)
                {
                    db.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        public bool Delete(T entity)
        {
            bool result = false;
            using (CommonEntities db = new CommonEntities())
            {
                db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }
        /// <summary>
        /// 删除集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteIQueryable(List<T> entity)
        {
            bool result = false;
            using (CommonEntities db = new CommonEntities())
            {
                foreach (var item in entity)
                {
                    db.Entry<T>(item).State = System.Data.Entity.EntityState.Deleted;
                }
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="Lambda">表达式</param>
        /// <returns>数据实体</returns>
        public T Query(Expression<Func<T, bool>> whereLambda)
        {
            using (CommonEntities db = new CommonEntities())
            {
                return db.Set<T>().FirstOrDefault(whereLambda);
            }
        }

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>数据列表</returns>
        public List<T> QueryList(Expression<Func<T, bool>> whereLambda)
        {
            using (CommonEntities db = new CommonEntities())
            {
                return db.Set<T>().Where(whereLambda).ToList();
            }
        }

        /// <summary>
        /// 查询sql语句(集合)
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="entity">数据实体</param>
        /// <returns>数据列表</returns>
        public List<T> QueryListSql(string sql)
        {
            using (CommonEntities db = new CommonEntities())
            {
                return db.Database.SqlQuery<T>(sql).ToList();
            }
        }

        /// <summary>
        /// 查询sql语句（单条）
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="entity">数据实体</param>
        /// <returns>数据</returns>
        public T QueryFirstSql(string sql)
        {
            using (CommonEntities db = new CommonEntities())
            {
                return db.Database.SqlQuery<T>(sql).FirstOrDefault();
            }
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            using (CommonEntities db = new CommonEntities())
            {
                return db.Set<T>().Any(anyLambda);
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="name">存储过程名称</param>
        /// <param name="para">参数</param>
        public int execproc(string name, string word, SqlParameter[] para)
        {
            using (CommonEntities db = new CommonEntities())
            {
                try
                {
                    return db.Database.ExecuteSqlCommand(name + " " + word, para);
                }
                catch (Exception)
                {
                    return -1024;
                }
            }
        }
    }
}
