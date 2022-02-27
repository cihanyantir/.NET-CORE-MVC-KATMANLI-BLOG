using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{

    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            WriterManager wm=new WriterManager(new EfWriterRepository());
            Context c = new Context();
            var usermail = User.Identity.Name;
            int value = wm.GetWriterID(usermail);
            ViewBag.v4 = value;
            ViewBag.v1 = c.Blogs.Count().ToString(); //Need refactoring
            ViewBag.v2 = c.Blogs.Count(x => x.WriterID == 1).ToString();
            ViewBag.v3 = c.Categories.Count().ToString();
            return View();
        }
    }
}
