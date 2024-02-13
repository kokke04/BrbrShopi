using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BarberShop.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int? BarberId { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public string? Comments { get; set; }

    [JsonIgnore]
    public virtual Barber? Barber { get; set; }
}
