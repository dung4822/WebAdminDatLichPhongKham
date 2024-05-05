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
    public class CaKhamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaKhamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CaKham
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaKhams.ToListAsync());
        }

        // GET: CaKham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caKham = await _context.CaKhams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caKham == null)
            {
                return NotFound();
            }

            return View(caKham);
        }

        // GET: CaKham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaKham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenCa,TGBatDau,TGKetThuc,HeSoLuong")] CaKham caKham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caKham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caKham);
        }

        // GET: CaKham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caKham = await _context.CaKhams.FindAsync(id);
            if (caKham == null)
            {
                return NotFound();
            }
            return View(caKham);
        }

        // POST: CaKham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenCa,TGBatDau,TGKetThuc,HeSoLuong")] CaKham caKham)
        {
            if (id != caKham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caKham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaKhamExists(caKham.Id))
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
            return View(caKham);
        }

        // GET: CaKham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caKham = await _context.CaKhams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caKham == null)
            {
                return NotFound();
            }

            return View(caKham);
        }

        // POST: CaKham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caKham = await _context.CaKhams.FindAsync(id);
            if (caKham != null)
            {
                _context.CaKhams.Remove(caKham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaKhamExists(int id)
        {
            return _context.CaKhams.Any(e => e.Id == id);
        }
    }
}
