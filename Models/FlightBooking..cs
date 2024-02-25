using System;
using System.ComponentModel.DataAnnotations;

namespace GBC_Travel_Group_76.Models
{
    public class Booking
    {
        [Key]
        public int PassengerId { get; set; }

        [Required]
        public string? PassengerName { get; set; }

        [Required]
        public int FlightId { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }       

    }
}
