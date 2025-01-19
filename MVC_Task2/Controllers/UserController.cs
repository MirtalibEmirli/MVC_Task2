using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Task2.DTO;
using MVC_Task2.Entities.Concretes;
using MVC_Task2.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            var sCities = new List<SelectListItem>();
            foreach (var item in cities)
            {
                sCities.Add(new SelectListItem { Text = item.Name, Value = item.AreaCode.ToString() });
            }

            var vm = new UserAddViewModel()
            {
                Cities = sCities,
                User = new User(),
             
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(UserAddViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = userVM.User;
                Users = ReadAllUsers();
                Users.Add(user);
                WriteAllUsers();

                return Redirect("/home/index");
            }
            else
            {
                var sCities = new List<SelectListItem>();
                foreach (var item in cities)
                {
                    sCities.Add(new SelectListItem { Text = item.Name, Value = item.AreaCode.ToString() });
                }

                var vm = new UserAddViewModel()
                {
                    Cities = sCities,
                    User = new User(),

                };
                return View(vm);
            }






            }


        public IActionResult Details(Guid id)
        {

            if (id != Guid.Empty)
            {
                var user = ReadByID(id);
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
            else { ReadAllUsers(); return Json(Users); }


        }

        public IActionResult Back()
        {
            return Redirect("/home/index");
        }

        public User ReadByID(Guid id)
        {
            var users = ReadAllUsers();
            var user = users.First(u => u.Id == id);
            return user ?? new User();
        }

        public List<User> ReadAllUsers()
        {

            string path = @"Helpers\users.json";
            string text = System.IO.File.ReadAllText(path);
            var users = JsonSerializer.Deserialize<List<User>>(text).ToList();

            return users ?? new List<User>(); ;
        }

        public void WriteAllUsers()
        {
            string path = @"Helpers\users.json";
            var options = new JsonSerializerOptions() { WriteIndented = true };
            var data = JsonSerializer.Serialize(Users, options);
            System.IO.File.WriteAllText(path, data);
            Console.WriteLine(data);
        }

    }


}
