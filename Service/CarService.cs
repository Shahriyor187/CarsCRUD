using CarsCRUD.Commens.Exceptions;
using CarsCRUD.Commens.Helpers;
using CarsCRUD.DTOs;
using CarsCRUD.Entity;
using CarsCRUD.InterfacesForRepositories;
using MongoDB.Bson;

namespace CarsCRUD.Service;
public class CarService(IUnitOfWork unitOfWork) : ICarService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task CreateCar(AddCarDto addCar)
    {
        if(addCar == null)
        {
            throw new ArgumentNullException(nameof(addCar));
        }
        if(addCar.Brand == null) 
        {
            throw new ArgumentNullException("Brand can not be null");
        }
        if(addCar.Name == null)
        {
            throw new ArgumentNullException("Name can not be null");
        }
        if(addCar.Price == 0)
        {
            throw new ArgumentNullException("Price can not be null");
        }
        var car = (Car)addCar;
        var cars = await _unitOfWork.CarRepository.GetAllAsync();
        if (!car.IsValid())
        {
            throw new ArgumentException("Car is not valid");
        }
        if (car.IsExist(cars))
        {
            throw new ArgumentException("Car already exist!");
        }
        await _unitOfWork.CarRepository.AddAsync(car);
    }
    public async Task DeleteCar(string id)
    {
        if(!ObjectId.TryParse(id, out ObjectId objectid))
        {
            throw new CustomException("Car's id looks not ObjectId");
        }
        var car = await _unitOfWork.CarRepository.GetByIdAsync(id);
        if (car != null)
        {
            throw new NotFoundException("Car was not found");
        }
        await _unitOfWork.CarRepository.DeleteAsync(id);
    }
    public async Task<List<CarDto>> GetAllCars()
    {
        var cars = await _unitOfWork.CarRepository.GetAllAsync();
        return cars.Select(c => (CarDto)c).ToList();
    }
    public async Task<CarDto> GetCarById(string id)
    {
        var car = await _unitOfWork.CarRepository.GetByIdAsync(id);
        if(car != null)
        {
            throw new NotFoundException("Car was not found");
        }
        return car;
    }
    public async Task UpdateCar(CarDto carDto)
    {
        var id = carDto.Id;
        if(!ObjectId.TryParse(id, out ObjectId objectId))
        {
            throw new CustomException("Car's id looks not ObjectId");
        }
        if(carDto is null)
        {
            throw new ArgumentNullException("Car can not be null");
        }
        var car1 = await _unitOfWork.CarRepository.GetByIdAsync(id);
        var car = (Car)car1;
        if (!car.IsValid())
        {
            throw new CustomException("Car is not valid");
        }
        await _unitOfWork.CarRepository.UpdateAsync(car);
    }
}