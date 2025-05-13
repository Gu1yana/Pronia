using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVClassromTask.Models.LoginAndRegister;
using MVClassromTask.ViewModels;

namespace MVClassromTask.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new AppUser
            {
                Email = vm.Email,
                UserName = vm.UserName,
            };
            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(Login));
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
