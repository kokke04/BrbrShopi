using BarberShop.Models;

namespace BarberShop.DtoModels
{
    public class ReservationDto
    {

        public string PhoneNumber { get; set; } = null!;

        public int? BarberId { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public string? Comments { get; set; }

      //public virtual BarberDto? Barber { get; set; }
    }
}
