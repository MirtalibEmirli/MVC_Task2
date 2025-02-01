using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC_Task2.Context;
using MVC_Task2.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MVC_Task2.Pages
{
    public class Page1Model : PageModel
    {
        public Page1Model(FreelancerDbcontext freelancerDbcontext)
        {
            dbcontext = freelancerDbcontext;
        }
        private readonly FreelancerDbcontext dbcontext;
        public string Message { get; set; }
        public string Info { get; set; }
        public List<User> Users { get; set; }
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
            Users = ReadAllUsers(); 
            Message = $"Now Date  is {DateTime.Now.Date.Day}/{DateTime.Now.Date.Month}";
            Info = "A";
        }

        public IActionResult OnPost()
        {
            Users.Add(User);
          WriteAllUsers();
            Message = $"{User.FirstName} added";
            return RedirectToPage("Page1");

        }
        public IActionResult OnPostDelete(Guid id)
        {
            Users = ReadAllUsers();
            var userToDelete = Users.FirstOrDefault(x => x.Id == id);
            if (userToDelete != null)
            {
                Users.Remove(userToDelete);
                WriteAllUsers();
            }
            return RedirectToPage();

        }
        public List<User> ReadAllUsers()
        {
            string path = @"Helpers\users.json";
            string text = System.IO.File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<User>>(text) ?? new List<User>();
        }

        public void WriteAllUsers()
        {
            string path = @"Helpers\users.json";
            var options = new JsonSerializerOptions() { WriteIndented = true };
            string data = JsonSerializer.Serialize(Users);
            System.IO.File.WriteAllText(path, data);
        }
    }   
}  
