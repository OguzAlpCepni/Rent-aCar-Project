using Core.DataAccess.EntityFramework;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    internal class ICarDal
    {
        List<Car> GetAll();
    }
}
