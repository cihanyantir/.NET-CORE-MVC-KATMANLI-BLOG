using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.DataAccessLayer
{
    public class Employee
    { [Key]
        public int ID { get; set; }
        public string Name   { get; set; }
    }

    //NEED WMIndex Like ParkProject cause Listing on Index needs a Model.
}
