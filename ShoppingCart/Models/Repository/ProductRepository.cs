using Dapper;
using ShoppingCart.Helpers;
using ShoppingCart.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IDatabaseHelper _databaseHelper;
        public ProductRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            using (IDbConnection conn = _databaseHelper.GetConnection())
            {
                string sql = @"
                            SELECT *
                            FROM Product";

                var products = await conn.QueryAsync<Product>(sql);

                return products;
            }
        }
    }
}
