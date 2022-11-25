using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stcokManagement.Models;

namespace stcokManagement.Controllers
{
    public class TblSelvesController : Controller
    {
        private readonly AirlinesStockContext _context;

        public TblSelvesController(AirlinesStockContext context)
        {
            _context = context;
        }

        // GET: TblSelves
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblSelves.ToListAsync());
        }

        // GET: TblSelves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblSelves == null)
            {
                return NotFound();
            }

            var tblSelf = await _context.TblSelves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSelf == null)
            {
                return NotFound();
            }

            return View(tblSelf);
        }

        // GET: TblSelves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblSelves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SelfNo,AirlineName,BlockNo")] TblSelf tblSelf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSelf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSelf);
        }

        // GET: TblSelves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblSelves == null)
            {
                return NotFound();
            }

            var tblSelf = await _context.TblSelves.FindAsync(id);
            if (tblSelf == null)
            {
                return NotFound();
            }
            return View(tblSelf);
        }

        // POST: TblSelves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SelfNo,AirlineName,BlockNo")] TblSelf tblSelf)
        {
            if (id != tblSelf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSelf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSelfExists(tblSelf.Id))
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
            return View(tblSelf);
        }

        // GET: TblSelves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblSelves == null)
            {
                return NotFound();
            }

            var tblSelf = await _context.TblSelves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSelf == null)
            {
                return NotFound();
            }

            return View(tblSelf);
        }

        // POST: TblSelves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblSelves == null)
            {
                return Problem("Entity set 'AirlinesStockContext.TblSelves'  is null.");
            }
            var tblSelf = await _context.TblSelves.FindAsync(id);
            if (tblSelf != null)
            {
                _context.TblSelves.Remove(tblSelf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSelfExists(int id)
        {
          return _context.TblSelves.Any(e => e.Id == id);
        }
    }
}
