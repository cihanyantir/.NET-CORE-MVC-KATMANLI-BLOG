using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//IGenericDal oluşturuldu, GenericRepository IGenericdal tarafından,
//EfCategory repository GenericRepository<Category>,ICategoryDal tarafından
//CategoryManager ICategoryService tarafından implemente edildi.
//EfCategoryRepositoryden üretilen nesneyle metodlar çağırıldı.
namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService //GenericRepository imzalı implementasyonu
    {
    
        //EfCategoryRepository efCategoryRepository;

        //public CategoryManager()
        //{
        //    efCategoryRepository = new EfCategoryRepository();
        //}


        ICategoryDal _categoryDal;

       

        public CategoryManager(ICategoryDal categoryDal) 
            //interface reference,  ICategoryDal tarafından implemente edilen referance ile çağrılabilir.
            //Yani newlediğinde ICategorydal tarafından implemente edilen Ef yada başka platformu çağırabilirsin.
        {
            _categoryDal = categoryDal;
        }

        //public void CategoryAdd(Category category)
        //{
        //    _categoryDal.Insert(category);
        //}

        //public void CategoryDelete(Category category)
        //{
        //    _categoryDal.Delete(category);
        //}

        //public void CategoryUpdate(Category category)
        //{
        //    _categoryDal.Update(category);
        //}

        public Category GetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
           _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
