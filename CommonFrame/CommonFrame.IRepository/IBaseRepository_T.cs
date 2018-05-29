using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrame.IRepository
{
    public interface IBaseRepository_T<T> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        bool Insert(T entity);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>实体</returns>
        T InsertReturnEntity(T entity);

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool InsertIQueryable(List<T> lstentity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        bool Update(T entity);

        /// <summary>
        /// 修改集合
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns>布尔值（修改结果）</returns>
        bool UpdateIQueryable(List<T> entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>布尔值（删除结果）</returns>
        bool Delete(T entity);

        /// <summary>
        /// 删除集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteIQueryable(List<T> entity);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="Lambda">表达式</param>
        /// <returns>数据实体</returns>
        T Query(Expression<Func<T, bool>> Lambda);

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>数据列表</returns>
        List<T> QueryList(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询sql语句(集合)
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="entity">数据实体</param>
        /// <returns>数据列表</returns>
        List<T> QueryListSql(string sql);

        /// <summary>
        /// 查询sql语句（单条）
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="entity">数据实体</param>
        /// <returns>数据</returns>
        T QueryFirstSql(string sql);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="name">存储过程名称</param>
        /// <param name="para">参数</param>
        int execproc(string name, string word, SqlParameter[] para);
    }
}
