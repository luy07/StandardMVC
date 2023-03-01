using Domain.Seedwork;
using Domain.Seedwork.Specification;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Seedwork
{

    /// <summary>
    ///    Repository base class
    /// </summary>
    /// <typeparam name="TEntity">The type of underlying entity in this repository</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region Members
        private IQueryableUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        /// <summary>
        ///    Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null) { throw new ArgumentNullException("unitOfWork"); }

            _unitOfWork = unitOfWork;
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// 释放对象
        /// </summary>
        public void Dispose()
        {
            if (_unitOfWork != null) { _unitOfWork.Dispose(); }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        private IDbSet<TEntity> GetSet()
        {
            return _unitOfWork.CreateSet<TEntity>();
        }
        #endregion

        #region IRepository Members
        /// <summary>
        /// 数据操作对象
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(TEntity item)
        {

            if (item != (TEntity)null)
            {
                GetSet().Add(item); // add new item in this set
            }
            else
            {
                //LoggerFactory.CreateLog().LogInfo(Messages.info_CannotAddNullEntity, typeof(TEntity).ToString());
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item"></param>
        public virtual void Remove(TEntity item)
        {
            if (item != (TEntity)null)
            {
                //attach item if not exist
                _unitOfWork.Attach(item);

                //set as "removed"
                GetSet().Remove(item);
            }
            else
            {
                //LoggerFactory.CreateLog().LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// 将对象附加到数据操作上下文
        /// </summary>
        /// <param name="item"></param>
        public virtual void TrackItem(TEntity item)
        {
            if (item != (TEntity)null)
            {
                _unitOfWork.Attach<TEntity>(item);
            }
            else
            {
                //LoggerFactory.CreateLog().LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        public virtual void Modify(TEntity item)
        {
            if (item != (TEntity)null)
            {
                _unitOfWork.SetModified(item);
            }
            else
            {
                //LoggerFactory.CreateLog().LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// 获取单个实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                return GetSet().Find(id);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet();
        }

        /// <summary>
        /// 使用规约查询
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> AllMatching(ISpecification<TEntity> specification)
        {
            return GetSet().Where(specification.SatisfiedBy());
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TKProperty"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        public virtual PagedResult<TEntity> GetPaged<TKProperty>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKProperty>> orderBy, bool descending)
        {
            var set = GetSet();

            PagedResult<TEntity> result = new PagedResult<TEntity>();

            var queryableSet = set.Where(where);

            if (descending)//倒序
            {
                result.Data = queryableSet.Where(where).OrderByDescending(orderBy).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }
            else
            {
                result.Data = queryableSet.OrderBy(orderBy).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }

            result.PageIndex = pageIndex;
            result.PageIndex = pageSize;
            result.TotalRecord = queryableSet.Count();

            return result;
        }

        #region 重载两个方便操作的分页查询方法
        public virtual PagedResult<TEntity> GetPaged<TKProperty>(int pageIndex, int pageSize, ISpecification<TEntity> specification, Expression<Func<TEntity, TKProperty>> orderBy, bool descending)
        {
            return GetPaged(pageIndex, pageSize, specification.SatisfiedBy(), orderBy, descending);
        }

        public virtual PagedResult<TEntity> GetPaged<TKProperty>(PagedResult<TEntity> inputPageInfo, ISpecification<TEntity> specification, Expression<Func<TEntity, TKProperty>> orderBy, bool descending)
        {
            return GetPaged(inputPageInfo.PageIndex, inputPageInfo.PageSize, specification.SatisfiedBy(), orderBy, descending);
        }
        #endregion



        /// <summary>
        /// 表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter);
        }

        /// <summary>
        /// 合并对象（更新操作时）
        /// </summary>
        /// <param name="persisted"></param>
        /// <param name="current"></param>
        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _unitOfWork.ApplyCurrentValues(persisted, current);
        }
        #endregion


    }

}