using kauaicapstone.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kauaicapstone.ViewComponents
{
    public class SearchResultsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SearchResultsViewComponent (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string searchString)

        {
            ViewData["CurrentFilter"] = searchString;

            var searchResults =  await _context.ViewLocation
                .Where(v => v.Name.Contains(searchString))
                .ToListAsync();


            return View(searchResults);
        }
    }
}
