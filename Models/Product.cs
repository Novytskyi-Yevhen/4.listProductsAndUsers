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
    public class Product : IValidatableObject
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

        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (Description == null) return errors;
            if (Name == Description)
            {
                errors.Add(new ValidationResult(errorMessage: "Fields Name and Description cannot be equal!", new List<string>() { "Description" }));
            }
            string[] array = Description.Split(' ');
            if (array.Select(s => s.Length).Sum() < 3)
            {
                errors.Add(new ValidationResult(errorMessage: "Description cannot be less than 3 symbols!", new List<string>() { "Description" }));
            }
            if (Name != array[0])
            {
                errors.Add(new ValidationResult(errorMessage: "Description does not start from name!", new List<string>() { "Description" }));
            }
           
            return errors;
        }

    }
}
