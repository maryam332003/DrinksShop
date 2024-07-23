using DrinkAndGo.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
                return View(loginViewModel);
           
        }

        public IActionResult Register() => View();


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user is null)
                {
                    user = await _userManager.FindByEmailAsync(model.Email);
                    if (user is null)
                    {
                        user = new IdentityUser()
                        {
                            Email = model.Email,
                            UserName = model.UserName,
                        };
                        var result = await _userManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                            return RedirectToAction("LoggedIn", "Account");
                        foreach (var Error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, Error.Description);

                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "User Is Already Exist ):");

            }
            return View(model);
        }

        public ViewResult LoggedIn() => View();


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpPut(template: "emailExists")]
        public async Task<ActionResult<bool>> CheckEmailExists(string UserName)
        {
            return await _userManager.FindByNameAsync(UserName) is not null;
        }
    }
}
