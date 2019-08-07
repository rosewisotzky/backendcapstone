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
using kauaicapstone.Models.ViewModels;

namespace kauaicapstone.Controllers
{
    [Authorize]
    public class ViewLocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;




        public ViewLocationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)

        {
            _context = context;
            _userManager = userManager;

        }




        public IActionResult LegendsIndex()
        {
            return this.RedirectToAction("Create", "Legends");
        }
        // GET: ViewLocations
        public async Task<IActionResult> Index()
        {

            /*    var applicationDbContext = _context.ViewLocation.Include(v => v.Name).take(v => v.ViewPointAddress)*/

            return View(await _context.ViewLocation.ToListAsync());
        }

        public async Task<IActionResult> SearchIndex(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;


            var applicationDbContext = _context.ViewLocation.Where(v => v.Name.Contains(searchString));
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
                .ThenInclude(v => v.User)
                .Include(v => v.LegendViewLocations)
                .ThenInclude(v => v.Legend)
                .FirstOrDefaultAsync(m => m.ViewLocationId == id);
            if (viewLocation == null)
            {
                return NotFound();
            }
            
            LocationCommentViewModel viewModel = new LocationCommentViewModel()
            {
                Location = viewLocation
            };
            return View(viewModel);
        }




        // GET: ViewLocations/Create
        public IActionResult Create()
        {
            {
                ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
                return View();
            }
        }

        // POST: ViewLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LocationsLegendViewModel viewModel, List<int> ViewLocationInput)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("ViewLocation.User");
            if (ModelState.IsValid)
            {
                var location = viewModel.ViewLocation;
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                viewModel.ViewLocation.User = currentUser;
                viewModel.ViewLocation.UserId = currentUser.Id;
                _context.Add(location);
                foreach (var id in ViewLocationInput) {
                    LegendViewLocation newView = new LegendViewLocation()
                    {
                        ViewLocationId = location.ViewLocationId,

                    };
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LegendsIndex));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", viewModel.ViewLocation.UserId);
            return View(viewModel);
        }

        // GET: ViewLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (_userManager.GetUserAsync(User).Result.IsAdmin)
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
        } else { 
        return NotFound();
    }
            }


        // POST: ViewLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ViewLocationId,Name,ViewPointAddress,UserId")] ViewLocation viewLocation)
        {
            if (_userManager.GetUserAsync(User).Result.IsAdmin)
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
        } else {
        return NotFound();
    }
}


        // GET: ViewLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_userManager.GetUserAsync(User).Result.IsAdmin)
            {
                var viewLocation = await _context.ViewLocation
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.ViewLocationId == id);
                if (viewLocation == null)
                {
                    return NotFound();
                }

                return View(viewLocation);
            } else
            {
                return NotFound();
            }
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
