using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;
using ShoppingCart.Models.Repository;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<int> Add([FromBody] List<Order> orders)
        {
            return await _orderRepository.Add(orders);
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = "Admin")]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderRepository.Get();
        }
    }
}
