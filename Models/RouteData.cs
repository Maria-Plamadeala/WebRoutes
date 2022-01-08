using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRoutes.Models
{
    public class RouteData
    {
        public IEnumerable<Route> Routes { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<RouteCategory> RouteCategories { get; set; }
    }
}
