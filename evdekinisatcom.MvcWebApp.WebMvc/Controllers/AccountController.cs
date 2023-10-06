using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using evdekinisatcom.MvcWebApp.Entity.Services;

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;   
        }
        [Authorize]
        public async Task< IActionResult> Index()
        {
            var currentUser = await _service.Find(User.Identity.Name);
            return View(currentUser);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            string msg = await _service.CreateUserAsync(model);

            if (msg == "OK")
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", msg);
            }

            return View(model);
        }
        public IActionResult Login(string? returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var msg = await _service.FindByNameAsync(model);

            if (msg == "user not found")
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(model);
            }
            else if (msg == "OK")
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

