using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmsApiProject.Models.PropertyModels
{
    public class WeeklyTotalLiter
    {
        public int WeeklyTotalLiterByAnimal { get; set; }
        public string AnimalName { get; set; }
        public string AnimalStatus { get; set; }
        public DateTime Date { get; set; }
    }
}
