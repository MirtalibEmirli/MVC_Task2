using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Task2.Entities.Concretes;

namespace MVC_Task2.Controllers
{
    public class HomeController : Controller
    {
        List<User> Users { get; set; }  
        public IActionResult Index()
        {
            var text = Read();
            var users = JsonSerializer.Deserialize<List<User>>(text);
            Users=users.ToList();   
            return View(users);
        }
        public string Read()
        {
            string path = @"Helpers\users.json";
            string json = System.IO.File.ReadAllText(path);
            return json;    
        }

         
    }
}
