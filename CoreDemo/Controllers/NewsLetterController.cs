using BusinessLayer.Concrete;
using BusinessLayer.Validation_Rules;
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
{ [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager( new EfNewsLetterRepository());
        
        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter p) //SosyalTesisController HttpDelete Bakılacak. ofr.json
        {
            NewsLetterValidator bv = new NewsLetterValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.MailStatus = true;
                nm.AddNewsLetter(p);
                return PartialView();
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
