using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class Category : Controller
    {
        //ICategoryDal' tarafından implemente edilen classlar Manager'daki field ile referans gösterilerek çağrılabiliyor.
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        
        //ActionResult on mvc
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
