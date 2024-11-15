﻿using System.ComponentModel.DataAnnotations;

namespace Restaurants.Domain.Entities; 
public class Customer {

    [Key]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public Address? Address { get; set; }
    [Required]
    public int? FavoriteRestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = new();
 }
