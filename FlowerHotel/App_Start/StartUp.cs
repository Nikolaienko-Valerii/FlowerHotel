using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using FlowerHotel.BLL.Services;
using Microsoft.AspNet.Identity;
using FlowerHotel.BLL.Interfaces;


[assembly: OwinStartup(typeof(FlowerHotel.App_Start.Startup))]

namespace FlowerHotel.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ExternalBearer,
                //LoginPath = new PathString("/Account/Login"),
                CookieHttpOnly = false,
                CookieSecure = CookieSecureOption.Never,
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}