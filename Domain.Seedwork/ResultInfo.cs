using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Seedwork
{
    /// <summary>
    /// 结果信息封装类
    /// </summary>
    public class ResultInfo
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 额外的返回信息（根据时间情况使用，例如可能需要返回一个ID）
        /// </summary>
        public object[] ExtraFeedback { get; set; }
    }
}
