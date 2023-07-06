using Core.Utilities.Results;
using Entities.concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResults Add(Car car);
        IResults Delete(Car car);
        IResults Update(Car car);
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetByDailyPrice(int min,int max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
