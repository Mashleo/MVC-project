using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Models
{
    public class Logbook
    {
        public Guid LogbookId { get; set; }

        public string NameLog { get; set; }
        public string Text { get; set; }
        [ForeignKey("Car")]
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
