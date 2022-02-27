using BusinessLayer.Concrete;
using BusinessLayer.Validation_Rules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        
        [HttpGet] //when page load
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p) //while u press
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
            if(results.IsValid)
            { 
                p.WriterStatus = true;
            p.WriterAbout = "Deneme Test";
            wm.TAdd(p); 
            return RedirectToAction("Index", "Blog");

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
    }
}
