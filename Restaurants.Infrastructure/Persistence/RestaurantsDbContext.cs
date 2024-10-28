﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence; 
internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options) {
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }
    internal DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
       base.OnModelCreating(modelBuilder);

        //Combine the two tables of address and restaurants and add address columns to the restaurants columns in restaurants table. 
         modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);
        //define the relationship between the restaurants table and dishes (one to many) and announce the foreign key
        modelBuilder.Entity<Restaurant>().HasMany(r => r.Dishes).WithOne().HasForeignKey(d => d.RestaurantId);
        
        //
        //Combine the two tables of address and customers and add address columns to the customer columns in customers table. 
        modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
        modelBuilder.Entity<Customer>()
            .HasOne(r => r.Restaurant)
            .WithOne(r => r.Customer)
            .HasForeignKey<Customer>(r => r.FavoriteRestaurantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}