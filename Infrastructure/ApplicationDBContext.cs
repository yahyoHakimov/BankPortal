using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ExternalMeeting> ExternalMeetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the one-to-one relationship between User and Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserID);

            // Define the many-to-one relationship between Department and Employee (Manager)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany(e => e.ManagedDepartments)
                .HasForeignKey(d => d.ManagerID);

            // Define the many-to-many relationship between User and Role via UserRoles
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserID, ur.RoleID });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
