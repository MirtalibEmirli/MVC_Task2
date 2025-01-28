using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using MVC_Task2.Context;
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
    //[Route("mvc/[controller]/[action]")]// bu formada isleyir amma actionnu silsek biz gerek 
    //her bir action uzerinde route yazaqki taninsin
    public class UserController: Controller
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
        private readonly FreelancerDbcontext dbcontext ;
        public UserController(FreelancerDbcontext freelancerDbcontext)
        {
            dbcontext=freelancerDbcontext;
        }
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
        [Route("user")]
        [Route("work")]
        public IActionResult Render()
        {
           var users = ReadAllUsers();
            return Json(users); 
        }
        [HttpGet]
        public IActionResult EditUser(Guid id)
        {

            if (id != Guid.Empty)
            {
                Users = ReadAllUsers();

                var user = Users.FirstOrDefault(u => u.Id == id);
                Console.WriteLine(user.Id + " IN GET");
                var sCities = new List<SelectListItem>();
                foreach (var item in cities)
                {
                    sCities.Add(new SelectListItem { Text = item.Name, Value = item.AreaCode.ToString() });

                }

                var vm = new UserEditViewModel()
                {
                    Cities = sCities,
                    User = user,
                };
                return View(vm);
            }
            else { return Redirect("/home/index"); }
        }

        [HttpPost]
        public IActionResult EditUser(UserEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = vm.User;



                Users = ReadAllUsers();

                
                var userToRemove = Users.FirstOrDefault(u => u.Id == user.Id);
                if (userToRemove != null)
                {
                    Users.Remove(userToRemove);
                }


                Users.Add(user);

                WriteAllUsers();
            }

            return Redirect("/home/index");
        }

        public IActionResult Delete(Guid id)
        {

            if (id != Guid.Empty)
            {
                Console.WriteLine(id + "deleted user id");


                Users = ReadAllUsers();

                var userToRemove = Users.FirstOrDefault(u => u.Id == id);
                if (userToRemove != null)
                {
                    Users.Remove(userToRemove);
                    Console.WriteLine("deleted user");

                }

                WriteAllUsers();
            }
            return Redirect("/home/index");
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

        }



    }


}
