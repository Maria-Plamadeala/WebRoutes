using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebRoutes.Data;
using WebRoutes.Models;

namespace WebRoutes.Pages.ExtraOffers
{
    public class EditModel : ExtraOfferCategoriesPageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public EditModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExtraOffer ExtraOffer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExtraOffer = await _context.ExtraOffer.Include(b => b.ExtraOfferCategories).ThenInclude(b => b.ExtraCategory)
.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (ExtraOffer == null)
            {
                return NotFound();
            }

            PopulateAssignedExtraCategoryData(_context, ExtraOffer);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var extraofferToUpdate = await _context.ExtraOffer
         
           .Include(i => i.ExtraOfferCategories)
           .ThenInclude(i => i.ExtraCategory)
           .FirstOrDefaultAsync(s => s.ID == id);
            if (extraofferToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<ExtraOffer>(
            extraofferToUpdate,
            "ExtraOffer",
            i => i.name, i => i.description,
            i => i.price))
            {
                UpdateExtraOfferCategories(_context, selectedCategories, extraofferToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdateExtraOfferCategories(_context, selectedCategories, extraofferToUpdate);
            PopulateAssignedExtraCategoryData(_context, extraofferToUpdate);
            return Page();
        }

        private bool ExtraOfferExists(int id)
        {
            return _context.ExtraOffer.Any(e => e.ID == id);
        }
    }
}
