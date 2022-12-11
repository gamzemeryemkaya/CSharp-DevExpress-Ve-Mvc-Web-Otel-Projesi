using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmsApiProject.Models.PropertyModels
{
    public class SpecificDateLiter
    {
          public int AnimalIdentificationNo { get; set; }
        public string AnimalName { get; set; }
        public DateTime Date { get; set; }
        public int TotalSpecificDateLiter { get; set; }
    }
}
