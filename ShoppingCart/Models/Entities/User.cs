using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class User
    {
        [Required(ErrorMessage = "UserName 必填")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
