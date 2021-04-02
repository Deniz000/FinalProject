using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{ 
    // Bu yapı bize s-o-lid harfini sağlar. Eğer her sınıfı IEntityRepostory e bağlasaydık o interface içinde bir sürü if-else yapısı oluşturacaktık
    //Bu yapı bizi bu kod karmaşasından kurtarır. Sınıf adında bir interface ve yine parametre o sınıf, üstelik IEntitRe'de T bizim istediğimiz sınıfı vermemizi sağlıyor
    public interface ICategoryDal:IEntityRepository<Category>
    {

    }
}
