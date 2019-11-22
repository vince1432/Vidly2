using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class NewRentalController : ApiController
    {

        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rental)
        {
            
            var customer = _context
                .Customers
                .Single(c => c.Id == rental.CustomerId);

            var movies = _context.Movies
                .Where( m => rental.MovieId.Contains(m.Id)).ToList();


            foreach (var movie in movies)
            {
                if (movie.Available == 0)
                    return BadRequest("not Available");

                movie.Available--;

                var rent = new Rental
                {
                    Customer = customer,
                    Movies = movie,
                    DateRented = DateTime.Now
                };

                _context.Rental.Add(rent);
            }

            _context.SaveChanges();

            return Ok();
        }
        
    }
}
