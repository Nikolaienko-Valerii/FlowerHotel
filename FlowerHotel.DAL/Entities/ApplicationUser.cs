using Microsoft.AspNet.Identity.EntityFramework;

namespace FlowerHotel.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
