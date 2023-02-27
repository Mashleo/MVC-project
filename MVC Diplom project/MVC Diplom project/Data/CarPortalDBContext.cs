using Microsoft.EntityFrameworkCore;
using MVC_Diplom_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Diplom_project.Data
{
    public class CarPortalDBContext : DbContext
    {
        public CarPortalDBContext(DbContextOptions<CarPortalDBContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Logbook> Logbooks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne<User>()
                .WithMany(x => x.CarsList)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Logbook>()
                .HasOne<Car>()
                .WithMany(x => x.LogbooksList)
                .HasForeignKey(a => a.CarId);

        }



    }
}
