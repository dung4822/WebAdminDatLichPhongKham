using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminDatLichPhongKham.Areas.Identity.Data;
using WebAdminDatLichPhongKham.Models;

namespace WebAdminDatLichPhongKham.Views
{
    public class BenhNhanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BenhNhanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BenhNhan
        public async Task<IActionResult> Index()
        {
            return View(await _context.BenhNhans.ToListAsync());
        }

        // GET: BenhNhan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benhNhan = await _context.BenhNhans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (benhNhan == null)
            {
                return NotFound();
            }

            return View(benhNhan);
        }

   

        // GET: BenhNhan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benhNhan = await _context.BenhNhans.FindAsync(id);
            if (benhNhan == null)
            {
                return NotFound();
            }

            return View(benhNhan);
        }

        // POST: BenhNhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CMND,Gender,Email,PhoneNumber")] BenhNhan benhNhan)
        {
            if (id != benhNhan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(benhNhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BenhNhanExists(benhNhan.Id))
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
            return View(benhNhan);
        }


        private bool BenhNhanExists(int id)
        {
            return _context.BenhNhans.Any(e => e.Id == id);
        }
    }
}
