using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRoutes.Data;
using WebRoutes.Models;

namespace WebRoutes.Pages.ExtraCategories
{
    public class IndexModel : PageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public IndexModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        public IList<ExtraCategory> ExtraCategory { get;set; }

        public async Task OnGetAsync()
        {
            ExtraCategory = await _context.ExtraCategory.ToListAsync();
        }
    }
}
