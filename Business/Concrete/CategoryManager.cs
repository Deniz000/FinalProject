using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //category manager olarak veri erişim katmanına bağımlıyım ama bu bağ biraz zayıf, çünkü ben referans üzerinden
        //interface üzerinden bağımlıyım o yüzden sen dataaccess katmanında istediğin şeyleri yapabilirsin, kurallarıma uymak şartı ile
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal) //injection
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //iş kodları
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
