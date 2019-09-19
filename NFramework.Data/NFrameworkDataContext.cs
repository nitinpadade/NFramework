using Microsoft.EntityFrameworkCore;
using System;

namespace NFramework.Data
{
    public class NFrameworkDataContext : DbContext
    {
        public NFrameworkDataContext(DbContextOptions<NFrameworkDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Role>().ToTable("Role");
            //modelBuilder.Entity<User>().ToTable("User");
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
