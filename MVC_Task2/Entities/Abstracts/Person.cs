using System.Collections.Generic;

namespace MVC_Task2.Entities.Abstracts
{
    public abstract class Person
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }

    }
}
