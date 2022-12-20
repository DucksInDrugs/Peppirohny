using Entities;
using Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Peppirohny.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Peppirohny.Controllers
{
    public class UserController: Controller
    {
        private IUserBLL _bll;
        public UserController(IUserBLL bll)
        {
            _bll = bll;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = _bll.GetByLogin(loginModel.Login);

            if (user != null && user.password == loginModel.Password)
            {
                var identity = new CustomUserIdentity(user);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }
            return RedirectToAction("StartGame", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel registrationModel)
        {
            User newUser = new User()
            {
                name = registrationModel.FIO,
                login = registrationModel.login,
                password = registrationModel.password,
                creationDate = DateTime.Now
            };
            _bll.PutUser(newUser);
            var identity = new CustomUserIdentity(newUser);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return RedirectToAction("StartGame", "Home");
        }


        public IActionResult Get(int id)
        {
            var user = _bll.GetByID(id);

            if (user != null)
            {
                return View(new UserModel() { id = user.id, fullName = $"{user.name}" });
            }
            else
            {
                return View();
            }
        }
    }
}
