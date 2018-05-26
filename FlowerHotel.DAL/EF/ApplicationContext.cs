using System.Data.Entity;
using FlowerHotel.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FlowerHotel.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("DefaultConnection") { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Resource> Resources { get; set; }       
    }
}
