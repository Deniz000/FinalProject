using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //ıentitity.. yani sql cümleleri barındırıyor
    public interface IOrderDal:IEntityRepository<Order>
    {

    }
}
