using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmsApiProject.Models.PropertyModels
{
    public class TotalDailyLiter
    {
        public string AnimalName { get; set; }
        public DateTime Date { get; set; }
        public int TotalDailyLiters { get; set; }
    }
}
