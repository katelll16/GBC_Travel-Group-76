using System;
using System.ComponentModel.DataAnnotations;

namespace GBC_Travel_Group_76.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        public string Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

        public int Passengers { get; set; }
        public int SeatNumber { get; set; }

        public int Price { get; set; }
    }
}
