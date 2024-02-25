using GBC_Travel_Group_76.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GBC_Travel_Group_76.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Flight> Flight { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<CarRent> CarRent { get; set; }
        public DbSet<Hotel> Hotel{ get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }
    }
}
