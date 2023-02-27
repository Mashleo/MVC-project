﻿using Microsoft.AspNetCore.Authorization;
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

     
        private readonly ICars _iCars;
        private readonly ILogbook _iLogbook;

        public CarsController(ICars iCars, ILogbook iLogbook, IDataProtectionProvider protectionProvider)
        {
            _iCars = iCars;
            _iLogbook = iLogbook;

        }
        [Authorize]
        public IActionResult AllCar()
        {
            
            return View(_iCars.AllCarrs());
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
            _iCars.AddCar(car, userAutorizeNmae);            
            return RedirectToAction(nameof(AllCar));
        }
        public IActionResult AddLogbook(Guid carId)
        {

            ViewBag.CarId = carId;
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddLogbook([FromForm]Logbook logbook, [FromQuery] Guid carId)
        {
            var userAutorizeNmae = User.Identity.Name;
           
            
            _iLogbook.AddLog(logbook, userAutorizeNmae);           
           
            return View();        
        }
        public IActionResult AllLogbook(Guid carId)
        {
            ViewBag.CarId = carId;
            return View(_iCars.AllCarrs());
        }

    }
}
