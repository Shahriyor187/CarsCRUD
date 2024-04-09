using CarsCRUD.DTOs;
using CarsCRUD.Entity;
using MongoDB.Bson;
public interface ICarService
{
    Task<List<CarDto>> GetAllCars();
    Task<CarDto> GetCarById(string id);
    Task CreateCar(AddCarDto addCar);
    Task UpdateCar(CarDto carDto);
    Task DeleteCar(string id);
}