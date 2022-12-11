using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FarmsApiProject.Models
{
    public class Farm
    {
        [Key]
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name = "FarmID")] //  
        public int FarmID { get; set; }

        [DataMember(Name = "AnimalIdentificationNo")]
        public int AnimalIdentificationNo { get; set; }

        [DataMember(Name = "AnimalName")]
        public string? AnimalName { get; set; }

        [DataMember(Name = "MilkingID")]
        public int MilkingID { get; set; }

        [DataMember(Name = "MilkingTime")]
        public int MilkingTime { get; set; }

        [DataMember(Name = "Liter")]
        public int Liter { get; set; }

        [DataMember(Name = "AuthorizedPersonel")]
        public string? AuthorizedPersonel { get; set; }

        [DataMember(Name = "Date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "AnimalStatus")]
        public string? AnimalStatus { get; set; }

        [DataMember(Name = "AnimalType")]
        public string AnimalType { get; set; }
    }
}
