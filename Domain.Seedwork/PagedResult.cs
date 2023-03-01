using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Seedwork
{
    public class PagedResult<TEntity>
    {
        public IEnumerable<TEntity> Data { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        /// <summary>
        /// 符合条件的总记录数
        /// </summary>
        public int TotalRecord { get; set; }
        /// <summary>
        /// 符合条件的总页数
        /// </summary>
        public int TotalPage
        {
            get
            {
                if (TotalRecord==0)
                {
                    return 0;
                }

                if (TotalRecord<PageSize)
                {
                    return 1;
                } 

                return TotalRecord / PageSize;
            }
        }
    }
}
