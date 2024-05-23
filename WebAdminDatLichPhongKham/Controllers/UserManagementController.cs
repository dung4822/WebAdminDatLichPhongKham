using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using WebAdminDatLichPhongKham.Areas.Identity.Data;
using WebAdminDatLichPhongKham.Models;
using WebAdminDatLichPhongKham.Models.ViewModels;

namespace WebAdminDatLichPhongKham.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UserManagementController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.NhanViens = _context.NhanViens.ToList();
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View(new UserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if ( ! ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    idNhanVien = model.idNhanVien
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (model.Roles != null)
                    {
                        await _userManager.AddToRolesAsync(user, model.Roles);
                    }
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            ViewBag.NhanViens = _context.NhanViens.ToList();
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                idNhanVien = user.idNhanVien,
                Roles = (await _userManager.GetRolesAsync(user)).ToList(),
                IsEdit = true
            };

            ViewBag.NhanViens = _context.NhanViens.ToList();
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = model.UserName;
                user.Email = model.Email;
                user.idNhanVien = model.idNhanVien;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    if (model.Password != null)
                    {
                        var passwordResult = await _userManager.RemovePasswordAsync(user);
                        if (passwordResult.Succeeded)
                        {
                            await _userManager.AddPasswordAsync(user, model.Password);
                        }
                    }

                    var userRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (model.Roles != null)
                    {
                        await _userManager.AddToRolesAsync(user, model.Roles);
                    }

                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            ViewBag.NhanViens = _context.NhanViens.ToList();
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return RedirectToAction("Index");
        }
    }
}
