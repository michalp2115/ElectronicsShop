using ElectronicsShop.Entities;
using ElectronicsShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ElectronicsShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        //public DbSet<LoginRequest> LoginRequests { get; set; }
        //public DbSet<RegisterRequest> RegisterRequests { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Item>().HasData(
        //        new Item()
        //        {
        //            Id = 1,
        //            Name = "Mouse",
        //            Description = "Wireless mouse"
        //        });
        //}
    }

}
