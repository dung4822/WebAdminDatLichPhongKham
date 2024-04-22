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
    public class KhoaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhoaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Khoa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Khoas.ToListAsync());
        }

        // GET: Khoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas
                .FirstOrDefaultAsync(m => m.idKhoa == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }

        // GET: Khoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Khoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idKhoa,TenKhoa,Mota")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoa);
        }

        // GET: Khoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa == null)
            {
                return NotFound();
            }
            return View(khoa);
        }

        // POST: Khoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idKhoa,TenKhoa,Mota")] Khoa khoa)
        {
            if (id != khoa.idKhoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaExists(khoa.idKhoa))
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
            return View(khoa);
        }

        // GET: Khoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas
                .FirstOrDefaultAsync(m => m.idKhoa == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }

        // POST: Khoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa != null)
            {
                _context.Khoas.Remove(khoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoaExists(int id)
        {
            return _context.Khoas.Any(e => e.idKhoa == id);
        }
    }
}
