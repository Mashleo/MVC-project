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
        public static List<Car> CarsDB = new List<Car>()
            {
            new Car { carBrand = "Audi", model = "A6", fuel = "Gas" }
            //    new Car { carBrand = "VW", model = "T4", fuel = "Gas" },
            //    new Car { carBrand = "BMW", model = "E34", fuel = "Diesel" },
            //    new Car { carBrand = "Audi", model = "A4", fuel = "Gas" }
        };
       
        //public CarsController(ICars iCars)
        //{
        //    _iCars = iCars;
        //}

        public IActionResult AllCar()
        {
            ViewData["Data"] = DateTime.Now;
        

            return View(CarsDB);
        }
        //POST
        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            ViewData["Data"] = DateTime.Now;
            CarsDB.Add(car);
            return View("AllCar", CarsDB);
        }
       

    }
}
