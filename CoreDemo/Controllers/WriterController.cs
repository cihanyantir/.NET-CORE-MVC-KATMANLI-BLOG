using BusinessLayer.Concrete;
using BusinessLayer.Validation_Rules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    { WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writername = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writername;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult PartialNavBar() //PartialViewResult ..... zaten actionsuz döndürüyor, need exact data.
        {
            return View(); //PartialView
        }
    
        //[HttpGet]
        //public IActionResult WriterEditProfile()
        //{ var usermail = User.Identity.Name;
        //    var value = wm.GetWriterID(usermail);
        //    var values = wm.GetById(value);
        //    return View(values);
        //}
  
        //[HttpPost]
        //public IActionResult WriterEditProfile(Writer p)
        //{
        //    WriterValidator wl = new WriterValidator();
        //    ValidationResult results = wl.Validate(p);
        //    if (results.IsValid)
        //    {
        //        wm.TUpdate(p);
        //        return RedirectToAction("Index", "DashBoard");
        //    }
        //    else
        //    {
        //        foreach (var item in results.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

        //        }
        //    }
        //    return View();
        //}

   
        [HttpGet]
        public IActionResult WriterEditProfileWithImage()
        {
            var usermail = User.Identity.Name;
            var value = wm.GetWriterID(usermail);
            var values = wm.GetById(value);
            return View(values);
        }
       
        [HttpPost]
        public IActionResult WriterEditProfileWithImage(ProfileImageModell p) //do 
        {
            ProfileImageModelValidator wl = new ProfileImageModelValidator();
            ValidationResult results = wl.Validate(p);
            if (results.IsValid)
            {
                Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;

            }
            w.WriterID = p.WriterID;
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TUpdate(w);
            return RedirectToAction("Index", "Dashboard");
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
