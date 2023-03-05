using Car_Unit_Test;

namespace ObliRESTAPI.Properties
{
    public class CarsRepository
    {
        private int _nextId;
        private static List<Car> cars;

        public CarsRepository()
        {
            _nextId = 1;
            cars = new List<Car>()
            {
                new Car {Id = _nextId++, Model = "Toyota", Price = 222222, LicensePlate = "TO2011"},
                new Car {Id = _nextId++, Model = "Panda", Price = 111111, LicensePlate = "PA2011"}
            };
        }

        public List<Car> GetAll()
        {
            return new List<Car>(cars);
        }

        public Car? GetById(int id)
        {
            var car = cars.Find(Car => Car.Id == id);
            if(car == null)
            {
                throw new ArgumentException($"The car with id {id} could not be found");
            }
            return car;
        }

        public Car Add(Car newCar)
        {
            if(newCar == null)
            {
                throw new ArgumentNullException("The car can't be created as null");
            }
            newCar.Id = _nextId++;
            cars.Add(newCar);
            return newCar;
        }

        public Car? Update(Car newCarinfo, int id)
        {
            Car? carToBeUpdated = GetById(id);            
            carToBeUpdated.LicensePlate = newCarinfo.LicensePlate;
            carToBeUpdated.Model = newCarinfo.Model;
            carToBeUpdated.Price = newCarinfo.Price;
                return carToBeUpdated;
        }

        public void Delete(int id)
        {
            Car carToBeDeleted = GetById(id);            
            cars.Remove(carToBeDeleted);
        }
    }
}
