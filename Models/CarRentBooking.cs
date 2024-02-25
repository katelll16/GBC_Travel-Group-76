using System;
using System.ComponentModel.DataAnnotations;

namespace GBC_Travel_Group_76.Models
{
    public class CarRentBooking
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public int CarModel { get; set; }

        [Required]
        public DateTime PickUpTime { get; set; }
        public DateTime DropOffTime { get; set; }

    }
}
