using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Models
{
    public class Car
    {
        public string carBrand { get; set; }
        public string model { get; set; }
        public string fuel { get; set; }
        public List<Logbooks> logbooks { get; set; }
    }
}
