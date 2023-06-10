using Microsoft.EntityFrameworkCore;
using MVCFoodDelivery.Models;
using MVCFoodDelivery.Repository;

namespace MVCFoodDelivery.Context
{
    public class ToLoginDbContext : DbContext
    {
        public ToLoginDbContext(DbContextOptions<ToLoginDbContext> options) : base(options) { }
              public DbSet<ToLogin> loginDetails { get; set; }
        
    

    }
}
