using BarberShop.DtoModels;
using BarberShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberShop.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationAdminController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ReservationAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ReservationAdminController>
        [HttpGet]
        public IActionResult GetReservations()
        {
            if (_context.Reservations == null)
            {
                return NotFound();
            }
            var res = _context.Reservations.Include(c => c.Barber);

            return Ok(res);
        }

        // GET api/<ReservationAdminController>/5
        [HttpGet("{id}")]
        public IActionResult  Get(int id)
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



        [HttpPut("{id}")]
        public IActionResult UpdateReservation(int id, ReservationDto reservDto)
        {

            var res = _context.Reservations.Include(c => c.Barber).FirstOrDefault(c => c.ReservationId == id);

            if (res == null)
            {
                return NotFound();
            }

            res.PhoneNumber = reservDto.PhoneNumber;
            res.BarberId= reservDto.BarberId;
            res.Date = reservDto.Date;
            res.Time = reservDto.Time;
            res.Comments= reservDto.Comments;
            //res.Barber= reservDto.Barber;


           
            _context.SaveChanges();
            return Ok(res);


        }


        // DELETE api/<ReservationAdminController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_context.Reservations == null)
            {
                return NotFound();
            }
            var res = _context.Reservations.Include(c => c.Barber).FirstOrDefault(c => c.ReservationId == id);
            if (res == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(res);
            _context.SaveChanges();

            return Ok(res);
        }
    }
}
