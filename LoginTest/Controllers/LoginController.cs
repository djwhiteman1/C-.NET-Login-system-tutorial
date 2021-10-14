using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginTest.Models;
using LoginTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginTest.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(userModel)){
                return View("LoginSuccess", userModel);
            }
            else {
                return View("LoginFailure", userModel);
            }
        }
    }
}
