using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VolvoTrucks.Repository.Model;

namespace VolvoTrucks.Domain.Contract
{
    public interface ITruckBusiness
    {
        Task<Truck> GetById(int id);
        Task<List<Truck>> Getall();
        List<TruckModel> GetAllModels();
        Task Save(Truck truck);
        Task Update(Truck truck);
        Task Delete(Truck truck);
        bool Exists(int id);
    }
}
