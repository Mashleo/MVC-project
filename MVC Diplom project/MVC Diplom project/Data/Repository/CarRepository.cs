using Microsoft.EntityFrameworkCore;
using MVC_Diplom_project.Controllers;
using MVC_Diplom_project.Data.Interfaces;
using MVC_Diplom_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Repository
{
    public class CarRepository : ICarsRepository
    {
        private readonly CarPortalDBContext _appDBContext;
        public CarRepository(CarPortalDBContext appDBContent)
        {
            this._appDBContext = appDBContent;

        }
       
       
        public void AddCar(Car car, string name)
        {
            User user = _appDBContext.Users.Include(x => x.CarsList).FirstOrDefault(u => u.UserName ==name);
            car.UserId = user.ID;
           
         
            _appDBContext.Cars.Add(car);
            _appDBContext.SaveChanges();
        }

        public  List<Car> AllCarrs()
        {

            return _appDBContext.Cars.ToList();
        }
       
    }
   
}
