namespace NetPontoSec.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Authorization;
    using Microsoft.AspNet.Http.Authentication;
    using Microsoft.AspNet.Mvc;

    using NetPontoSec.Repository;
    using NetPontoSec.ViewModels;

    public class Account : Controller
    {
        private readonly INetPontoUserRepository userRepository;

        public Account(INetPontoUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Login(string returnUrl)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            var user =
                this.userRepository.Find(
                    x => x.Username.Equals(model.Username, StringComparison.CurrentCultureIgnoreCase) && x.Password == model.Password);

            if (user == null)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return this.View(model);
            }

            var claims = user.Claims.Select(x => new Claim(x.Key, x.Value)).ToList();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            var claimsIdentity = new ClaimsIdentity(claims, "bolachinhas");
            var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

            await this.HttpContext.Authentication.SignInAsync(
                "bolachinhas",
                claimsPrinciple,
                new AuthenticationProperties { IsPersistent = model.RememberMe });

            return this.Redirect(returnUrl);
        }

        public IActionResult Forbidden()
        {
            return this.View();
        }

        public async Task<IActionResult> LogOff()
        {
            await this.HttpContext.Authentication.SignOutAsync("bolachinhas");
            return this.RedirectToAction("index", "home");
        }

        [Authorize]
        public IActionResult UserInfo()
        {
            return this.View();
        }
    }
}
