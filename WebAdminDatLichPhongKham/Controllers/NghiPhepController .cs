using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebAdminDatLichPhongKham.Areas.Identity.Data;
using WebAdminDatLichPhongKham.Models;
using WebAdminDatLichPhongKham.Models.ViewModels;

namespace WebAdminDatLichPhongKham.Controllers
{
    public class DonNghiPhepController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DonNghiPhepController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Create()
        {
            var model = new NghiPhepViewModel
            {
                CaKhamList = _context.CaKhams.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(NghiPhepViewModel model)
        {
            var user = await _userManager.GetUserAsync(User); // Lấy thông tin của người dùng hiện tại
            if (user == null)
            {
                // Xử lý khi không tìm thấy người dùng
                return RedirectToAction("Error");
            }
            if (!ModelState.IsValid)
            {

                var donNghiPhep = new DonNghiPhep
                {
                    NgayDK = DateTime.Now,
                    NgayNghi = model.NgayNghi,
                    LyDo = model.LyDo,
                    NhanvienId = user.idNhanVien
                };
                _context.DonNghiPheps.Add(donNghiPhep);
                _context.SaveChanges();

                var caNghiPhep = new CaNghiPhep
                {
                    DonNghiPhepId = donNghiPhep.Id,
                    CaKhamId = model.SelectedCaKhamId
                };
                _context.CaNghiPheps.Add(caNghiPhep);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            model.CaKhamList = _context.CaKhams.ToList();
            return View(model);
        }

        public IActionResult Index()
        {
            var donNghiPheps = _context.DonNghiPheps
           .Include(d => d.NhanVien)
           .Include(d => d.CaNghiPheps)
                .ThenInclude(cnp => cnp.CaKham)
           .ToList();

            var viewModelList = donNghiPheps.Select(d => new DonNghiPhepViewModel
            {
                NgayNghi = d.NgayNghi,
                LyDo = d.LyDo,
                TenNhanVien = d.NhanVien?.HoTen,
                TenCa = d.CaNghiPheps.FirstOrDefault()?.CaKham?.TenCa
            }).ToList();

            return View(viewModelList);
        }
    }
}

