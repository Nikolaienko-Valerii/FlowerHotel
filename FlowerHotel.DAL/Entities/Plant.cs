using System.Collections.Generic;

namespace FlowerHotel.DAL.Entities
{
    public class Plant
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
