using BasicAuth.CustomPolicyProvider;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BasicAuth.Controllers
{
    public class HomeController: Controller
    {
        private IAuthorizationService _authorizationService;

        //IAuthorizationService --> Authoriza a block of code
        //                      --> Strategically place authorization in controller/views 
        public HomeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
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

        [Authorize(Policy = "Claim.DoB")]
        public IActionResult SecretPolicy()
        {
            return View("Secret");
        }

        [SecurityLevel(5)]
        public IActionResult SecretLevel()
        {
            return View("Secret");
        }

        [SecurityLevel(10)]
        public IActionResult SecretHigherLevel()
        {
            return View("Secret");
        }

        public IActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Bob"),
                new Claim(ClaimTypes.Email,"Bob@fmail.com"),
                new Claim(ClaimTypes.DateOfBirth,"11/11/2000"),
                new Claim("Grandma.says","Very nice boy"),
                new Claim(DynamicPolicies.SecurityLevel,"7")
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Bob K Who"),
                new Claim("DrivingLicense","A+")
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "GrandMa Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DoStuff()
        {
            //Some block of Code
            //Now Authorize the remaining blocks

            //We can also use Builder
            var builder = new AuthorizationPolicyBuilder("policyName");
            var customPolicy = builder.RequireClaim("Hello").Build();
            

            //await _authorizationService.AuthorizeAsync(User, "Claim.DoB");

            //AuthorizeAsync also accepts AuthorizationPolicy, which is returned by
            // Build Method
            var authResult = 
                await _authorizationService.AuthorizeAsync(User, customPolicy);

            

            if(authResult.Succeeded)
            {

            }

            return View("Index");
        }

        //Inject AuthorizationService only on particular Method
        public async Task<IActionResult> DoSpecificStuff(
            [FromServices]IAuthorizationService authService)
        {
            var authResult = 
                await _authorizationService.AuthorizeAsync(User, "Claim.DoB");

            if(authResult.Succeeded)
            {
                return View("Index");
            }

            return View("Index");
        }

    }
}
