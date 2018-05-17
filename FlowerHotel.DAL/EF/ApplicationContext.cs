using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using FlowerHotel.DAL.Entities;

namespace FlowerHotel.DAL.EF
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Resource> Resources { get; set; }

        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new StoreDbInitializer());
        }
        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {

    }
}
