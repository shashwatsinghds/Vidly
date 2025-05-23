﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
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
        // GET: Movies/Random
        public ActionResult Random()

        {
            var movie = new Movie() { Name = "Shrek!" }; // Anonymous Object
            var customers = new List<Customer>
            {
                new Customer {Name="Customer 1"},
                new Customer {Name="Customer 2"}

            };

            var viewModel = new RandomMovieViewModel();
            viewModel.Movie = movie;
            viewModel.Customers = customers;
            return View(viewModel);
            //return Content("Hello");
            //return HttpNotFound();
            //return RedirectToAction("Index", "Home", new {page=1, sortBy="name"});
        }
       

        public ActionResult Index()
        {
            
            var movieList = _context.Movies.Include(x => x.Genre).ToList();
          
            return View(movieList);
        }

        //movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue) 
        //    {
        //        pageIndex = 1;
        //    }
        //    if (String.IsNullOrEmpty(sortBy))
        //    {
        //        sortBy = "name"; 
        //    }

        //    return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        //}

        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }



        [Route("movies/lets")]
        public ActionResult Lets()
        {
            //return Content("lets-" + count.ToString());
            return View();
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).First(x=>x.Id == id);
            return View(movie);
        }


        public ActionResult New()
        {
            MovieFormViewModel movieFormObj = new MovieFormViewModel()
            {
                Genres = _context.Genres
            };
            return View("MovieForm",movieFormObj);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel();
                viewModel.Movie = movie;
                viewModel.Genres = _context.Genres;

                return View("MovieForm",viewModel);
            }
            
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Now;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new MovieFormViewModel() 
            {
                Genres = _context.Genres.ToList() ,
                Movie = _context.Movies.SingleOrDefault(m => m.Id == id)

            };
            return View("MovieForm", viewModel);
        }

    }
}