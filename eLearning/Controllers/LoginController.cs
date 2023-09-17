using eLearning.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static eLearning.ViewModel.LoginViewModel;

namespace eLearning.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Try to log in the user
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure : false);
                if (result.Succeeded)
                {
                    //If login is successful, redirect the user to another page
                    return RedirectToPage("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            //If ModelState is invalid or login fails, show the login page again
            return View(model);
        }
    }
}
