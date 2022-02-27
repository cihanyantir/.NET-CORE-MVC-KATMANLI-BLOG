using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {

        private readonly IBlogService _Service;
        readonly Context c = new Context();

        public Statistic1(IBlogService service)
        {
            _Service = service;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _Service.GetList().Count(); // ViewBag using on the main page
                                                     // /Staticstic/Default.cshtml
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();
            string apikey = "d957fb7dcd984d06b79395d9d47d37b6";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+apikey;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                    return View();
        }
    }
}
