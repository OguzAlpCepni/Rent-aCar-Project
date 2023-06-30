using DataAccess.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.InMemory
{
    public class InMemoryCarDal  
    {
        /*List<Car> _cars;
        public InMemoryCarDal() 
        {
            _cars = new List<Car>();
            new Car
            {
                CarId = 1,
                BrandId = 1,
                ColorId = 1,
                ModelYear = new DateTime(15, 05, 2012),
                DailyPrice = 500,
                Description = "if you wanna buy come to Istanbul"

            };
            new Car
            {
                CarId = 2,
                BrandId = 2,
                ColorId = 2,
                ModelYear = new DateTime(15, 05, 2012),
                DailyPrice = 1000,
                Description = "if you wanna buy come to ankara"

            };
            new Car
            {
                CarId = 3,
                BrandId = 3,
                ColorId = 4,
                ModelYear = new DateTime(15, 05, 2012),
                DailyPrice = 500,
                Description = "if you wanna buy come to izmir"

            };
            new Car
            {
                CarId = 4,
                BrandId = 3,
                ColorId = 2,
                ModelYear = new DateTime(15, 05, 2012),
                DailyPrice = 200,
                Description = "if you wanna buy come to afyon"

            };


        }

        public void add(Car car)
        {
            _cars.Add(car);
        }

        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car CarToDelete = null;
            CarToDelete = _cars.SingleOrDefault(p=>p.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(p=>p.CarId==car.CarId);
            CarToUpdate.CarId = car.CarId;
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
        }
        */
    }
}
