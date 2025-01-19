using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Task2.Entities.Abstracts
{
    public abstract class Person
    {
         protected Person() { Id = Guid.NewGuid(); } 
        public Guid Id { get; set; }

        [Required]
        public int CityId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Number { get; set; }

    }
}
