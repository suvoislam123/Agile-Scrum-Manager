using Entities.Account;
using Entities.JoinTables;
using Entities.ProjectEntities;
using Entities.TeamEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Entities
{
    public class PMS_DBContext : IdentityDbContext<ApplicationUser>
    {
        public PMS_DBContext(DbContextOptions<PMS_DBContext> options) : base(options)
        {
            
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ApplicationUserProject> ApplicationUserProjects { get; set; }
        
        public DbSet<Board> Boards { get; set; }
        public DbSet<TempIssue> TempIssues { get; set; }
        //public DbSet<Backlog> Backlogs { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AttachedFile> AttachedFiles { get; set; }
        public DbSet<AttachedLink> AttachedLinks { get; set; }

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
            //User To Team Many to Many realtion
            builder.Entity<Team>()
            .HasMany(t => t.Users)
            .WithMany(u => u.Teams)
            .UsingEntity<TeamUser>(
                j => j
                    .HasOne(tu => tu.User)
                    .WithMany()
                    .HasForeignKey(tu => tu.UserId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne(tu => tu.Team)
                    .WithMany()
                    .HasForeignKey(tu => tu.TeamId)
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey(tu => new { tu.UserId, tu.TeamId });
                    j.HasIndex(tu => new { tu.TeamId, tu.UserId }).IsUnique();
                }
            );

            //Projects to Board Many to One relationship
            builder.Entity<Board>()
                 .HasOne(p => p.Project)
                 .WithMany(b => b.Boards)
                 .HasForeignKey(k => k.ProjectId)
                 .OnDelete(DeleteBehavior.Cascade);
            //Board to Backlog One to One relation 
            builder.Entity<Board>()
                .HasOne(b=>b.Backlog)
                .WithOne(b=>b.Board)
                .HasForeignKey<Backlog>(k => k.boardId);
           
            builder.Entity<TempIssue>()
                 .HasOne(b => b.Board)
                 .WithMany(t => t.TempIssues)
                 .HasForeignKey(b => b.BoardId);
            //Board to Sprint One to Many Relation
            builder.Entity<Sprint>()
                .HasOne(b => b.Board)
                .WithMany(s => s.Sprints)
                .HasForeignKey(k => k.BoardId);
            //Sprint to Issue One to Many relation
            builder.Entity<Issue>()
                .HasOne(s => s.Sprint)
                .WithMany(s => s.Issues)
                .HasForeignKey(k => k.SprintId);
            //Issue to Comment One to Many relation
            builder.Entity<Comment>()
                .HasOne(i => i.Issue)
                .WithMany(c => c.Comments)
                .HasForeignKey(k => k.IssueId);           
            //Issue to AttatchedLink One to many relation
            builder.Entity<AttachedLink>()
                .HasOne(i => i.Issue)
                .WithMany(a => a.AttachedLinks)
                .HasForeignKey(k => k.IssueId);
            //Issue to AttatchedFile One to Many relation
            builder.Entity<AttachedFile>()
                .HasOne(i => i.Issue)
                .WithMany(a => a.AttachedFiles)
                .HasForeignKey(k => k.IssueId);

        }
    }
}
