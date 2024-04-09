namespace CarsCRUD.InterfacesForRepositories
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
    }
}