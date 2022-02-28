using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourDictionaries.Domain.Models;
using YourDictionaries.EntityFramework.DataServices.Interfaces;
using YourDictionary.ASP.ViewModels;

namespace YourDictionary.ASP.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersDataService _usersDataService;

        public AccountController(IUsersDataService usersDataService)
        {
            _usersDataService = usersDataService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var returnUrl = HttpContext.Request.Query["ReturnUrl"];
            var loginViewModel = new LoginViewModel { ReturnUrl = returnUrl };
            return View(loginViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = await _usersDataService.UserIsValid(new User
            {
                Name = loginViewModel.Name,
                Email = loginViewModel.Email,
                Password = loginViewModel.Password
            });

            if (user == null)
            {
                ModelState.AddModelError(nameof(loginViewModel.Name), "Invalid login or password");
                return View(loginViewModel);
            }

            await Authenticate(user);
            if (!string.IsNullOrEmpty(loginViewModel.ReturnUrl))
            {
                return Redirect(loginViewModel.ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var user = new User
            {
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password
            };

            if (_usersDataService.UserAlreadyExist(user))
            {
                ModelState.AddModelError(nameof(registerViewModel.Name), "User with this name or email is already registered");
                return View(registerViewModel);
            }
            await Authenticate(user);
            await _usersDataService.Create(user);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public string Profile()
        {
            return "Authorized";
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(User user)
        {

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }
    }
}
