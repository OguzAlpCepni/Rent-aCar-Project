using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{   // entity framework kullanarak bir enttiy base oluştur . 
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> // burayı yapmaktaki amacım ICar dalda fark ettiysen bağımlılık var onu yok etye çalışıyorum generic kullanarak Car ve RentaCarContexi tekrar tekrar yazmak istemediğim için veya farklı bir yapı kullanıcaksam onu daha kolay entegre edebilmek için kullanıyorum 
        where TEntity : class, IEntites, new()
        where TContext : DbContext , new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable  pattern 
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);   // git veri kaynağından beni gönderdim car a  bir tane nesneye eşleştir
                addedEntity.State = EntityState.Added;      // ben veri kaynagi ile eslestirdim simdi burda ne yapayım 
                context.SaveChanges();
            }// close garbage collector
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var DeletedEntity = context.Entry(entity);   // git veri kaynağından beni gönderdim car a  bir tane nesneye eşleştir
                DeletedEntity.State = EntityState.Deleted;      // ben veri kaynagi ile eslestirdim simdi burda ne yapayım 
                context.SaveChanges();
            }// close 
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
                // DbSetten car bagalniyor oraya singleOrDefault uyguluyır foreach gibi dolanıyor
            }
            // yıldızlı not Car Brand Colour için standart kodlarımız hepsinde aynı olucak yani Generic base hale getirrrrrrrr
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext rentACarContext = new TContext())
            {// ilk ifade SELECT * FROM CAR ikincide ise istedigin ifadeye göre getir linq
                return filter == null
                    ? rentACarContext.Set<TEntity>().ToList()
                    : rentACarContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var UpdateEntity = context.Entry(entity);   // git veri kaynağından beni gönderdim car a  bir tane nesneye eşleştir
                UpdateEntity.State = EntityState.Modified;      // ben veri kaynagi ile eslestirdim simdi burda ne yapayım 
                context.SaveChanges();
            }// close
        }
    }
}
