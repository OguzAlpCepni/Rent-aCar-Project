using Core.Utilities.Results;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IResults Add(Brand brand);
        IResults Delete(Brand brand);
        IResults Update(Brand brand);
        
    }
}
