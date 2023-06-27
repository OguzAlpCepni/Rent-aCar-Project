using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.concrete
{
    public class Colour:IEntites
    {
        public int ColourId { get; set; }
        public string ColourName { get; set; }
    }
}
