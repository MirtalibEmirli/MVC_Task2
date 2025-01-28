using MVC_Task2.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Entities.Concretes
{
    [Serializable]
    public class User : Person
    {
        public string Github { get; set; }
        public string LinkedIn { get; set; }
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public List<string> Skills { get; set; } = new List<string>() { "C#",
      "ASP.NET Core",
      "React.js"};
        public string Img { get; set; } = "https://www.shutterstock.com/image-vector/user-profile-icon-vector-avatar-600nw-2247726673.jpg";
    }
}
