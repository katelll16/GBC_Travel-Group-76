using System;

namespace GBC_Travel_Group_76.Models
{
    public class CarRent
    {
        public int Id { get; set; }

        public string? Model { get; set; }
        public string? PickUpLocation { get; set; }
        public string? DropOffLocation { get; set; }
        public DateTime PickUpTime{ get; set; }
        public DateTime DropOffTime { get; set; }          
        public int Price { get; set; }
    }
}
