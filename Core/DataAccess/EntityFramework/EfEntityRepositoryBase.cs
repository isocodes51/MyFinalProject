using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposible pattern implement of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //Referansı yakalama
                addedEntity.State = EntityState.Added; //Eklenecek nesne
                context.SaveChanges(); //Ekle ve Kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //Referansı yakalama
                deletedEntity.State = EntityState.Deleted; //Silinecek nesne
                context.SaveChanges(); //Ekle ve Kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList(); ;
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //Referansı yakalama
                updatedEntity.State = EntityState.Modified; //Güncellenecek nesne
                context.SaveChanges(); //Ekle ve Kaydet
            }
        }
    }
}
