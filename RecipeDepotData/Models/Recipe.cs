﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeDepotData.Models
{
  public class Recipe : DateAsset
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RecipeId { get; set; }

    public bool Shared { get; set; }

    [Required]
    [MaxLength]
    public string Title { get; set; }

    [Column(TypeName = "text")]
    [MaxLength]
    public string Description { get; set; }

    [Column(TypeName = "text")]
    [MaxLength]
    public string Steps { get; set; }

    public string ImageUrl { get; set; }
    public int CookTime { get; set; }
    public int PrepTime { get; set; }

    [MaxLength(25)]
    public string DishType { get; set; }

    [MaxLength(25)]
    public string MainIngredient { get; set; }

    [MaxLength(25)]
    public string Seasons { get; set; }

    public Patron Patron { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
    public ICollection<Review> Reviews { get; set; }
  }
}
