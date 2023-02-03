using Entities.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Entities
{
    public class PMS_DBContext : IdentityDbContext<ApplicationUser>
    {
        public PMS_DBContext(DbContextOptions<PMS_DBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.UserAddress);
                entity.Property(e => e.DateOfBirth);

            });
        }
    }
}
