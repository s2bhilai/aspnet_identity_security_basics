using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityExample.Controllers
{
    public class HomeController:Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private IEmailService _emailService;

        public HomeController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName,string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if(user != null)
            {
                //Sign In
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if(signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName,string Password)
        {
            var user = new IdentityUser
            {
                UserName = userName,
                Email = ""
            };

            var result = await _userManager.CreateAsync(user,Password);

            if(result.Succeeded)
            {
                //Sign User here
                //var signInResult = await _signInManager.PasswordSignInAsync(user, Password, false, false);

                //if (signInResult.Succeeded)
                //{
                //    return RedirectToAction("Index");
                //}

                //Generation of Email Token

                var code = _userManager.GenerateEmailConfirmationTokenAsync(user);
                var link = Url.Action(nameof(VerifyEmail), "Home", 
                    new { userId = user.Id, code = code.Result },Request.Scheme,Request.Host.ToString());


                await _emailService.SendAsync("test@test.com", "email verify",$"<a href=\"{link}\">Verify Email</a>",true);

                return RedirectToAction("EmailVerification");

            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> VerifyEmail(string userId,string code)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if(result.Succeeded)
            {
                return View();
            }

            return BadRequest();
        }

        public IActionResult EmailVerification() => View();

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
