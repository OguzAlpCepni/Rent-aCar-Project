using Business.Abstract;
using DataAccess.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.concrete
{
    public class ColourManager : IColourService
    {
        IColourDal _colurDal;
        public ColourManager(IColourDal colurDal)
        {
            _colurDal = colurDal;
        }

        public void Add(Colour colour)
        {
            _colurDal.Add(colour);
        }

        public void Delete(Colour colour)
        {
            
        }

        public List<Colour> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Colour colour)
        {
            throw new NotImplementedException();
        }
    }
}
