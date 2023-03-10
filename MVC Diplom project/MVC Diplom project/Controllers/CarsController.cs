using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MVC_Diplom_project.Data.Interfaces;
using MVC_Diplom_project.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Controllers
{
    public class CarsController : Controller
    {


        private readonly ICarsRepository _iCarsRepository;
        private readonly ILogbookRepositiry _iLogbookRepository;
        private readonly IUserAutorizeRepository _iUserAutorizeRepository;

        public CarsController(ICarsRepository iCars, ILogbookRepositiry iLogbook, IUserAutorizeRepository iUserAutorizeRepository)
        {
            _iCarsRepository = iCars;
            _iLogbookRepository = iLogbook;
            _iUserAutorizeRepository = iUserAutorizeRepository;

        }
        [Authorize]
        public IActionResult AllCar()
        {
            ViewBag.NameAutirizeUser = User.Identity.Name;
            ViewBag.IdUser =  _iUserAutorizeRepository.UserWhoAuturize(User.Identity.Name);
          
            return View(_iCarsRepository.AllCarrs());
        }
        [Authorize]
        public IActionResult AddCarView()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCarView(Car car)
        {
            var userAutorizeNmae = User.Identity.Name;
            _iCarsRepository.AddCar(car, userAutorizeNmae);
            return RedirectToAction(nameof(AllCar));
        }
       
        [Authorize]
        public IActionResult AddLogbook([FromRoute] Guid Id)
        {

            ViewBag.CarId = Id;
            return View();
        }

        [HttpPost("{carId:guid}")]
        [Authorize]
        public IActionResult AddLogbook([FromForm]Logbook logbook, [FromRoute] Guid carId)
        {
            var userAutorizeNmae = User.Identity.Name;
           
            
            _iLogbookRepository.AddLog(logbook, userAutorizeNmae, carId);           
           
            return View();        
        }
        [Authorize]
        public IActionResult AllLogbook([FromRoute] Guid Id)
        {
            ViewBag.CarId = Id;
            return View(_iLogbookRepository.AllLogbokThisCar(Id));
        }

    }
}
