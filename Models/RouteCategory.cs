using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRoutes.Models
{
    public class RouteCategory
    {
        public int ID { get; set; }
        public int routeID { get; set; }
        public Route Route { get; set; }
        public int categoryID { get; set; }
        public Category Category { get; set; }
    }
}
