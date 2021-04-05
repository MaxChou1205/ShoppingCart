using Dapper;
using ShoppingCart.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public OrderRepository(IDatabaseHelper databaseHelper)
        {
            this._databaseHelper = databaseHelper;
        }

        public async Task<int> Add(List<Order> orders)
        {
            // TODO: change "CreatedBy" value by specified user

            foreach(var order in orders.ToList())
            {
                if (order.Amount == 0)
                {
                    orders.Remove(order);
                }
                else
                {
                    order.Price = order.Price * order.Amount;
                    order.CreatedBy = "User";
                }
            }

            using (IDbConnection conn = this._databaseHelper.GetConnection())
            {
                string sql = @"
                                INSERT INTO ""Order""
                                VALUES (
                                    @Name,
                                    @Price,
                                    @Amount,
                                    @CreatedBy
                                );";

                var count = await conn.ExecuteAsync(
                    sql, orders);

                return count;
            }
        }

        public async Task<IEnumerable<Order>> Get()
        {
            using (IDbConnection conn = _databaseHelper.GetConnection())
            {
                string sql = @"
                            SELECT *
                            FROM ""Order"" ";

                var orders = await conn.QueryAsync<Order>(sql);

                return orders;
            }
        }
    }
}
