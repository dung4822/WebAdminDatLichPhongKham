using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAdminDatLichPhongKham.Areas.Identity.Data;
using WebAdminDatLichPhongKham.Models;
using WebAdminDatLichPhongKham.Models.ViewModels;

namespace WebAdminDatLichPhongKham.Controllers
{
    public class HoSoBenhAnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoSoBenhAnController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var hoSoBenhAns = _context.HoSoBenhAns
                .Include(h => h.ChiTietHoSoBenhAns)
                .ThenInclude(ct => ct.Thuoc)
                .Include(h => h.PhieuDatLich)
                .ThenInclude(p => p.BenhNhan)
                .ToList();

            return View(hoSoBenhAns);
        }
        public IActionResult TaoHoSo(int phieuDatLichId)
        {
            var phieuDatLich = _context.PhieuDatLichs.Include(p => p.BenhNhan).FirstOrDefault(p => p.Id == phieuDatLichId);
            if (phieuDatLich == null)
            {
                return NotFound();
            }

            var viewModel = new TaoHoSoBenhAnViewModel
            {
                PhieuDatLichId = phieuDatLich.Id,
                BenhNhanId = phieuDatLich.BenhNhanId,
                BenhNhanName = phieuDatLich.BenhNhan.Name
            };

            ViewBag.ThuocList = new SelectList(_context.Thuocs.ToList(), "Id", "TenThuoc");

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult TaoHoSo(TaoHoSoBenhAnViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Tính tổng tiền thuốc
                double tongTienThuoc = 0;
                foreach (var item in viewModel.ChiTietThuoc)
                {
                    var thuoc = _context.Thuocs.Find(item.ThuocId);
                    tongTienThuoc += thuoc.GiaTien * item.SoLuong;
                }

                // Tạo hồ sơ bệnh án mới
                var hoSoBenhAn = new HoSoBenhAn
                {
                    PhieuDatLichId = viewModel.PhieuDatLichId,
                    ChanDoan = viewModel.ChanDoan,
                    GhiChu = viewModel.GhiChu,
                    TongTien = tongTienThuoc
                };

                _context.HoSoBenhAns.Add(hoSoBenhAn);
                _context.SaveChanges();

                // Thêm chi tiết hồ sơ bệnh án
                foreach (var item in viewModel.ChiTietThuoc)
                {
                    var chiTietHoSoBenhAn = new ChiTietHoSoBenhAn
                    {
                        HoSoBenhAnId = hoSoBenhAn.Id,
                        ThuocId = item.ThuocId,
                        SoLuong = item.SoLuong
                    };

                    _context.ChiTietHoSoBenhAns.Add(chiTietHoSoBenhAn);
                }

                _context.SaveChanges();

                return RedirectToAction("ChiTietHoSo", new { id = hoSoBenhAn.Id });
            }

            ViewBag.ThuocList = new SelectList(_context.Thuocs.ToList(), "Id", "TenThuoc");
            return View(viewModel);
        }

        public IActionResult ChiTietHoSo(int id)
        {
            var hoSoBenhAn = _context.HoSoBenhAns
                .Include(h => h.ChiTietHoSoBenhAns)
                .ThenInclude(ct => ct.Thuoc)
                .Include(h => h.PhieuDatLich)
                .ThenInclude(p => p.BenhNhan)
                .FirstOrDefault(h => h.Id == id);

            if (hoSoBenhAn == null)
            {
                return NotFound();
            }

            return View(hoSoBenhAn);
        }
       
    }
}
