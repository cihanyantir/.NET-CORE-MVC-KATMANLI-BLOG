using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category> //REFACTORING

        //**********************REFACTORING********************************/
    // public void Delete(T t) GenericRepository imzasına parametre yazılıyor
    {
        //void CategoryAdd(Category category);
        //void CategoryDelete(Category category);
        //void CategoryUpdate(Category category);
        //List<Category> GetList();
        //Category GetById(int id);
    }
}
