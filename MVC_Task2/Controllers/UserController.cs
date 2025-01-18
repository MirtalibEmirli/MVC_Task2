using Microsoft.AspNetCore.Mvc;
using MVC_Task2.DTO;
using MVC_Task2.Entities.Concretes;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MVC_Task2.Controllers
{
    public class UserController : Controller
    {
        List<City> cities = new List<City>
        {
            new City { AreaCode = 101, Name = "New York" },
            new City { AreaCode = 102, Name = "Los Angeles" },
            new City { AreaCode = 103, Name = "Chicago" },
            new City { AreaCode = 104, Name = "Houston" },
            new City { AreaCode = 105, Name = "Phoenix" },
            new City { AreaCode = 106, Name = "Philadelphia" },
            new City { AreaCode = 107, Name = "San Antonio" },
            new City { AreaCode = 108, Name = "San Diego" },
            new City { AreaCode = 109, Name = "Dallas" },
            new City { AreaCode = 110, Name = "San Jose" },
            new City { AreaCode = 111, Name = "Austin" },
            new City { AreaCode = 112, Name = "Jacksonville" },
            new City { AreaCode = 113, Name = "Fort Worth" },
            new City { AreaCode = 114, Name = "Columbus" },
            new City { AreaCode = 115, Name = "Indianapolis" },
            new City { AreaCode = 116, Name = "Charlotte" },
            new City { AreaCode = 117, Name = "San Francisco" },
            new City { AreaCode = 118, Name = "Seattle" },
            new City { AreaCode = 119, Name = "Denver" },
            new City { AreaCode = 120, Name = "Washington D.C." }
        };
        List<User> Users { get; set; }
        [HttpGet]  
        public IActionResult Add()
        {
            return View();
        }


        public IActionResult Details(int id=-1) {

            if (id!=-1)
            {
                var user = Read(id);
                UserDTO userDTO = new UserDTO
                {
                    FirstName = user.FirstName,
                    LinkedIn = user.LinkedIn,
                    Github = user.Github,
                    Number = user.Number,
                };
                userDTO.City = cities.FirstOrDefault(city => city.AreaCode == user.CityId).Name;
                return View(userDTO);

            }
            else { Read(); return Json(Users); }
            
            
        }
        public User Read(int id=-1)
        {
            string path = @"Helpers\users.json";
            string text = System.IO.File.ReadAllText(path);
            var users = JsonSerializer.Deserialize<List<User>>(text);
            Users = users;
            var user = users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public IActionResult Back()
        {
            return Redirect("/home/index");
        }



    }


}
