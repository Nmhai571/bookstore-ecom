using ecom.minhhai.bookstore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecom.minhhai.bookstore.Context
{
    public class BookStoreDbContext : IdentityDbContext<AccountModel>
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public BookStoreDbContext()
        {

        }
        public DbSet<BookModel> BookModels { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<PageModel> Pages { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<TransactStatusModel> TransactStatuses { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UserData();
            modelBuilder.RoleData();
            modelBuilder.UserRoleData();
            modelBuilder.CategoryData();
            modelBuilder.BookData();
            modelBuilder.PostData();
            modelBuilder.PaymentData();
            modelBuilder.LocationData();
            modelBuilder.TranSactStatusData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
