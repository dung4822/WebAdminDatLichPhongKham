using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminDatLichPhongKham.Areas.Identity.Data;
using WebAdminDatLichPhongKham.Models;

namespace WebAdminDatLichPhongKham.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhanVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NhanViens.Include(n => n.chucVu).Include(n => n.khoa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.chucVu)
                .Include(n => n.khoa)
                .FirstOrDefaultAsync(m => m.idNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            ViewData["idChucVu"] = new SelectList(_context.ChucVus, "idChucVu", "Tenchucvu");
            ViewData["idKhoa"] = new SelectList(_context.Khoas, "idKhoa", "TenKhoa");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idNhanVien,HoTen,GioiTinh,SDT,Ngaysinh,Hinhanh,idKhoa,idChucVu")] NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idChucVu"] = new SelectList(_context.ChucVus, "idChucVu", "Tenchucvu", nhanVien.idChucVu);
            ViewData["idKhoa"] = new SelectList(_context.Khoas, "idKhoa", "TenKhoa", nhanVien.idKhoa);
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["idChucVu"] = new SelectList(_context.ChucVus, "idChucVu", "Tenchucvu", nhanVien.idChucVu);
            ViewData["idKhoa"] = new SelectList(_context.Khoas, "idKhoa", "TenKhoa", nhanVien.idKhoa);
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idNhanVien,HoTen,GioiTinh,SDT,Ngaysinh,Hinhanh,idKhoa,idChucVu")] NhanVien nhanVien)
        {
            if (id != nhanVien.idNhanVien)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.idNhanVien))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["idChucVu"] = new SelectList(_context.ChucVus, "idChucVu", "Tenchucvu", nhanVien.idChucVu);
            ViewData["idKhoa"] = new SelectList(_context.Khoas, "idKhoa", "TenKhoa", nhanVien.idKhoa);
            return View(nhanVien);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.chucVu)
                .Include(n => n.khoa)
                .FirstOrDefaultAsync(m => m.idNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanViens.Remove(nhanVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanViens.Any(e => e.idNhanVien == id);
        }
    }
}
