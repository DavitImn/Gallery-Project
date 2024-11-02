using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Domain.DTO;
using Gallery.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Repository.Dbcontext
{
    public class GalleryDbContext : DbContext, IGalleryDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["GalleryDb"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GalleryItem>().OwnsOne(p => p.Draft);
            modelBuilder.Entity<GalleryItem>().OwnsOne(p => p.Published);
        }
    }
}
