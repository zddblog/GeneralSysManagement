using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace General.NetCore.Data
{
    /// <summary>
    /// EFCore数据操作基本仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<TModel> where TModel: class
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="TModelModel"></param>
        void Add(TModel TModelModel);



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        void Delete(object Id);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="TModelModel"></param>
        void Update(TModel TModelModel);



        /// <summary>
        /// 根据主键查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <reTModelurns></reTModelurns>
        TModel GetSingle(object Id);


        /// <summary>
        /// 返回列表
        /// </summary>
        /// <reTModelurns></reTModelurns>
        IEnumerable<TModel> GetList();

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        DbContext dbContext { get; }

        /// <summary>
        /// 获取该实体类型
        /// </summary>
        DbSet<TModel> Entities { get; }
    }
}
