using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRoutes.Data;
using WebRoutes.Models;

namespace WebRoutes.Pages.ExtraOffers
{
    public class DetailsModel : PageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public DetailsModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        public ExtraOffer ExtraOffer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExtraOffer = await _context.ExtraOffer.FirstOrDefaultAsync(m => m.ID == id);

            if (ExtraOffer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
