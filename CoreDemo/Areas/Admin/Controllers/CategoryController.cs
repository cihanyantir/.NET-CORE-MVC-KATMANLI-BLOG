using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Validation_Rules;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{[Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(int page=1)
        {
            var values = _categoryService.GetList().ToPagedList(page,3); //Valueyi 3'er 3'er sayfalara böl.
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                p.CategoryStatus = true;
              
               
                _categoryService.TAdd(p);
                return RedirectToAction("Index", "Category");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }


        
        public IActionResult CategoryDelete(int id)
        {
            var categoryvalue = _categoryService.GetById(id);
            _categoryService.TDelete(categoryvalue);
            return RedirectToAction("Index");

        }
    }
}
