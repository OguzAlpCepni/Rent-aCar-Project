using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.concrete
{
    public class Brand:IEntites
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
