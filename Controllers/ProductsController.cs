using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductsValidation.Models;
using ProductsValidation.Services;

namespace ProductsValidation.Controllers
{
    
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(myProducts);
        }

        [HttpPost]
        public IActionResult Index(ProductCatregoryPricesModel model)
        {
            ViewBag.CategoryType = model.CategoryType;
            var products = new List<Product>();
            if (!string.IsNullOrEmpty(model.CategoryType))
            {
                products = myProducts.Where(x => x.Type == model.Category).ToList();
            }
            else
            {
                foreach (var price in model.Prices)
                {
                    var product = myProducts.FirstOrDefault(x => x.Id == price.Key);
                    if (product != null)
                    {
                        product.Price = price.Value;
                        products.Add(product);
                    }
                }
            }

            return View("Index", products);
        }

        public IActionResult View(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        } 
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;
                return View("View", product);
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                myProducts.Add(product);
                return View("View", product);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View(new Product(){Id = myProducts.Last().Id + 1});
        }

        public IActionResult Delete(int id)
        {
            myProducts.Remove( myProducts.Find(product => product.Id == id));
            return View("View", myProducts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
