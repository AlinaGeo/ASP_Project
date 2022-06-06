using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ASP_Project.Entities
{
    // Ctrl + .
    // Add-Migration    Name-Migration      Remove-Migration(removes the last migration)        Update-Database

    // 1. Add-Migration
    // 2. Verify migration for mistakes
    // 3. Update-Database
    public class ASP_ProjectContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>     // code-first database -> first we write the code, then be transform the code into a db
    {
        public ASP_ProjectContext(DbContextOptions<ASP_ProjectContext> options) : base(options) { }     // dependency injection -> it becomes a service, but it doesn't use mmemory until it it used by a controller
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Partnership> Partnerships { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RestaurantPartnership> RestaurantPartnerships { get; set; }
        public DbSet<DishMenu> DishMenus { get; set; }

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseLoggerFactory(LoggerFactory.Create(DbContextOptionsBuilder => DbContextOptionsBuilder.AddConsole()))    // this line will print the result of the select into the console
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=ASP_Project_DB_v2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");
        }*/

        protected override void OnModelCreating(ModelBuilder builder)       // here we put the builders for the relations
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Restaurant>()        // ONE-TO-ONE
                .HasOne(r => r.Location)
                .WithOne(l => l.Restaurant);

            builder.Entity<Menu>()        // ONE-TO-ONE
                .HasOne(b => b.Beverages)
                .WithOne(m => m.Menu);

            builder.Entity<Restaurant>()        // ONE-TO-MANY
                .HasMany(r => r.Dishes)
                .WithOne(d => d.Restaurant);

            builder.Entity<Restaurant>()        // ONE-TO-MANY
                .HasMany(r => r.Beverages)
                .WithOne(b => b.Restaurant);

            builder.Entity<RestaurantPartnership>().HasKey(rp => new { rp.RestaurantId, rp.PartnershipId });

            builder.Entity<RestaurantPartnership>()     // MANY-TO-MANY
                .HasOne(rp => rp.Restaurant)
                .WithMany(r => r.RestaurantPartnerships)
                .HasForeignKey(rp => rp.RestaurantId);

            builder.Entity<RestaurantPartnership>()
                .HasOne(rp => rp.Partnership)
                .WithMany(p => p.RestaurantPartnerships)
                .HasForeignKey(rp => rp.PartnershipId);

            builder.Entity<DishMenu>().HasKey(dm => new { dm.DishId, dm.MenuId });

            builder.Entity<DishMenu>()     // MANY-TO-MANY
                .HasOne(dm => dm.Menu)
                .WithMany(m => m.DishMenus)
                .HasForeignKey(dm => dm.MenuId);

            builder.Entity<DishMenu>()
                .HasOne(dm => dm.Dish)
                .WithMany(d => d.DishMenus)
                .HasForeignKey(dm => dm.DishId);
        }
    }
}
