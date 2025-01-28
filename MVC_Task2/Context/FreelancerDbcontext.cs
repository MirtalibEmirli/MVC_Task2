using Microsoft.EntityFrameworkCore;
using MVC_Task2.Entities.Concretes;

namespace MVC_Task2.Context
{
    public class FreelancerDbcontext:DbContext
    {
        public FreelancerDbcontext(DbContextOptions<FreelancerDbcontext> options):base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Citys { get; set; }  
    }
}
