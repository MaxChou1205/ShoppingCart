using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public interface IOrderRepository
    {
        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="order">g 實體</param>
        Task<int> Add(List<Order> orders);

        /// <summary>
        /// 取得所有 Blog
        /// </summary>
        /// <param name="blogQuery">查詢條件</param>
        Task<IEnumerable<Order>> Get();
    }
}
