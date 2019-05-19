using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VolvoTrucks.Repository.Model;
using System.Linq;

namespace VolvoTrucks.Data.Context
{
    public class VolvoContext : DbContext
    {
        public VolvoContext(DbContextOptions<VolvoContext> options)
            : base(options)
        { }

        public DbSet<Truck> Truck { get; set; }
        public DbSet<TruckModel> TruckModel { get; set; }

    }
    public static class ContextExtensions
    {
        public static void SeedData(this VolvoContext context)
        {

            if (!context.TruckModel.Any())
            {

                var models = new List<TruckModel>();
                var truckFH = new TruckModel
                {
                    Name = "FH"
                };
                models.Add(truckFH);
                var truckFM = new TruckModel
                {
                    Name = "FM"
                };
                models.Add(truckFM);

                context.TruckModel.AddRange(models);
                context.SaveChanges();
            }
            if (!context.Truck.Any())
            {
                var trucks = new List<Truck>();
                var truckFH = new Truck
                {
                    ManufactureYear = DateTime.Now.Year,
                    ModelYear = DateTime.Now.Year + 1,
                    TruckModelId = context.TruckModel.FirstOrDefault().Id,

                };
                trucks.Add(truckFH);
                var truckFM = new Truck
                {
                    ManufactureYear = DateTime.Now.Year,
                    ModelYear = DateTime.Now.Year,
                    TruckModelId = context.TruckModel.LastOrDefault().Id,

                };
                trucks.Add(truckFM);

                context.Truck.AddRange(trucks);
                context.SaveChanges();
            }
        }
    }
}
