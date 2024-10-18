using FluentWay.Extentions;
using FluentWay.Models;
using FluentWay.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FluentWay.Controllers
{

    //[Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private readonly IEmailSender _emailSender;
        //private readonly ILogger _logger;

        public AccountController(
            UserManager<User> userManager,
            //ILogger logger, 
            SignInManager<User> signInManager
            //IEmailSender emailSender
            )
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            //_emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");

            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Name, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //_logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }

                AddErrors(result);
            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
