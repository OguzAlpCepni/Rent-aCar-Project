using Business.Abstract;
using DataAccess.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;
        CarManager(ICarDal CarDal)
        {
            _CarDal = CarDal;
        }

        public void Add(Car car)
        {
            _CarDal.add(car);
        }

        public void Delete(Car car)
        {
            _CarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public void Update(Car car)
        {
            _CarDal.Update(car);
        }
    }
}
