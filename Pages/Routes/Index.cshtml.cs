using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRoutes.Data;
using WebRoutes.Models;

namespace WebRoutes.Pages.Routes
{
    public class IndexModel : PageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public IndexModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        public IList<Route> Route { get; set; }
        public RouteData RouteD { get; set; }
        public int routeID { get; set; }
        public int categoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            RouteD = new RouteData();
            RouteD.Routes = await _context.Route.Include(b => b.Guide)
            .Include(b => b.RouteCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.name)
            .ToListAsync();
            if (id != null)
            {
                routeID = id.Value;
                Route route = RouteD.Routes
                .Where(i => i.ID == id.Value).Single();
                RouteD.Categories = route.RouteCategories.Select(s => s.Category);
            }
        }
    }
}
