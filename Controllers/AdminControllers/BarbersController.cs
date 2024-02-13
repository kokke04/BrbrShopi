using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberShop.Models;
using BarberShop.Services;
using BarberShop.DtoModels;

namespace BarberShop.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BarbersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Barbers
        [HttpGet]
        public IActionResult GetBarbers()
        {
          if (_context.Barbers == null)
          {
              return NotFound();
          }

            var barbers = _context.Barbers; 

            return Ok(barbers);
        }

        // GET: api/Barbers/5
        [HttpGet("{id}")]
        public  IActionResult GetBarber(int id)
        {
          if (_context.Barbers == null)
          {
              return NotFound();
          }
            var barber = _context.Barbers.Find(id);

            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        // PUT: api/Barbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBarber(int id, BarberDto barber)
        {
            
            var b = _context.Barbers.FirstOrDefault(c => c.BarberId == id);
            if (b == null)
            {
                return NotFound();
            }

            b.Name = barber.Name;

            return Ok(b);

        }

        // POST: api/Barbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostBarber(BarberDto barber)
        {

            Barber b = new Barber
            { Name = barber.Name };


            _context.Barbers.Add(b);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/Barbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarber(int id)
        {
            if (_context.Barbers == null)
            {
                return NotFound();
            }
            var barber = await _context.Barbers.FindAsync(id);
            if (barber == null)
            {
                return NotFound();
            }

            _context.Barbers.Remove(barber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
