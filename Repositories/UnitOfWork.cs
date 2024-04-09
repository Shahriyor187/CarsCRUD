using CarsCRUD.Data;
using CarsCRUD.InterfacesForRepositories;

namespace CarsCRUD.Repositories;
public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        CarRepository = new CarRepository(_dbContext.Car);
    }

    private readonly ApplicationDbContext _dbContext;
    public ICarRepository CarRepository { get; }
}