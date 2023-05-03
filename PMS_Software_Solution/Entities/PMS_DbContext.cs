using Entities.Account;
using Entities.JoinTables;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Entities
{
    public class PMS_DBContext : IdentityDbContext<ApplicationUser>
    {
        public PMS_DBContext(DbContextOptions<PMS_DBContext> options) : base(options)
        {
            
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserProject> applicationUserProjects { get; set; }
        public DbSet<Board> Boards { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Project to user many to many relationship
            builder.Entity<ApplicationUserProject>()
                .HasKey(cs => new { cs.ProjectId, cs.ApplicationUserId });
            builder.Entity<ApplicationUserProject>()
                .HasOne(p => p.Project)
                .WithMany(u => u.ApplicationUserProjects)
                .HasForeignKey(p => p.ProjectId);
            builder.Entity<ApplicationUserProject>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(u => u.ApplicationUserProjects)
                .HasForeignKey(a => a.ApplicationUserId);
            //Projects to Board Many to One relationship
            builder.Entity<Board>()
                 .HasOne(p => p.Project)
                 .WithMany(b => b.Boards)
                 .HasForeignKey(k => k.ProjectId);
            //Board to Sprint One to Many Relation
            builder.Entity<Sprint>()
                .HasOne(b => b.Board)
                .WithMany(s => s.Sprints)
                .HasForeignKey(k => k.BoardId);
        }
    }
}
