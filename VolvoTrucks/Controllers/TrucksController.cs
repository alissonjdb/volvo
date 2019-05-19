using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VolvoTrucks.Data.Context;
using VolvoTrucks.Domain.Contract;
using VolvoTrucks.Repository.Model;

namespace VolvoTrucks.Controllers
{
    public class TrucksController : Controller
    {
        private ITruckBusiness _truckBusiness;

        public TrucksController(ITruckBusiness truckBusiness)
        {
            _truckBusiness = truckBusiness;
        }

        // GET: Trucks
        public async Task<IActionResult> Index()
        {

            var volvo = _truckBusiness.Getall();
            return View(await volvo);
        }

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _truckBusiness.GetById(id.Value);

            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // GET: Trucks/Create
        public IActionResult Create()
        {
            ViewData["TruckModelId"] = new SelectList(_truckBusiness.GetAllModels(), "Id", "Name");
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManufactureYear,ModelYear,TruckModelId")] Truck truck)
        {
            if (truck.ManufactureYear != DateTime.Now.Year)
                ModelState.AddModelError("ManufactureYear", "Set a valid Manufacture Year!");

            if (truck.ModelYear != DateTime.Now.Year && truck.ModelYear != DateTime.Now.Year + 1)
                ModelState.AddModelError("ModelYear", "Set a valid Model Year!");

            if (ModelState.IsValid)
            {
                await _truckBusiness.Save(truck);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TruckModelId"] = new SelectList(_truckBusiness.GetAllModels(), "Id", "Name", truck.TruckModelId);
            return View(truck);
        }

        // GET: Trucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _truckBusiness.GetById(id.Value);
            if (truck == null)
            {
                return NotFound();
            }
            ViewData["TruckModelId"] = new SelectList(_truckBusiness.GetAllModels(), "Id", "Name", truck.TruckModelId);
            return View(truck);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufactureYear,ModelYear,TruckModelId")] Truck truck)
        {
            if (id != truck.Id)
            {
                return NotFound();
            }

            if(truck.ManufactureYear != DateTime.Now.Year)
                ModelState.AddModelError("ManufactureYear", "Set a valid Manufacture Year!");

            if (truck.ModelYear != DateTime.Now.Year && truck.ModelYear != DateTime.Now.Year + 1)
                ModelState.AddModelError("ModelYear", "Set a valid Model Year!");

            if (ModelState.IsValid)
            {
                try
                {
                    await _truckBusiness.Update(truck);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckExists(truck.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TruckModelId"] = new SelectList(_truckBusiness.GetAllModels(), "Id", "Name", truck.TruckModelId);
            return View(truck);
        }

        // GET: Trucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truck = await _truckBusiness.GetById(id.Value);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truck = await _truckBusiness.GetById(id);
            await _truckBusiness.Delete(truck);
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(int id)
        {
            return _truckBusiness.Exists(id);
        }
    }
}
