using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TuffyHealthNew.Models;

namespace TuffyHealthNew.Controllers
{
    public class AppUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AppUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            if (userid == null)
            {
                return RedirectToAction("Login");    //redirect to login if not logged in
            }
            else
            {
                ApplicationUser user = _userManager.FindByIdAsync(userid).Result;
                
                return View(user);
            }
        }
    }
}
