using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ProductsValidation.Models;
using ProductsValidation.Services;
using System.ComponentModel.DataAnnotations;

namespace ProductsValidation.Controllers
{
    public class UsersController : Controller
    {
        private List<User> users;

        public UsersController(Data data)
        {
            users = data.Users;
        }

        public IActionResult Index(string id)
        {
            return View("Index", users);
        }
        [HttpGet]
        public IActionResult AddUsers(string Name, string Email, int Id, string Role, User user)
        {
            User newUser;
            if (user != null)
            {
                newUser = user;
            }
            else
            {
                newUser = new User() { Name = Name, Email = Email, Id = Id, Role = Role };
            }
            return View(newUser);
        }
        [HttpPost]
        public IActionResult AddUsers([FromQuery] User user)
        {
            if (!string.IsNullOrEmpty(user.Name))
                users.Add(user);
            return View("Index", users);
            

            // https://localhost:44309/users/AddUsers?Id=2&Name=Lex&Email=mail@google.com&Role=admin
            // https://localhost:44309/users/AddUsers?user.Id=1&user.Name=Lex&user.Email=mail@google.com&user.Role=admin
        }
    }
}
