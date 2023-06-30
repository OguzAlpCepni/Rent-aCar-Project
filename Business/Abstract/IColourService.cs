using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColourService
    {
        List<Colour> GetAll();
        void Add(Colour colour);
        void Delete(Colour colour);
        void Update(Colour colour);
    }
}
