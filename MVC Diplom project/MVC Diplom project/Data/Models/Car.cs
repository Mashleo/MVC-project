using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string СarBrand { get; set; }
        public string Model { get; set; }
        public string Fuel { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public List<Logbook> LogbooksList { get; set; }
        public Car()
        {
            LogbooksList = new List<Logbook>();

        }
    }
}
