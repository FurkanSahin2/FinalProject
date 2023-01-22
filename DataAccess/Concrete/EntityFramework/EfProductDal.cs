using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // using: İçine yazılan nesneler using(in işi) bitince anında garbage collector tarafından atılır. Bunu kullanmamızın sebebi 'context' nesnesi biraz ağırdır.
            // IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                //EntityFramework'te referansı yakalamak için (Veri kaynağı ile eşleştirmek için);
                var addedEntity = context.Entry(entity);
                // O aslında eklenecek bir nesne olduğunu belirtmek için;
                addedEntity.State = EntityState.Added;
                // Eklemek için;
                context.SaveChanges();
            }
        }
        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Filtre 'null' değerinde mi?
                return filter == null
                    // Evet, 'null' ise çalışacak olan kod:
                    ? context.Set<Product>().ToList()
                    // Hayır, filtre mevcut ise -listeleyip vermesi için- çalışacak olan kod:
                    : context.Set<Product>().Where(filter).ToList();
            }
        }
        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
