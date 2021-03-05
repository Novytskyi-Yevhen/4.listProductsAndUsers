using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductsValidation.Models
{
    public class Product
    {
        public enum Category { Toy, Technique, Clothes, Transport }

        public int Id { get; set; }
        public Category Type { get; set; }
        [Required]
        public string Name { get; set; }
        [MinLength(2, ErrorMessage = "The value must contain more than 2 characters.")]
        public string Description { get; set; }
        [Range(0.0, 100000.0)]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid format is: 999.99")]
        public decimal Price { get; set; }
    }
}
