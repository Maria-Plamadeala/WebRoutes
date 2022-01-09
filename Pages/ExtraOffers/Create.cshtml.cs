using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebRoutes.Data;
using WebRoutes.Models;

namespace WebRoutes.Pages.ExtraOffers
{
    public class CreateModel : ExtraOfferCategoriesPageModel
    {
        private readonly WebRoutes.Data.WebRoutesContext _context;

        public CreateModel(WebRoutes.Data.WebRoutesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            var extraoffer = new ExtraOffer();
            extraoffer.ExtraOfferCategories = new List<ExtraOfferCategory>();
            PopulateAssignedExtraCategoryData(_context, extraoffer);
            return Page();
        }

        [BindProperty]
        public ExtraOffer ExtraOffer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newExtraOffer = new ExtraOffer();
            if (selectedCategories != null)
            {
                newExtraOffer.ExtraOfferCategories = new List<ExtraOfferCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ExtraOfferCategory
                    {
                        extracategoryID = int.Parse(cat)
                    };
                    newExtraOffer.ExtraOfferCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<ExtraOffer>(
           newExtraOffer,
           "ExtraOffer",
           i => i.name, i => i.description,
           i => i.price))
            {
                _context.ExtraOffer.Add(newExtraOffer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedExtraCategoryData(_context, newExtraOffer);
            return Page();
        }
    }
}
