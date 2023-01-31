using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess 
{
    // Not: 'Core' katmanı diğer katmanları referans almaz. Çünkü Core katmanı bağımsız olmalıdır.

    // generic constraint => Jenerik Kısıt
    // Amacımız, sistemimizin gerçekten veri tabanı nesneleriyle çalışmasını sağlamaktır.
    // class: "referans tip" olabilir.
    // IEntity: "IEntity veya IEntity implemente eden bir nesne" olabilir.
    // new(): New'lenebilir olmalı.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // 'filter=null' => filtre vermeyebiliriz. Yani filtre vermemiş ise tüm data'yı istiyor demektir.
        T Get(Expression<Func<T, bool>> filter); // filtre zorunludur.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
