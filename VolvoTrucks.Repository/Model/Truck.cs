using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VolvoTrucks.Repository.Model
{
    public class Truck
    {
        public int Id { get; set; }

        [Display(Name = "Manufacture Year")]
        public int ManufactureYear { get; set; }

        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        [Display(Name = "Model")]
        public int TruckModelId { get; set; }

        [Display(Name = "Model")]
        public virtual TruckModel TruckModel { get; set; }
    }
}
