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

 
        private bool UnidadeCurricularExists(string id)
        {
          return (_context.UnidadesCurriculares?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
