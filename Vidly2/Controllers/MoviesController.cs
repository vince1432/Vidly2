using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModel;
using Vidly2.Migrations;
using System.Data.Entity;
namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genre = _context.Genre.ToList( );

            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };

            return View("MovieForm",viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if ( movie == null)
            {
                return HttpNotFound();
            }
            var modelView = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genre.ToList()

            };
            return View("MovieForm",modelView);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    
                    Genres = _context.Genre.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDB.Name = movie.Name;
                movieInDB.RealeaseDate = movie.RealeaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.Stock = movie.Stock;
            }
            

            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        // GET: Movies
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };

            // var viewResult = new ViewResult();
            // viewResult.ViewData.Model;

            var customer = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customer
            };

            return View(viewModel);
        }

        public ActionResult Edit1(int id)
        {
            return Content("id =" + id);
        }

        public ActionResult Index1(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex= {0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}