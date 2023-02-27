using MVC_Diplom_project.Data.Interfaces;
using MVC_Diplom_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace MVC_Diplom_project.Data.Repository
{
    public class LogbooksRepository : ILogbook
    {
        private readonly CarPortalDBContext _appDBContext;
        public LogbooksRepository(CarPortalDBContext appDBContent)
        {
            this._appDBContext = appDBContent;

        }
        public void AddLog( Logbook logbook, string name)
        {
          
            
            User user = _appDBContext.Users.FirstOrDefault(u => u.UserName == name);
            Car car = _appDBContext.Cars.FirstOrDefault(u => u.UserId == user.ID);
          
                _appDBContext.Logbooks.Add(logbook);
           
           


        }

        public List<Logbook> AllLogbokThisCar()
        {
            return _appDBContext.Logbooks.ToList();
        }
    }
}
