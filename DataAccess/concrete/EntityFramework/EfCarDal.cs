using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.EntityFramework
{
    public class EfCarDal :EfEntityRepositoryBase<Car,RentACarContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from p in context.Car
                             join c in context.Brand
                             on p.BrandId equals c.BrandId
                             select new CarDetailDto 
                             {
                                 CarId = p.CarId,
                                 CarName = p.CarName,
                                 BrandName = c.BrandName,
                                 DailyPrice = p.DailyPrice 
                             };
                return result.ToList();
            }
        }
    }
}
