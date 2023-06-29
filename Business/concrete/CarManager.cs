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
        public CarManager(ICarDal CarDal)
        {
            _CarDal = CarDal;
        }

        public void Add(Car car)
        {
            _CarDal.Add(car);
        }

        public void Delete(Car car)
        {
            _CarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _CarDal.GetAll(p=>p.BrandId == id);
        }

        public List<Car> GetByDailyPrice(int min, int max)
        {
            return _CarDal.GetAll(p=>p.DailyPrice>=min&&p.DailyPrice<=max);
        }

        public void Update(Car car)
        {
            _CarDal.Update(car);
        }
    }
}
