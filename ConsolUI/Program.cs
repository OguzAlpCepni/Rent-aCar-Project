using Business.concrete;
using DataAccess.concrete.EntityFramework;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }
        } 
    }
}