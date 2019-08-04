using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kauaicapstone.Data;
using kauaicapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace kauaicapstone.Controllers
{
    [Authorize]
    public class ViewLocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;




        public ViewLocationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)

        {
            _context = context;
            _userManager = userManager;

        }


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: ViewLocations
        public async Task<IActionResult> Index()
        {

        /*    var applicationDbContext = _context.ViewLocation.Include(v => v.Name).take(v => v.ViewPointAddress)*/
            
            return View(await _context.ViewLocation.ToListAsync());
        }

        public async Task<IActionResult> SearchIndex(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;


            var applicationDbContext = _context.ViewLocation.Where(v=>v.Name.Contains(searchString));
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ViewLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
                if (id == null)
                {
                    return NotFound();
                }

                var viewLocation = await _context.ViewLocation
                    .Include(v => v.User)
                    .Include(v => v.Comments)
                    .Include(v => v.LegendViewLocations)
                    .ThenInclude(v => v.Legend)
                    .FirstOrDefaultAsync(m => m.ViewLocationId == id);
                if (viewLocation == null)
                {
                    return NotFound();
                }

                return View(viewLocation);
            }




        // GET: ViewLocations/Create
        public IActionResult Create()
        {
            if (_userManager.GetUserAsync(User).Result.IsAdmin)
            {
                ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
                return View();
            } else
            {
                return NotFound();
            }
        }

        // POST: ViewLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViewLocationId,Name,ViewPointAddress,UserId")] ViewLocation viewLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", viewLocation.UserId);
            return View(viewLocation);
        }

        // GET: ViewLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewLocation = await _context.ViewLocation.FindAsync(id);
            if (viewLocation == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", viewLocation.UserId);
            return View(viewLocation);
        }

        // POST: ViewLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ViewLocationId,Name,ViewPointAddress,UserId")] ViewLocation viewLocation)
        {
            if (id != viewLocation.ViewLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViewLocationExists(viewLocation.ViewLocationId))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", viewLocation.UserId);
            return View(viewLocation);
        }

        // GET: ViewLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewLocation = await _context.ViewLocation
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.ViewLocationId == id);
            if (viewLocation == null)
            {
                return NotFound();
            }

            return View(viewLocation);
        }

        // POST: ViewLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viewLocation = await _context.ViewLocation.FindAsync(id);
            _context.ViewLocation.Remove(viewLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViewLocationExists(int id)
        {
            return _context.ViewLocation.Any(e => e.ViewLocationId == id);
        }
    }
}
