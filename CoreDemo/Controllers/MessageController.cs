using BusinessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
      
        public IActionResult InBox()
        {
            int id = 2;

            var values = mm.GetInboxListByWriter(id);

            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {

            var valuess = mm.GetMessageByID(id);
            
       

            return View(valuess);
        }
    }
}
