using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using FlowerHotel.Models;
using System.Security.Claims;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.Infrastructure;
using FlowerHotel.BLL.DTO;

namespace FlowerHotel.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    var result = new JsonResult();
                    string roles = "";
                    if (User.IsInRole("user"))
                    {
                        roles += "user";
                    }
                    if (User.IsInRole("employee"))
                    {
                        roles += "employee";
                    }
                    if (User.IsInRole("admin"))
                    {
                        roles += "admin";
                    }
                    result.Data = roles;
                    return result;
                }
            }
            return new JsonResult();
        }

        public JsonResult Logout()
        {
            AuthenticationManager.SignOut();
            return new JsonResult();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Surname = model.Surname,
                    Name = model.Name,
                    TelephoneNumber = model.PhoneNumber,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    {
                    var res = new JsonResult
                    {
                        Data = ""
                    };
                    return res;
                    }
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            var result = new JsonResult
            {
                Data = "error"
            };
            return result;
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                Password = "!Password1",
                Name = "Valerii",
                Surname = "Nikolaienko",
                Role = "admin",
            }, new List<string> { "user", "admin", "emloyee" });
        }
    }
}