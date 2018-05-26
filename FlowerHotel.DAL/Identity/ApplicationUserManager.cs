using FlowerHotel.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace FlowerHotel.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
