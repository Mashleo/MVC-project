using Microsoft.AspNetCore.Mvc;
using MVC_Diplom_project.Data.Interfaces;
using MVC_Diplom_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICars _iCars;
        public CarsController(ICars iCars)
        {
            _iCars = iCars;
        }
        
        public ViewResult AllCar()
        {
            var allCarsInMockClass = _iCars.AllCarrs;
            
            return View(allCarsInMockClass);
        }
       
        
        public ActionResult Add()
        {
            
            return View(_iCars.AddCar());
        }
    }
}
