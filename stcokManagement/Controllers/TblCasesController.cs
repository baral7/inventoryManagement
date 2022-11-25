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
    public class TblCasesController : Controller
    {
        private readonly AirlinesStockContext _context;

        public TblCasesController(AirlinesStockContext context)
        {
            _context = context;
        }

        // GET: TblCases
        public async Task<IActionResult> Index()
        {
            var airlinesStockContext = _context.TblCases.Include(t => t.Self);
            return View(await airlinesStockContext.ToListAsync());
        }

        // GET: TblCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblCases == null)
            {
                return NotFound();
            }

            var tblCase = await _context.TblCases
                .Include(t => t.Self)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCase == null)
            {
                return NotFound();
            }

            return View(tblCase);
        }

        // GET: TblCases/Create
        public IActionResult Create()
        {
            ViewData["SelfId"] = new SelectList(_context.TblSelves, "Id", "SelfNo");
            return View();
        }

        // POST: TblCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CaseNo,SelfId")] TblCase tblCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SelfId"] = new SelectList(_context.TblSelves, "Id", "Id", tblCase.SelfId);
            return View(tblCase);
        }

        // GET: TblCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblCases == null)
            {
                return NotFound();
            }

            var tblCase = await _context.TblCases.FindAsync(id);
            if (tblCase == null)
            {
                return NotFound();
            }
            ViewData["SelfId"] = new SelectList(_context.TblSelves, "Id", "Id", tblCase.SelfId);
            return View(tblCase);
        }

        // POST: TblCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CaseNo,SelfId")] TblCase tblCase)
        {
            if (id != tblCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCaseExists(tblCase.Id))
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
            ViewData["SelfId"] = new SelectList(_context.TblSelves, "Id", "Id", tblCase.SelfId);
            return View(tblCase);
        }

        // GET: TblCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblCases == null)
            {
                return NotFound();
            }

            var tblCase = await _context.TblCases
                .Include(t => t.Self)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCase == null)
            {
                return NotFound();
            }

            return View(tblCase);
        }

        // POST: TblCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblCases == null)
            {
                return Problem("Entity set 'AirlinesStockContext.TblCases'  is null.");
            }
            var tblCase = await _context.TblCases.FindAsync(id);
            if (tblCase != null)
            {
                _context.TblCases.Remove(tblCase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCaseExists(int id)
        {
          return _context.TblCases.Any(e => e.Id == id);
        }
    }
}
