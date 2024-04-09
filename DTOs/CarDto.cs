using CarsCRUD.Entity;

namespace CarsCRUD.DTOs;
public class CarDto : BaseDto
{
    public string Brand { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public static implicit operator CarDto(Car car) 
        => new() 
        {
            Brand = car.Brand,
            Name = car.Name,
            Price = car.Price,
            ImageUrl = car.ImageUrl
        };
}