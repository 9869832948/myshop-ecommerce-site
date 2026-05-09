using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace myshop2.Models
{
    public class myContext : DbContext
    {
        public myContext(DbContextOptions<myContext>options) : base(options)
        {
            
        }
        public DbSet<Admin> tbl_admin{ get; set; }
        public DbSet<Customer> tbl_customer { get; set; }
        public DbSet<Category> tbl_category { get; set; }
        public DbSet<Product> tbl_product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Product)
                .HasForeignKey(p => p.cat_id);
        }
    }
}
