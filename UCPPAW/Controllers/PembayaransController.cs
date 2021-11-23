using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCPPAW.Models;

namespace UCPPAW.Controllers
{
    public class PembayaransController : Controller
    {
        private readonly JualBajuContext _context;

        public PembayaransController(JualBajuContext context)
        {
            _context = context;
        }

        // GET: Pembayarans
        public async Task<IActionResult> Index()
        {
            var jualBajuContext = _context.Pembayarans.Include(p => p.TotalBayarNavigation);
            return View(await jualBajuContext.ToListAsync());
        }

        // GET: Pembayarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans
                .Include(p => p.TotalBayarNavigation)
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // GET: Pembayarans/Create
        public IActionResult Create()
        {
            ViewData["TotalBayar"] = new SelectList(_context.Transaksis, "IdTransaksi", "IdTransaksi");
            return View();
        }

        // POST: Pembayarans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembayaran,TanggalBayar,TotalBayar,IdTransaksi")] Pembayaran pembayaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembayaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TotalBayar"] = new SelectList(_context.Transaksis, "IdTransaksi", "IdTransaksi", pembayaran.TotalBayar);
            return View(pembayaran);
        }

        // GET: Pembayarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans.FindAsync(id);
            if (pembayaran == null)
            {
                return NotFound();
            }
            ViewData["TotalBayar"] = new SelectList(_context.Transaksis, "IdTransaksi", "IdTransaksi", pembayaran.TotalBayar);
            return View(pembayaran);
        }

        // POST: Pembayarans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPembayaran,TanggalBayar,TotalBayar,IdTransaksi")] Pembayaran pembayaran)
        {
            if (id != pembayaran.IdPembayaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembayaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembayaranExists(pembayaran.IdPembayaran))
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
            ViewData["TotalBayar"] = new SelectList(_context.Transaksis, "IdTransaksi", "IdTransaksi", pembayaran.TotalBayar);
            return View(pembayaran);
        }

        // GET: Pembayarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans
                .Include(p => p.TotalBayarNavigation)
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // POST: Pembayarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembayaran = await _context.Pembayarans.FindAsync(id);
            _context.Pembayarans.Remove(pembayaran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembayaranExists(int id)
        {
            return _context.Pembayarans.Any(e => e.IdPembayaran == id);
        }
    }
}
