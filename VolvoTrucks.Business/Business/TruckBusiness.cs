using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoTrucks.Data.Context;
using VolvoTrucks.Domain.Contract;
using VolvoTrucks.Repository.Model;

namespace VolvoTrucks.Domain.Business
{
    public class TruckBusiness : ITruckBusiness
    {
        private VolvoContext _volvoContext;


        public TruckBusiness(VolvoContext volvoContext)
        {
            _volvoContext = volvoContext;
        }
        public async Task<Truck> GetById(int id)
        {
            return await _volvoContext.Truck.Include(x => x.TruckModel).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Truck>> Getall()
        {
            return await _volvoContext.Truck.Include(x => x.TruckModel).ToListAsync();
        }

        public List<TruckModel> GetAllModels()
        {
            return _volvoContext.TruckModel.ToList();
        }
        public async Task Save(Truck truck)
        {
            if (truck.ManufactureYear != DateTime.Now.Year)
                throw new IndexOutOfRangeException();

            if (truck.ModelYear != DateTime.Now.Year && truck.ModelYear != DateTime.Now.Year + 1)
                throw new IndexOutOfRangeException();

            _volvoContext.Add(truck);
            await _volvoContext.SaveChangesAsync();
        }

        public async Task Update(Truck truck)
        {
            if(truck.ManufactureYear != DateTime.Now.Year)
                throw new IndexOutOfRangeException();

            if (truck.ModelYear != DateTime.Now.Year && truck.ModelYear != DateTime.Now.Year + 1)
                throw new IndexOutOfRangeException();

            _volvoContext.Update(truck);
            await _volvoContext.SaveChangesAsync();
        }

        public async Task Delete(Truck truck)
        {
            _volvoContext.Truck.Remove(truck);
            await _volvoContext.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return  _volvoContext.Truck.Any(e => e.Id == id);
        }

    }
}
