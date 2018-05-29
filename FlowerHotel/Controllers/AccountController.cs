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
using FlowerHotel.BLL.Services;

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

        private IEmployeeService EmployeeService
        {
            get
            {
                return new ServiceCreator().CreateEmployeeService("DefaultConnection");
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
                    var user = new UserModel
                    {
                        UserName = model.Email
                    };
                    var result = new JsonResult();
                    if (User.IsInRole("user"))
                    {
                        user.Role = "user";
                    }
                    if (User.IsInRole("employee"))
                    {
                        user.Role = "employee";
                    }
                    if (User.IsInRole("admin"))
                    {
                        user.Role = "admin";
                    }
                    result.Data = user;
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
        public async Task<JsonResult> Register(RegisterModel model, int hotelId = 0)
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
                    TelephoneNumber = model.PhoneNumber
                };
                userDto.Role = hotelId != 0 ? "employee" : "user";
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    {
                        if (hotelId != 0)
                        {
                            string userId = operationDetails.Message;
                            await EmployeeService.Create(new EmployeeDTO
                            {
                                ApplicationUserId = userId,
                                HotelId = hotelId
                            });
                        }
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