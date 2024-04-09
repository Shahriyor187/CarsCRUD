using CarsCRUD.Entity;

namespace CarsCRUD.DTOs;
public class AddCarDto 
{
    public string Brand { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public static implicit operator Car(AddCarDto car) => new()
    {
        Brand = car.Brand,
        Name = car.Name,
        Price = car.Price,
        ImageUrl = car.ImageUrl
    };
}