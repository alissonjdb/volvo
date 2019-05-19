using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VolvoTrucks.Repository.Model
{
    public class TruckModel
    {
        public int Id { get; set; }
        [Display(Name = "Model")]
        public string Name { get; set; }

    }
}
