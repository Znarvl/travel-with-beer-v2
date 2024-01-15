using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Spatial;
using System.Drawing;

namespace backend.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<PersonProject> PersonProjects { get; set; }
        public DbSet<ProjectMessage> ProjectMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Person
            modelBuilder.Entity<Person>()
                .HasKey(p => p.PersonId);

            // Project
            modelBuilder.Entity<Project>()
                .HasKey(p => p.ProjectId);

            // PersonProject
            modelBuilder.Entity<PersonProject>()
                .HasKey(pp => new { pp.PersonId, pp.ProjectId });

            modelBuilder.Entity<PersonProject>()
                .HasOne(pp => pp.Person)
                .WithMany(p => p.PersonProjects)
                .HasForeignKey(pp => pp.PersonId);

            modelBuilder.Entity<PersonProject>()
                .HasOne(pp => pp.Project)
                .WithMany(p => p.PersonProjects)
                .HasForeignKey(pp => pp.ProjectId);

            // ProjectMessage
            modelBuilder.Entity<ProjectMessage>()
                .HasKey(pm => pm.MessageId);

            modelBuilder.Entity<ProjectMessage>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.ProjectMessages)
                .HasForeignKey(pm => pm.ProjectId);

            modelBuilder.Entity<ProjectMessage>()
                .HasOne(pm => pm.Person)
                .WithMany(p => p.ProjectMessages)
                .HasForeignKey(pm => pm.PersonId);

        }
    }
}
