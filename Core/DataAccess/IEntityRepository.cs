using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{   //evrensel katmanım 
    //core katmanı diğer katmanları referans almaz****  ---> alırsa o katmana bağlı olursun
    //Burada T: Sınıf adından arayüzler için. O arayüzler de kendi sınıfını alıyor. ICategoryDal'a bak
    // generic constraint-kısıt ==T 
    //class: referans tip olabilir demek, değer tipi olmaz
    //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir. 
    //new: newlenebilir olmalı --> IEntity interface ve newlenemez bu yüzden immplemente eden sınıfları kullanmalıyız 
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //istenilen detayları getirmek
        T Get(Expression<Func<T, bool>> filter); //tek data getirmek --> Bununla daha sonra linq ssorhuları yazıyoruz. 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
