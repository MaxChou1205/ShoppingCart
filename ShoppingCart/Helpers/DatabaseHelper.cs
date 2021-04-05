using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Helpers
{
    public interface IDatabaseHelper
    {
        /// <summary>
        /// 取得連線
        /// </summary>
        /// <returns></returns>
        IDbConnection GetConnection();
    }

    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            var conn = new SqlConnection(this._connectionString);

            return conn;
        }
    }
}
