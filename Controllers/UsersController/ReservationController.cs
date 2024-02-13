using BarberShop.DtoModels;
using BarberShop.Models;
using BarberShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberShop.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_context.Reservations == null)
            {
                return NotFound();
            }

            var res = _context.Reservations.FirstOrDefault(c => c.ReservationId == id);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);

        }

        // POST api/<ReservationController>
        [HttpPost]
        public IActionResult PostReservation( ReservationDto resDto)
        {
            if (_context.Barbers == null)
            {
                return Problem("There are no Barbers available");
            }

            Reservation res = new Reservation()
            {
                PhoneNumber = resDto.PhoneNumber,
                BarberId= resDto.BarberId,
                Date = resDto.Date,
                Time = resDto.Time,
                Comments = resDto.Comments
            };

            _context.Reservations.Add(res); 
            _context.SaveChanges();

            return Ok(res);
        }


        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            if (_context.Reservations == null)
            {
                return NotFound();
            }

            var res = _context.Reservations.Include(x => x.Barber.Reservations).FirstOrDefault(c => c.ReservationId == id);

            if (res == null) { return NotFound(); }

            _context.Reservations.Remove(res);
            _context.SaveChanges();
            return Ok(res);

        }
    }
}
