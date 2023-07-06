using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.concrete;
using Entities.DTOs;
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

        public IResults Add(Car car)
        {
            if (car.CarName.Length <= 1) return new ErrorResult(Message.CarNameInValid);        // kontrol
            _CarDal.Add(car);                                                                   // araba eklendi 
            return new SuccessResult(Message.CarAdded);                                         // mesaj gönderildi
        }

        public IResults Delete(Car car)
        {
            _CarDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Car>>(_CarDal.GetAll(),Message.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(), Message.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {

            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetails());
        }

        public IResults Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }
    }
}
