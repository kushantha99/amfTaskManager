using amfTaskManager.Models;
using amfTaskManager.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace amfTaskManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager; // Declare userManager

        // Constructor: Make sure both services are injected
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager; // Initialize userManager
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    // Redirect to a different page after successful login
                    return RedirectToAction("Index", "UserTasks"); // Change as necessary
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // If we got this far, something failed; redisplay form
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model) // Make this method async
        {
            Console.WriteLine("Hello, World!");

            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    Address = model.Address
                };

                // Create the user
                var result = await userManager.CreateAsync(user, model.Password);

                Console.WriteLine(result);

                if (result.Succeeded)
                {
                    // Optionally sign in the user after registration
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "UserTasks"); // Redirect to home after successful registration
                }

                // If there are errors, add them to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed; redisplay form
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
