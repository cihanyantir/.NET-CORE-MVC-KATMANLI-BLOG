using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProfileImageModell //here was in Model folder but Fluent Validation
                                    //doesnt accept a class in Model folder.
    {
        public int WriterID { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterAbout { get; set; }
        public string WriterName { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
