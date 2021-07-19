using Entities;
using Microsoft.EntityFrameworkCore;
using Enums;
namespace Db
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(x=>x.WrapperType)
                .HasDefaultValue(WrapperType.Box);
        }
    }
}