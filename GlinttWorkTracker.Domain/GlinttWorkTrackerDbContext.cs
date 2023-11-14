using GlinttWorkTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain
{
    public class GlinttWorkTrackerDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Work> Users { get; set; }

        public GlinttWorkTrackerDbContext()
        {

        }
        public GlinttWorkTrackerDbContext(DbContextOptions<GlinttWorkTrackerDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //string SqlConnectionString = @"Server=localhost; User Id=sa;Password=mystrongpasswd123!#;Initial Catalog=shopping-list; Connect Timeout = 30";

            options
                .UseSqlite("Data Source=shoppinglist.db");
            //.UseSqlServer(SqlConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasIndex(i => i.Username).IsUnique();
            modelBuilder.Entity<User>().Property(i => i.Username)
                .IsRequired().HasMaxLength(256);
            modelBuilder.Entity<User>().Property(i => i.Password)
                .HasMaxLength(256);
            modelBuilder.Entity<User>().Property(i => i.IsAdmin)
                .IsRequired();

            modelBuilder.Entity<Category>().HasIndex(i => i.Name).IsUnique();
            modelBuilder.Entity<Category>().Property(i => i.Name)
               .IsRequired().HasMaxLength(256);


            modelBuilder.Entity<Product>().HasIndex(i => i.Name).IsUnique();
            modelBuilder.Entity<Product>().Property(i => i.Name)
               .IsRequired().HasMaxLength(256);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShoppingList>()
                .HasIndex(t => new { t.Name, t.UserId }).IsUnique();
            modelBuilder.Entity<ShoppingList>().Property(i => i.Name)
               .IsRequired().HasMaxLength(256);
            modelBuilder.Entity<ShoppingList>().Property(i => i.Color)
                .HasMaxLength(9);
            modelBuilder.Entity<ShoppingList>().Property(i => i.Status)
               .IsRequired();
            modelBuilder.Entity<ShoppingList>().Property(i => i.CreationDate)
               .IsRequired();



            modelBuilder.Entity<ShoppingListProduct>()
                .HasIndex(t => new { t.ShoppingListId, t.ProductUserId }).IsUnique();
            modelBuilder.Entity<ShoppingListProduct>().Property(i => i.Quantity)
                .IsRequired();

            modelBuilder.Entity<ShoppingListProduct>()
                .HasOne(p => p.ShoppingList)
                .WithMany(p => p.ShoppingListProducts)
                .HasForeignKey(p => p.ShoppingListId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShoppingListProduct>()
                .HasOne(p => p.ProductUser)
                .WithMany(t => t.ShoppingListProducts)
                .HasForeignKey(p => p.ProductUserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProductUser>()
                 .HasIndex(t => new { t.ProductId, t.UserId }).IsUnique();

            modelBuilder.Entity<ProductUser>()
               .HasOne(p => p.Product)
               .WithMany(p => p.ProductUsers)
               .HasForeignKey(p => p.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductUser>()
                .HasOne(p => p.User)
                .WithMany(t => t.ProductUsers)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasData(new User
            { Id = 1, Username = "admin", Password = "admin", IsAdmin = true });
        }
    }

}
