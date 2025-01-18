using MVC_Task2.Entities.Abstracts;
using System;
using System.Collections.Generic;

namespace MVC_Task2.Entities.Concretes
{
    [Serializable]
    public class User : Person
    {
        public string Github { get; set; }
        public string LinkedIn { get; set; }
        public string Description { get; set; }
        public List<string> Skills { get; set; }
        public string Img { get; set; }
    }
}
