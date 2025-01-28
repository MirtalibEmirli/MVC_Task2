using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC_Task2.Context;
using MVC_Task2.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Users = dbcontext.Users.ToList();
            Message = $"Now Date  is {DateTime.Now.Date.Day}/{DateTime.Now.Date.Month}";
            Info = "A";
        }

        public IActionResult OnPost()
        {
            dbcontext.Users.Add(User);  
            dbcontext.SaveChanges();
            Message =$"{User.FirstName} added";
            return RedirectToPage("Page1");

        }
    }
}
