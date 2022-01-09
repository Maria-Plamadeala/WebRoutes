using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRoutes.Data;

namespace WebRoutes.Models
{
    public class ExtraOfferCategoriesPageModel: PageModel
    {
        public List<AssignedExtraCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedExtraCategoryData(WebRoutesContext context,
        ExtraOffer extraoffer)
        {
            var allCategories = context.ExtraCategory;
            var extraofferCategories = new HashSet<int>(
            extraoffer.ExtraOfferCategories.Select(c => c.extracategoryID)); //
            AssignedCategoryDataList = new List<AssignedExtraCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedExtraCategoryData
                {
                    extracategoryID = cat.ID,
                    name = cat.extra_category_name,
                    assigned = extraofferCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateExtraOfferCategories(WebRoutesContext context,
        string[] selectedCategories, ExtraOffer extraofferToUpdate)
        {
            if (selectedCategories == null)
            {
                extraofferToUpdate.ExtraOfferCategories = new List<ExtraOfferCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var extraofferCategories = new HashSet<int>
            (extraofferToUpdate.ExtraOfferCategories.Select(c => c.ExtraCategory.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!extraofferCategories.Contains(cat.ID))
                    {
                        extraofferToUpdate.ExtraOfferCategories.Add(
                        new ExtraOfferCategory
                        {
                            extraofferID = extraofferToUpdate.ID,
                            extracategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (extraofferCategories.Contains(cat.ID))
                    {
                        ExtraOfferCategory courseToRemove
                        = extraofferToUpdate
                        .ExtraOfferCategories
                        .SingleOrDefault(i => i.extracategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
