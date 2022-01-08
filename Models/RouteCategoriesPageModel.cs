using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRoutes.Data;

namespace WebRoutes.Models
{
    public class RouteCategoriesPageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(WebRoutesContext context,
        Route route)
        {
            var allCategories = context.Category;
            var routeCategories = new HashSet<int>(
            route.RouteCategories.Select(c => c.categoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    categoryID = cat.ID,
                    name = cat.category_name,
                    assigned = routeCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateRouteCategories(WebRoutesContext context,
        string[] selectedCategories, Route routeToUpdate)
        {
            if (selectedCategories == null)
            {
                routeToUpdate.RouteCategories = new List<RouteCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var routeCategories = new HashSet<int>
            (routeToUpdate.RouteCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!routeCategories.Contains(cat.ID))
                    {
                        routeToUpdate.RouteCategories.Add(
                        new RouteCategory
                        {
                            routeID = routeToUpdate.ID,
                            categoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (routeCategories.Contains(cat.ID))
                    {
                        RouteCategory courseToRemove
                        = routeToUpdate
                        .RouteCategories
                        .SingleOrDefault(i => i.categoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
