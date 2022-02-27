//using BusinessLayer.Concrete;
//using BusinessLayer.Validation_Rules;
//using DataAccessLayer.Concrete;
//using DataAccessLayer.Entity_Framework;
//using EntityLayer.Concrete;
//using FluentValidation.Results;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CoreDemo.ViewComponents.NewsLetterViewComponent
//{
//    public class NewsLetterPartial : ViewComponent
//    {
//        NewsLetterManager cm = new NewsLetterManager(new EfNewsLetterRepository());
//        //[HttpGet]
//        //public IViewComponentResult Invoke()
//        //{
//        //    return View();
//        //}
        
//        [HttpPost]
       
//        public async Task<IViewComponentResult> Invoke(NewsLetter p)
//        {
//            Context cnt = new Context();
//            cnt.Add(p);
//            await cnt.SaveChangesAsync();
     
//            //NewsLetterValidator bv = new NewsLetterValidator();
//            //ValidationResult results = bv.Validate(p);
//            //if (results.IsValid)
//            //{
//            ////    p.MailStatus = true;
//            //cm.AddNewsLetter(p);
//            //    return View();
//            //}
//            //else
//            //{
//            //    foreach (var item in results.Errors)
//            //    {
//            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

//            //    }
////            //}
////            return RedirectToAction
////        }

       
//    }
//}
