using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Project.Models.Identity;
using Project.Models.ViewModels;

namespace CustomIdentityApp.Controllers
{
    public class AdminController : Controller
    {
        UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            var usersWithRoles = users.Select( user =>
            {
                var roles = _userManager.GetRolesAsync(user).Result;

                return new UserWithRoles(user, roles);
            });

            return View(usersWithRoles);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email, Language = model.Language };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> AppointAdmin(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult addNewRole = await _userManager.AddToRoleAsync(user, "admin");
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<ActionResult> RemoveAdmin(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult deleteRole = await _userManager.RemoveFromRoleAsync(user, "admin");
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<ActionResult> BlockUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult deleteAdRole = await _userManager.RemoveFromRoleAsync(user, "admin");
                IdentityResult deleteUsRole = await _userManager.RemoveFromRoleAsync(user, "user");
                IdentityResult addNewRole = await _userManager.AddToRoleAsync(user, "block");
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public async Task<ActionResult> UnblockUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult deleteAdRole = await _userManager.RemoveFromRoleAsync(user, "block");
                IdentityResult addNewRole = await _userManager.AddToRoleAsync(user, "user");
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}