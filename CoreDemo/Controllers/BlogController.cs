using BusinessLayer.Concrete;
using BusinessLayer.Validation_Rules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;


using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        Context ctx = new Context();

 //       private readonly EfCategoryRepository _efCategoryRepository;
 //       private readonly EfBlogRepository _efBlogRepository;
 //       private readonly EfWriterRepository _efWriterRepository;



 //public BlogController(EfCategoryRepository efCategoryRepository, EfBlogRepository efBlogRepository, EfWriterRepository efWriterRepository)
 //       {
 //           _efCategoryRepository = efCategoryRepository;
 //           _efBlogRepository = efBlogRepository;
 //           _efWriterRepository = efWriterRepository;
 //       }

        

        CategoryManager cm = new CategoryManager(new EfCategoryRepository()); //dontneedifwe addservice
        BlogManager bm = new BlogManager(new EfBlogRepository());
        WriterManager wm = new WriterManager(new EfWriterRepository());


       
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id) //buraya getbyid'de yaz. 
        {
            ViewBag.i = id; //id to ViewComponent
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            int value = wm.GetWriterID(usermail);
            var values=bm.Test(value);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
          
            List<SelectListItem> categories = (from x in cm.GetList()
                                               select new SelectListItem
                                               { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.cv = categories;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                var usermail = User.Identity.Name;
                int value = wm.GetWriterID(usermail);
                p.WriterID = value;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");

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
        public IActionResult DeleteBlog(int id)
        { var blogvalue = bm.GetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");

        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {var valuess = bm.GetById(id);
            List<SelectListItem> categories = (from x in cm.GetList()
                                               select new SelectListItem
                                               { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.cv = categories;

            return View(valuess); }

        [HttpPost]
        public IActionResult EditBlog(Blog p)

     {
            p.WriterID = bm.UpdateBlogWithID(p).WriterID;
            p.CreateDate = bm.UpdateBlogWithID(p).CreateDate;
            bm.TUpdate(p);

            
           
            //var guncellenecekblog = ctx.Blogs.SingleOrDefault(x => x.BlogID == p.BlogID);
            //p.WriterID = 1;
            //await TryUpdateModelAsync(guncellenecekblog);
            
                return RedirectToAction("BlogListByWriter"); }
        
    }
}
