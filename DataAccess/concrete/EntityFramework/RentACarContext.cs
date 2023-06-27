using Entities.concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete.EntityFramework
{
    //Context = Db tabloları ile  proje classlarını bağlamak
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Rent-aCar;Trusted_Connection=true");
        }
        public DbSet<Car> Car { get; set; }                  //hangi classım hangi tabloya karşılık geliyor
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Colour> Colour { get; set; }
    }
}
