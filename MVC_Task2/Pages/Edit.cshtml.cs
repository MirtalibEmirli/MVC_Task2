using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC_Task2.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MVC_Task2.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public User User { get; set; } = new User();   
        public List<User> Users { get; set; } = new List<User>();

        public void OnGet(Guid id)
        {
           

            Users = ReadAllUsers();
            User = Users.FirstOrDefault(x => x.Id == id);

          
        }

        public IActionResult OnPost()
        {
            Users = ReadAllUsers();
            var existingUser = Users.FirstOrDefault(u => u.Id == User.Id);

            if (existingUser != null)
            {
          
                existingUser.FirstName = User.FirstName;
                existingUser.LastName = User.LastName;
                existingUser.Description = User.Description;
                existingUser.Img = User.Img;
            }
            else
            { 
                Users.Add(User);
            }

            WriteAllUsers();  
            return RedirectToPage("Page1");
        }



        public List<User> ReadAllUsers()
        {
            string path = @"Helpers\users.json";

            if (!System.IO.File.Exists(path))
            {
                return new List<User>();
            }

            string text = System.IO.File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<User>>(text) ?? new List<User>();
        }

        public void WriteAllUsers()
        {
            string path = @"Helpers\users.json";
            var options = new JsonSerializerOptions { WriteIndented = true };
            var data = JsonSerializer.Serialize(Users, options);
            System.IO.File.WriteAllText(path, data);
        }
    }
}
