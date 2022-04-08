using System;
using System.Text;
using System.Collections.Generic;
using CinemaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CinemaManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

            modelBuilder.Entity<Coupon_Movie>().HasKey(cm => new
            {
                cm.CouponId,
                cm.MovieId
            });

            modelBuilder.Entity<Coupon_Movie>().HasOne(x => x.Movie).WithMany(cm => cm.Coupons_Movies).HasForeignKey(x => x.MovieId);
            modelBuilder.Entity<Coupon_Movie>().HasOne(x => x.Coupon).WithMany(cm => cm.Coupons_Movies).HasForeignKey(x => x.CouponId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Coupon_Movie> Coupons_Movies { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

        //Data related tables

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        //Order related tables

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CinemaManagementSystem.Models.Category> Category { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
