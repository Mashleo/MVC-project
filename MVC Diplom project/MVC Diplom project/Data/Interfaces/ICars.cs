using MVC_Diplom_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Interfaces
{
    public interface ICars
    {
        List<Car> AllCarrs { get; }
        Car AddCar();
    }
}
