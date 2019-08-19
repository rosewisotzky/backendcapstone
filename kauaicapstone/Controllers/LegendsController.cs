// Author: Rose Wisotzky
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace kauaicapstone.Controllers
{
    [Authorize]
    public class LegendsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LegendsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        //private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Legends
        // This method looks into the legends table and grabs the legends, including the User information, where the boolean value of IsApproved is set to true and saves that in a variable named applicationDbContext. It then returns that variable as a list passed into the Index view.
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Legend.Include(l => l.User).Where(l => l.IsApproved == true);
            return View(await applicationDbContext.ToListAsync());
        }

        //GET: PendingLegends
        //This method sorts through the legends in our database and selects the legends where the boolean value of IsApproved is set to false. We have the Distinct method on there so there are not any repeats. We then return the applicationDbContext that has been passed into our PendingIndex view.
        public async Task<IActionResult> PendingIndex()
        {
            var applicationDbContext = _context.Legend.Include(l => l.User).Where(l => l.IsApproved == false).Distinct();


            return View(await applicationDbContext.ToListAsync());

        }
        //GET: Approved Legends
        //This method changes the boolean value of IsApproved. We are passing in the legend id from our URL route as an argument in this method.
        public async Task<IActionResult> Approve([FromRoute] int id)
        {
            //We are using _context to go into our database and find the legend that has the same id as the one we are passing in.
            var legend = _context.Legend.Find(id);
            //If we can't find that legend, we will display a Not Found message.
            if (id != legend.LegendId)
            {
                return NotFound();
            }
            //ModelState is a property on the Controller class. The ModelState is a collection of key value pairs that get sent to the serer when a request is made. It will be valid if all of those pairs are true. If not, it will be invalid and the request will stop.
            if (ModelState.IsValid)
            {
                try
                {
                    //Once the ModelState is valid, the IsApproved is changed to true and then we call Update in our database to change that value and SaveChangesAsync() to save them.
                    legend.IsApproved = true;
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


        // GET: Legends/Details/5
        //This method gets the legends and their details! We pass in the id as an argument.
        public async Task<IActionResult> Details(int? id)
        {
            // Here we just check that the legend we are trying to target has an id--another way to check if it exists. If not, we return NotFound.
            if (id == null)
            {
                return NotFound();
            }
            //If the id is not null, we use _context to go through our database and get the legend with that id, and all of the corresponding information we want. ThenInclude allows us to go into our join table to reference the ViewLocation, which we will want when looking at our legend details.
            var legend = await _context.Legend
                .Include(l => l.User)
                .Include(l => l.LegendViewLocations)
                .ThenInclude(l => l.ViewLocation)
                .FirstOrDefaultAsync(m => m.LegendId == id)
                ;
            if (legend == null)
            {
                return NotFound();
            }

            return View(legend);
        }

        // GET: Legends/Create. 
        public IActionResult Create()
        {
            LocationsLegendViewModel location = new LocationsLegendViewModel() {
                AvailableLocations = _context.ViewLocation.Include(l => l.User).ToList()
            };



            return View(location);
        }
        //GET: Legends/CreateForm
        public IActionResult CreateForm(List<int> ViewLocationInput)
        {
            CreateLegendViewModel viewModel = new CreateLegendViewModel()
            {
                LocationIds = ViewLocationInput
            };
            return View(viewModel);
        }
        // POST: Legends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EditLegendLocationViewModel viewModel, List<int> ViewLocationInput)
        {
            ModelState.Remove("Legend.UserId");
            ModelState.Remove("ViewLocationInput");
            ModelState.Remove("Legend.LegendViewLocations");
            if (ModelState.IsValid)
            {
                var legend = viewModel.Legend;
                //var legendViewLocations = _context.LegendViewLocation.Include(l => l.Legend.Title).Include(l=> l.ViewLocation.Name).ToList();
                //var legendViewName = legendViewLocations.Select(l => l.ViewLocation.Name);
                //var legendTitle = legendViewLocations.Select(l => l.Legend.Title);
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                legend.UserId = currentUser.Id;
                viewModel.LocationIds = ViewLocationInput;
                _context.Add(legend);

                foreach (var id in ViewLocationInput)
                {


                    LegendViewLocation newView = new LegendViewLocation()
                    {
                        LegendId = legend.LegendId,
                        ViewLocationId = id,
                    };
                    _context.Add(newView);
                }


                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: Legends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (_userManager.GetUserAsync(User).Result.IsAdmin) 
    {
                if (id == null)
                {
                    return NotFound();
                }
                var viewLocationList = _context.LegendViewLocation.Where(lv => lv.LegendId == id).Select(lv => lv.ViewLocationId).ToList();

                EditLegendLocationViewModel location = new EditLegendLocationViewModel()
                {
                    AvailableLocations = _context.ViewLocation.Include(l => l.User).ToList(),
                    Legend = await _context.Legend.FindAsync(id),
                    LocationIds = viewLocationList

                };



                if (location == null)
                {
                    return NotFound();
                }
                ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", location.Legend.UserId);
                return View(location);
            } else
            {
                return NotFound();
            }
        }

        // POST: Legends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditLegendLocationViewModel viewModel, List<int> ViewLocationInput)
        {
            if (_userManager.GetUserAsync(User).Result.IsAdmin)
            {
                if (id != viewModel.Legend.LegendId)
                {
                    return NotFound();
                }
                ModelState.Remove("User");
                ModelState.Remove("Legend.LegendViewLocations");
                if (ModelState.IsValid)
                {
                    List<LegendViewLocation> viewLocations = await _context.LegendViewLocation.Where(lv => lv.LegendId == id).ToListAsync();
                    viewLocations.ForEach(lv => _context.LegendViewLocation.Remove(lv));
                    try
                    {
                        var legend = viewModel.Legend;
                        viewModel.LocationIds = ViewLocationInput;
                        _context.Legend.Update(legend);

                        foreach (var item in ViewLocationInput)
                        {
                            LegendViewLocation newView = new LegendViewLocation()
                            {
                                LegendId = legend.LegendId,
                                ViewLocationId = item,
                            };

                            _context.Add(newView);
                        }
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LegendExists(viewModel.Legend.LegendId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(PendingIndex));
                }
                ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", viewModel.Legend.UserId);
                return View(viewModel);
        } else {
                return NotFound();
    }
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
                .Include(l => l.LegendViewLocations)
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
            var viewLocation = await _context.LegendViewLocation.Where(l => l.LegendId == legend.LegendId).ToListAsync();
            foreach(var item in viewLocation)
            {
                _context.LegendViewLocation.Remove(item);
            }
            _context.Legend.Remove(legend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PendingIndex));
        }

        private bool LegendExists(int id)
        {
            return _context.Legend.Any(e => e.LegendId == id);
        }
    }
}
