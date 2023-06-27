using DataAccess.Abstract;
using Entities.concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //IDisposable  pattern 
            using (RentACarContext context = new RentACarContext())  
            {
                var addedEntity = context.Entry(entity);   // git veri kaynağından beni gönderdim car a  bir tane nesneye eşleştir
                addedEntity.State= EntityState.Added;      // ben veri kaynagi ile eslestirdim simdi burda ne yapayım 
                context.SaveChanges();
            }// close garbage collector
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var DeletedEntity = context.Entry(entity);   // git veri kaynağından beni gönderdim car a  bir tane nesneye eşleştir
                DeletedEntity.State = EntityState.Deleted;      // ben veri kaynagi ile eslestirdim simdi burda ne yapayım 
                context.SaveChanges();
            }// close 
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
                // DnSetten car bagalniyor oraya singleOrDefault uyguluyır foreach gibi dolanıyor
            }
            // yıldızlı not Car Brand Colour için standart kodlarımız hepsinde aynı olucak yani Generic base hale getirrrrrrrr
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {// ilk ifade SELECT * FROM CAR ikincide ise istedigin ifadeye göre getir linq
                return filter == null 
                    ? rentACarContext.Set<Car>().ToList() 
                    : rentACarContext.Set<Car>().Where(filter).ToList();      
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var UpdateEntity = context.Entry(entity);   // git veri kaynağından beni gönderdim car a  bir tane nesneye eşleştir
                UpdateEntity.State = EntityState.Modified;      // ben veri kaynagi ile eslestirdim simdi burda ne yapayım 
                context.SaveChanges();
            }// close
        }
    }
}
