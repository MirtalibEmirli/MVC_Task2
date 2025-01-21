using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Task2.Entities.Concretes;
using System.Collections.Generic;

namespace MVC_Task2.Models
{
    public class UserEditViewModel
    {
        public User User { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}
