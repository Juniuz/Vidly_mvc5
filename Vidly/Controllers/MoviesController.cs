using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>
            { 
                new Movie { Name = "Shrek", Id = 1 },
                new Movie { Name = "Shrek 2", Id = 2 },
                new Movie { Name = "Lost - Season 1", Id = 3 },
            };

            return View(movies);
        }
    }
}