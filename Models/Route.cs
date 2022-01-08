using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRoutes.Models
{
    public class Route
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 5)]
        [Display(Name = "Route Title")]
        public string name { get; set; }

        [Required, StringLength(800, MinimumLength = 15)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required, StringLength(150, MinimumLength = 4)]
        [Display(Name = "Duration")]
        public string duration { get; set; }

        [Display(Name = "Price")]

        [Column(TypeName = "decimal(5, 2)")]
        [Range(1, 500)]
        public decimal price { get; set; }

        public int guideID { get; set; }
        public Guide Guide { get; set; }

        [Display(Name = "Level")]
        public ICollection<RouteCategory> RouteCategories { get; set; }

    }
}

