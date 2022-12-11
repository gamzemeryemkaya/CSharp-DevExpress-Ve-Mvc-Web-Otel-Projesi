using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmsApiProject.Models.PropertyModels
{
    public class GetAnimalTypeInfo
    {
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public int AnimalIdentificationNo { get; set; }
    }
}
