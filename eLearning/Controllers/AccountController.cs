using eLearning.Models;
using eLearning.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using eLearning.Data;

using Microsoft.VisualStudio.Services.WebApi.Location;
using eLearning.Data.Enum;

namespace eLearning.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext context,
            ILocationService locationService)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            AreaAttribute response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user != null)
            {
                //User is foun, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _singInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                //Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginViewModel);
            }
            //User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);

        }

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (user != null)
            {
                TempData["Error"] = "This email addresss is already in use";
                return View(registerViewModel);
            }
            var newUser = new User()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Account/Welcome")]
        public async Task<IActionResult> Welcome(int page = 0)
        {
            if(page == 0)
            {
                return View();
            }
            return View();
        }

    }
}
