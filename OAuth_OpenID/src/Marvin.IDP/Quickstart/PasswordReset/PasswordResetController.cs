using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Marvin.IDP.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marvin.IDP.Quickstart.PasswordReset
{
    public class PasswordResetController : Controller
    {
        private ILocalUserService _localUserService;

        public PasswordResetController(ILocalUserService localUserService)
        {
            _localUserService = localUserService;
        }

        [HttpGet]
        public IActionResult RequestPassword()
        {
            var vm = new RequestPasswordViewModel();
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestPassword(RequestPasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var securityCode = await _localUserService
                .InitiatePasswordResetRequest(model.Email);
            await _localUserService.SaveChangesAsync();

            //Create Activation Link
            var link = Url.ActionLink("ResetPassword", "PasswordReset", new { securityCode });
            Debug.WriteLine(link);

            return View("PasswordResetRequestSent");


        }

        [HttpGet]
        public IActionResult ResetPassword(string securityCode)
        {
            var vm = new ResetPasswordViewModel()
            {
                SecurityCode = securityCode
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(await _localUserService.SetPassword(model.SecurityCode,model.Password))
            {
                ViewData["Message"] = "Your password was changed";
            }
            else
            {
                ViewData["Message"] = "Your Password can't be changed";
            }

            await _localUserService.SaveChangesAsync();

            return View("ResetPasswordResult");
        }
    }
}
