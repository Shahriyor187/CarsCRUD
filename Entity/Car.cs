using CarsCRUD.DTOs;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CarsCRUD.Entity;
public class Car : BaseEntity
{
    [Required, StringLength(20)]
    public string Brand { get; set; } = string.Empty;
    [Required, StringLength(30)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string ImageUrl { get; set; } = string.Empty;
}