using CarsCRUD.Entity;

namespace CarsCRUD.Commens.Helpers;
public static class Validator
{
    public static bool IsExist(this Car car, IEnumerable<Car> cars)
        => cars.Any(c => c.Brand == car.Brand 
                                    && c.Name == car.Name);
    public static bool IsValid(this Car car)
        => !string.IsNullOrEmpty(car.Name)
        && string.IsNullOrEmpty(car.Brand);
}