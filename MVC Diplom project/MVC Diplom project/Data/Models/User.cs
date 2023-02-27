using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Car> CarsList { get; set; }
        public User()
        {
            CarsList = new List<Car>();
        }

    }
}
