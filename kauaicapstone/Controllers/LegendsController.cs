using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kauaicapstone.Data;
using kauaicapstone.Models;
using kauaicapstone.Models.ViewModels;

namespace kauaicapstone.Controllers
{
    public class LegendsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LegendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Legends
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Legend.Include(l => l.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Legends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legend = await _context.Legend
                .Include(l => l.User)
                .Include(l => l.LegendViewLocations)
                .ThenInclude(l => l.ViewLocation)
                .FirstOrDefaultAsync(m => m.LegendId == id);
            if (legend == null)
            {
                return NotFound();
            }

            return View(legend);
        }

        // GET: Legends/Create
        public IActionResult Create()
        {
            LocationsLegendViewModel location = new LocationsLegendViewModel() {
                AvailableLocations = _context.ViewLocation.Include(l => l.User).ToList()
        };

            
           
            return View(location);
        }
        //GET: Legends/CreateForm
        public IActionResult CreateForm()
        {
            return View();
        }
        // POST: Legends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LegendId,Title,Description,Source,IsApproved,UserId,ImageURL")] Legend legend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", legend.UserId);
            return View(legend);
        }

        // GET: Legends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legend = await _context.Legend.FindAsync(id);
            if (legend == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", legend.UserId);
            return View(legend);
        }

        // POST: Legends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LegendId,Title,Description,Source,IsApproved,UserId,ImageURL")] Legend legend)
        {
            if (id != legend.LegendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegendExists(legend.LegendId))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", legend.UserId);
            return View(legend);
        }

        // GET: Legends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legend = await _context.Legend
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LegendId == id);
            if (legend == null)
            {
                return NotFound();
            }

            return View(legend);
        }

        // POST: Legends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var legend = await _context.Legend.FindAsync(id);
            _context.Legend.Remove(legend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegendExists(int id)
        {
            return _context.Legend.Any(e => e.LegendId == id);
        }
    }
}
