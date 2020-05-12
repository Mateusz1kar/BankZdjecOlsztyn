using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankZdjecOlsztyn.ViewsModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankZdjecOlsztyn.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (!ModelState.IsValid)
                return View(loginvm);

            var user = await _userManager.FindByNameAsync(loginvm.UserName);

            if (user !=null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginvm.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Niepoprawna nazwa użytkownika lub hasło");
            return View(loginvm);
        }

        // GET: /<controller>/
        public IActionResult Register()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginVM loginvm)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = loginvm.UserName };
                var result = await _userManager.CreateAsync(user, loginvm.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

           
            return View(loginvm);
        }

        
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}