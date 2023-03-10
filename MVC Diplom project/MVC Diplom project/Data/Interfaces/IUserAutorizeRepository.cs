using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Interfaces
{
    public interface IUserAutorizeRepository
    {
        public Guid UserWhoAuturize(string name);
        public string NameUserWhoOwnerCars(Guid idCar);
    }
}
