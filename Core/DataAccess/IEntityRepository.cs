using Entities.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class,IEntites,new()
    {                                                                       //getById gibi kodlara ihtiyacin yok böylelikleeee            
        List<T> GetAll(Expression<Func<T, bool>> filter = null);           //categoriye göre getir ürün fiyatına göre vb. metodları tekrar ayrı ayrı metodlar yazmanı engelleyen kod bloğu 
        T Get(Expression<Func<T, bool>> filter);                                                       //I create filter after give to me data
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
