using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        {
                
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
