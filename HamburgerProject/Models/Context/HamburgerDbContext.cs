using HamburgerProject.Models.Entities;
using HamburgerProject.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace HamburgerProject.Models.Context
{
    public class HamburgerDbContext:DbContext
    {
        public HamburgerDbContext(DbContextOptions<HamburgerDbContext> options): base (options)
        {

        }

        public DbSet<Extra> Extras { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuMapping());
            modelBuilder.ApplyConfiguration(new ExtraMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
