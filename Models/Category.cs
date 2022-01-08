using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRoutes.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Level")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage =
            "Level name is required"), Required, StringLength(50, MinimumLength = 3)]
        public string category_name { get; set; }
        public ICollection<RouteCategory> RouteCategories { get; set; }
    }
}
