using MVC_Diplom_project.Data.Interfaces;
using MVC_Diplom_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Mocks
{
    public class MockCars : ICars
    {
        
        public List<Car> AllCarrs
        {
            get
            {
                return new List<Car>
                {
                    new Car { carBrand = "Audi", model = "A6", fuel = "Gas" },
                    new Car { carBrand = "VW", model = "T4", fuel = "Gas" },
                    new Car { carBrand = "BMW", model = "E34", fuel = "Diesel" },
                    new Car { carBrand = "Audi", model = "A4", fuel = "Gas" }


                };
            }
        }

        public Car AddCar()
        {
            var car = new Car();
            return car;
        }
    }
}
