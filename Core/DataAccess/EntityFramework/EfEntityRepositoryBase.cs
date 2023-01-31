using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>: IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // using: İçine yazılan nesneler using(in işi) bitince anında garbage collector tarafından atılır. Bunu kullanmamızın sebebi 'context' nesnesi biraz ağırdır.
            // IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                //EntityFramework'te referansı yakalamak için (Veri kaynağı ile eşleştirmek için);
                var addedEntity = context.Entry(entity);
                // O aslında eklenecek bir nesne olduğunu belirtmek için;
                addedEntity.State = EntityState.Added;
                // Eklemek için;
                context.SaveChanges();
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
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Filtre 'null' değerinde mi?
                return filter == null
                    // Evet, 'null' ise çalışacak olan kod:
                    ? context.Set<TEntity>().ToList()
                    // Hayır, filtre mevcut ise -listeleyip vermesi için- çalışacak olan kod:
                    : context.Set<TEntity>().Where(filter).ToList();
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
