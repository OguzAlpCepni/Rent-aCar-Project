using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.concrete
{
    internal class Car
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public DateTime ModelYear { get; set; }
        public int MyProperty { get; set; }
    }
}
