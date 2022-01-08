using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebRoutes.Models;

namespace WebRoutes.Data
{
    public class WebRoutesContext : DbContext
    {
        public WebRoutesContext (DbContextOptions<WebRoutesContext> options)
            : base(options)
        {
        }

        public DbSet<WebRoutes.Models.Route> Route { get; set; }

        public DbSet<WebRoutes.Models.Guide> Guide { get; set; }

        public DbSet<WebRoutes.Models.Category> Category { get; set; }
    }
}
