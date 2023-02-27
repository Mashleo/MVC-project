using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Diplom_project.Data;
using MVC_Diplom_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Controllers
{
    public class AccountController : Controller
    {
        
            private CarPortalDBContext _appDBcontext;
            public AccountController(CarPortalDBContext context)
            {
                _appDBcontext = context;
            }
            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginModel model)
            {
                if (ModelState.IsValid)
                {
                User user = await _appDBcontext.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);
                    if (user != null)
                    {
                        await Authenticate(model.UserName); 

                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                return View(model);
            }
            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterModel model)
            {
                if (ModelState.IsValid)
                {
                    User user = await _appDBcontext.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
                    if (user == null)
                    {
                        
                        _appDBcontext.Users.Add(new User { UserName = model.UserName, Password = model.Password, ID = new Guid() });
                        await _appDBcontext.SaveChangesAsync();

                        await Authenticate(model.UserName); 

                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                return View(model);
            }

            private async Task Authenticate(string userName)
            {
                
                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
               
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            }

            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Account");
            }

        }
    
}
