using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Entities
{
    public class PMS_DBContext : IdentityDbContext
    {
        public PMS_DBContext(DbContextOptions options) : base(options)
        {

        }
        /*public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasData(new User()
            {
                UserId = Guid.NewGuid(),
                FirstName = "Shuvo",
                LastName = "Islam",
                Email = "suvoislam753@gmail.com",
                PhoneNumber = "1234567890",
                UserName = "suvoislam123",
                UserAddress = "lohajong,Munshigonj"
            });
        }*/
    }
}
