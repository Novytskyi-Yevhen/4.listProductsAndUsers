using System;
using System.Collections.Generic;

namespace ProductsValidation.Models
{
    public class ProductCatregoryPricesModel
    {
        public string CategoryType { get; set; }
        public Dictionary<int, decimal> Prices { get; set; }

        public Product.Category Category
        {
            get
            {
                var result = !string.IsNullOrEmpty(CategoryType) && Enum.TryParse(typeof(Product.Category), CategoryType, out var categoryType)
                    ? (Product.Category) categoryType
                    : Product.Category.Toy;
                return result;
            }
        }
    }
}
