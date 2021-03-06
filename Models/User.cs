using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.Models
{
    
    public class User
    {
        [FromQuery]
        public int Id { get; set; }
        [FromQuery]
        public string Name { get; set; }
        [FromQuery]
        public string Email { get; set; }
        [FromQuery]
        public string Role { get; set; }
    }
}
