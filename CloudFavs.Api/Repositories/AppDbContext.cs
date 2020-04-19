using CloudFavs.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudFavs.Api.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Folder>()
                .Property(b => b.Created)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Folder>()
                .Property(b => b.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Favorite>()
                .Property(b => b.Created)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Favorite>()
                .Property(b => b.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Folder>().HasData(new Folder 
                { Id = new Guid("43d0b777-8548-4710-a7b2-fcd8aabf9488"), OwnerId = new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34"), Name = "Learning" });
            modelBuilder.Entity<Folder>().HasData(new Folder
                { Id = new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"), OwnerId = new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34"), Name = "News" });
            modelBuilder.Entity<Folder>().HasData(new Folder
                { Id = new Guid("995d12ac-b84c-4dac-bcff-27857a1e9f95"), OwnerId = new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34"), Name = "Games" });

            modelBuilder.Entity<Favorite>().HasData(
                new Favorite
                {
                    Id = new Guid("1e114a99-26ad-4e33-9cd1-8c592aabb2bf"),
                    OwnerId = new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34"),
                    FolderId = new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"),
                    Name = "BBC News",
                    Uri = "http://www.bbcnews.com",
                    IsPinned = true
                });
        }
    }
}
