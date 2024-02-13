using System;
using System.Collections.Generic;

namespace BarberShop.Models;

public partial class Barber
{
    public int BarberId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
