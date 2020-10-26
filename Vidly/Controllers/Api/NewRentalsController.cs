using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult CreateRental (NewRentalDTO newRental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //var customer = _context.Customers.Single(m=>m.Id == newRental.CustomerId).Select(Mapper.Map<Rental, NewRentalDTO>);/*.SingleOrDefault(c => c.Id == newRental.CustomerId).*/
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MoviesIds.Contains(m.Id)).ToList();

            foreach(var movie in movies)
            {
                if (movie.AvailableMovies == 0)
                    return BadRequest(string.Format("{0} is nos available to rent.",movie.Name));

                movie.AvailableMovies--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
