using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        [Description]
        public string Description { get; set; }
        [Range(0, 100000.00)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
    }
}
