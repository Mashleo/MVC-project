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
        public static List<Car> CarsDB = new List<Car>();
        //= new List<Car>()
        //    {
        //    new Car { carBrand = "Audi", model = "A6", fuel = "Gas" },
        //        new Car { carBrand = "VW", model = "T4", fuel = "Gas" },
        //        new Car { carBrand = "BMW", model = "E34", fuel = "Diesel" },

        //}

        public List<Car> AllCarrs()
        {
            return CarsDB;
        }
        public void AddCar(Car car, string name)
        {
            CarsDB.Add(car);
        }










    }
}
