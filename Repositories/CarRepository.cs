using CarsCRUD.Entity;
using CarsCRUD.InterfacesForRepositories;
using MongoDB.Driver;

namespace CarsCRUD.Repositories;
public class CarRepository(IMongoCollection<Car> collection)
    : Repository<Car>(collection), ICarRepository
{
}