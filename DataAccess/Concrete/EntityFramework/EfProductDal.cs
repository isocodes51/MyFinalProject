using DataAccess.Abstract;
using Entitites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{ //NuGet
   public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposible pattern implement of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //Referansı yakalama
                addedEntity.State = EntityState.Added; //Eklenecek nesne
                context.SaveChanges(); //Ekle ve Kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //Referansı yakalama
                deletedEntity.State = EntityState.Deleted; //Silinecek nesne
                context.SaveChanges(); //Ekle ve Kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //Referansı yakalama
                updatedEntity.State = EntityState.Modified; //Güncellenecek nesne
                context.SaveChanges(); //Ekle ve Kaydet
            }
        }
    }
}
