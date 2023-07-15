using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        
        public IResults Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Message.BrandAdded);
        }

        public IResults Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.BrandDelete);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Message.BrandListed);
        }

        

        public IResults Update(Brand brand)
        {
           _brandDal.Update(brand);
            return new SuccessResult(Message.BrandUpdate);
        }
    }
}
