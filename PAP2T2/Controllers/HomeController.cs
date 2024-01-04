using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAP2T2.Data;
using PAP2T2.Models;

namespace PAP2T2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
              return _context.UnidadesCurriculares != null ? 
                          View(await _context.UnidadesCurriculares.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UnidadesCurriculares'  is null.");
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UnidadesCurriculares == null)
            {
                return NotFound();
            }

            var unidadeCurricular = await _context.UnidadesCurriculares
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (unidadeCurricular == null)
            {
                return NotFound();
            }

            return View(unidadeCurricular);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome,ECTS")] UnidadeCurricular unidadeCurricular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadeCurricular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadeCurricular);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UnidadesCurriculares == null)
            {
                return NotFound();
            }

            var unidadeCurricular = await _context.UnidadesCurriculares.FindAsync(id);
            if (unidadeCurricular == null)
            {
                return NotFound();
            }
            return View(unidadeCurricular);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Codigo,Nome,ECTS")] UnidadeCurricular unidadeCurricular)
        {
            if (id != unidadeCurricular.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadeCurricular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadeCurricularExists(unidadeCurricular.Codigo))
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
            return View(unidadeCurricular);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UnidadesCurriculares == null)
            {
                return NotFound();
            }

            var unidadeCurricular = await _context.UnidadesCurriculares
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (unidadeCurricular == null)
            {
                return NotFound();
            }

            return View(unidadeCurricular);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UnidadesCurriculares == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UnidadesCurriculares'  is null.");
            }
            var unidadeCurricular = await _context.UnidadesCurriculares.FindAsync(id);
            if (unidadeCurricular != null)
            {
                _context.UnidadesCurriculares.Remove(unidadeCurricular);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadeCurricularExists(string id)
        {
          return (_context.UnidadesCurriculares?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
