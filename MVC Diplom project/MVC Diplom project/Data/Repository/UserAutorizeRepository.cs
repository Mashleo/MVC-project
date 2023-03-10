using MVC_Diplom_project.Data.Interfaces;
using MVC_Diplom_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Repository
{
    public class UserAutorizeRepository : IUserAutorizeRepository
    {
        private readonly CarPortalDBContext _appDBContext;
        public UserAutorizeRepository(CarPortalDBContext appDBContent)
        {
            this._appDBContext = appDBContent;

        }

        public string NameUserWhoOwnerCars(Guid idCars)
        {
            Car car = _appDBContext.Cars.FirstOrDefault(a => a.Id == idCars);
            User user = _appDBContext.Users.FirstOrDefault(u => u.ID == car.UserId);
            return user.UserName;

        }

        public Guid UserWhoAuturize(string name)
        {
            User user = _appDBContext.Users.FirstOrDefault(u => u.UserName == name);

            return user.ID;
        }

    }
}
