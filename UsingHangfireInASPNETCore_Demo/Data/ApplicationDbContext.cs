using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsingHangfireInASPNETCore_Demo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<ImageVariant> ImageVariants { get; set; }
        public DbSet<OriginalImage> OriginalImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // be sure to call the base model creator
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ImageVariant>().ToTable("ImageVariant");
            modelBuilder.Entity<OriginalImage>().ToTable("OriginalImage");
        }
    }
}
