using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{ 
    // bana bir vertabanı tablosu ver bir tane de bununla kurabileceğim bağlantıyı ver
    public class EfEntityRepositoryBase<TEntity, TContext>: IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //altta using = IDısposable pattern implementation of c#
            using (TContext context = new TContext()) //c# a özel GC using sonunda çalışır ve bunu siler 
            {
                var addedEntity = context.Entry(entity); //veritabanında benim gönderdiğimi işle / veri kaynağımla ilişkilendirdim
                addedEntity.State = EntityState.Added; //1) referansı yakala  2) eklenecek bir nesne olduğunu belirt (state durum demek, addedEntity nin durumu EntityState durumuna added işlemi yapan şeklinde eklenecek)
                context.SaveChanges(); // 3) değişikliği kaydet / ekle 
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); //gönderdiğim varsa getir, yoksa da hata verme default değer getir.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
