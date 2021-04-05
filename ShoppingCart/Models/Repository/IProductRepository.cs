using ShoppingCart.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
    }
}
