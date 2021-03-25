using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Route("addOrder")]
        public void AddOrder([FromBody] List<Dictionary<string, object>> parameters)
        {
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Cart;Integrated Security=true"))
            {
                var data = new List<Dictionary<string, object>>();
                foreach (var parameter in parameters)
                {
                    data.Add(new Dictionary<string, object>
                    {
                        {"id", parameter["id"]},
                        {"amount", parameter["amount"]}
                    });
                
                }
                string strSql = "INSERT INTO Order(ID,Amount) VALUES (@id,@amount);";
                conn.Execute(strSql, data);
            }
        }

        [HttpGet]
        [Route("getOrders")]
        public APIResult GetOrders()
        {
            var result = new APIResult();
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Cart;Integrated Security=true"))
            {
                string strSql = "Select * from Order";
                result.Data = conn.Query(strSql).ToList();
                result.IsSucceed = true;
            }
            return result;
        }
    }
}
