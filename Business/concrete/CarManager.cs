using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Business;
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
        IBrandService _brandService;
        public CarManager(ICarDal CarDal, IBrandService brandService)
        {
            _CarDal = CarDal;
            _brandService = brandService;
        }
        [ValidationAspect(typeof(CarValidator))]// add metodunu dogrula carvalidator kullanarak 
        public IResults Add(Car car)
        {
            IResults result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.CarId), CheckIfCarNameExists(car.CarName));
                                                                             
            if(result !=null)
            {
                return result;
            }
            _CarDal.Add(car);
            return new SuccessResult(Message.CarAdded);                                         
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

        public IDataResult<List<Car>> GetById(int carId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p=>p.CarId == carId),Message.CarsListed);
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
        private IResults CheckIfCarNameExists(string carName)
        {
            var result = _CarDal.GetAll(p=>p.CarName==carName).Any();
            if(result==true)
            {
                return new ErrorResult(Message.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResults CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _CarDal.GetAll(p=>p.BrandId == brandId).Count;
            if(result <= 15)
            {
                return new ErrorResult(Message.CarCountOfBrandCorrect);
            }
            return new SuccessResult();
        }
        private IResults CheckifBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count > 20)
            {
                return new ErrorResult(Message.BrandLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
