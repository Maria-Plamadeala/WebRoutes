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
    public class DetailsModel : PageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public DetailsModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        public ExtraCategory ExtraCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExtraCategory = await _context.ExtraCategory.FirstOrDefaultAsync(m => m.ID == id);

            if (ExtraCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
