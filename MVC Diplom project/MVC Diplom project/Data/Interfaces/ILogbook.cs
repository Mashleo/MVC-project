using MVC_Diplom_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data.Interfaces
{
   public interface ILogbook
    {
        List<Logbook> AllLogbokThisCar();
        void AddLog( Logbook logbook, string name);
    }
}
