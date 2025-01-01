using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RZRV.APP.AppConfig;
using RZRV.APP.Models;
using RZRV.APP.Services;
using RZRV.APP.ViewModel;

namespace RZRV.APP.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleService _roleService;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleService roleService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Phone, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Phone);
                    var roles = await _userManager.GetRolesAsync(user);
                    var userRole = roles.FirstOrDefault();

                    switch (userRole)
                    {
                        case "Admin":
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        case "Store":
                            return RedirectToAction("Index", "Dashboard", new { area = "Store" });
                        case "Provider":
                            return RedirectToAction("Index", "Dashboard", new { area = "Provider" });
                        default:
                            return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new List<string>
            {
                SystemRoles.Admin,
                SystemRoles.Store,
                SystemRoles.Provider
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Phone,
                    PhoneNumber = model.Phone
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    switch (model.Role)
                    {
                        case SystemRoles.Admin:
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        case SystemRoles.Store:
                            return RedirectToAction("Index", "Dashboard", new { area = "Store" });
                        case SystemRoles.Provider:
                            return RedirectToAction("Index", "Dashboard", new { area = "Provider" });
                        default:
                            return RedirectToAction("Index", "Home");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            ViewBag.Roles = new List<string>
            {
                SystemRoles.Admin,
                SystemRoles.Store,
                SystemRoles.Provider
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }

}
