using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerHotel.DAL.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public ICollection<Plant> Plants { get; set; }
        public ICollection<Order> Orders { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
