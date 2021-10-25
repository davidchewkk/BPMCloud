using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Controllers
{
    public class MovieController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private MovieContext context { get; set; }

        public MovieController(MovieContext ctx)
        {
            context = ctx;
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("Edit", new Movie());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var movie = context.Movie.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                    context.Movie.Add(movie);
                else
                    context.Movie.Update(movie);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.action = (movie.MovieId == 0) ? "Add" : "Edit";
                return View(movie);
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = context.Movie.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            context.Movie.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
