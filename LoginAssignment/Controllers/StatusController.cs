using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LoginAssignment.Models;

namespace LoginAssignment.Controllers
{
    public class StatusController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public StatusController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                ApplicationUser currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)       
                    return View(new CurrentUserModel { FirstName = currentUser.FirstName, LastName = currentUser.LastName });
                else
                    return View();
            }            
            else
                return new RedirectToActionResult("Login", "Account", new { returnUrl = "~/Status/Index", isRedirect = true });
        }
    }
}