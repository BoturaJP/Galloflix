using GalloFlix.DataTransferObjects;
using GalloFlix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace GalloFlix.Controllers;

[Authorize(Roles = "Administrador")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager; 

        public AccountController(ILogger<AccountController> logger,
         SignInManager<AppUser> signInManager,
         UserManager<AppUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            LoginDto login = new();
            login.ReturnUrl = returnUrl ?? Url.Content("~/");
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                string userName = login.Email;
                if (IsValidEmail(login.Email))
                {
                    var user = await _userManager.FindByEmailAsync(login.Email);
                    if (user != null)
                     userName = user.UserName;
                }

                var result = await _signInManager.PasswordSignInAsync(
                    login.Email, login.Password, login.RememberMe, lockoutOnFailure: true
                );
                if (result.Succeeded)
                {
                    _logger.LogInformation($"Usuário { login.Email } acessou o sistema");
                    return LocalRedirect(login.ReturnUrl);
                }
                if(result.IsLockedOut)
                {
                    _logger.LogWarning($"Usuário { login.Email } está bloqueado");
                    return RedirectToAction("Lockout");
                }
                ModelState.AddModelError("login","Usuário e/ou senha Inválidos vagabundo!!!");
            }
            return View(login);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }

        }



    }
