namespace GBC_Travel_Group_76.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public decimal PricePerNight { get; set; }
        public int Rating { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public string? Description { get; set; }
    }
}
