using System.ComponentModel.DataAnnotations;

namespace GBC_Travel_Group_76.Models
{
    public class HotelBooking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? GuestName { get; set; }
        [Required]
        public string? ContactPerson { get; set; }
        [Required]
        public string? NumberOfGuests { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
