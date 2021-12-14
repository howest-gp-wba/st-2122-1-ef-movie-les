using Labo.H05.RateAMovie.Core.Entities;
using Labo.H05.RateAMovie.Web.Data;
using Labo.H05.RateAMovie.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labo.H05.RateAMovie.Web.Extensions;

namespace Labo.H05.RateAMovie.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _movieContext;
        public MoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IActionResult Index()
        {
            // extensive way using loop
            // con: more code, include needed in Linq-query
            // adv: you can count movies on-the-fly: no 2nd dbquery
            //var movies = _movieContext.Movies.Include(m => m.Company);
            //MoviesIndexViewModel moviesIndexViewModel = new();
            //moviesIndexViewModel.Movies = new List<MoviesBasicViewModel>();
            //foreach (var movie in movies) {          
            //    MoviesBasicViewModel moviesBasicViewModel = new()
            //    {
            //        Id = movie.Id,
            //        Title = movie.Title,
            //        Company = movie.Company.Name
            //    };
            //    moviesIndexViewModel.Movies.Add(moviesBasicViewModel);
            //}
            //moviesIndexViewModel.MoviesCount = movies.Count();

            // compact way
            MovieIndexViewModel moviesIndexViewModel = new()
            {
                Movies = _movieContext.Movies.OrderBy(m => m.Title)
                .Select(m => new MovieBasicViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Company = m.Company.Name
                }).ToList(),
                MoviesCount = _movieContext.Movies.Count()
            };
            return View(moviesIndexViewModel);
        }

        public IActionResult Details(int id)
        {

            return View(LoadDetails(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            return View(LoadEditDetails(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieDetailsViewModel movieDetailsViewModel)
        {
            return await Save(movieDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            MovieDetailsViewModel movieDetailViewModel = new();
            movieDetailViewModel.Company = new CompanyDetailsViewModel();
            movieDetailViewModel.Actors = new List<ActorDetailsViewModel>();
            movieDetailViewModel.Directors = new List<DirectorDetailsViewModel>();


            LoadEditDetails(movieDetailViewModel);
            return View("Edit", movieDetailViewModel);
        }

        private async Task<IActionResult> Save(MovieDetailsViewModel movieDetailsViewModel)
        {
            // Remove modelstate erros for Directors and Actors, only id's are received, no names ...
            // Cleaner solution: don't reuse ViewModels
            ModelState.Remove_StartsWith("Directors");
            ModelState.Remove_StartsWith("Actors");

            if (!ModelState.IsValid)
            {
                // reloading movie EditDetails (pick lists for companies, actors and directors)
                // warning: changes in actors or directorslist will be lost
                // could be resolved by first mapping List<int> ActorsSelected to Actors and DirectorsSelected to Directors
                movieDetailsViewModel = LoadEditDetails(movieDetailsViewModel.Id);
                return View("Edit", movieDetailsViewModel);
            }

            var movie = new Movie
            {
                Actors = new List<Actor>(),
                Directors = new List<Director>()
            };

            if (movieDetailsViewModel.Id != 0)
            {
                movie = _movieContext.Movies
                        .Include(m => m.Actors)
                        .Include(m => m.Directors)
                        .Single(m => m.Id == movieDetailsViewModel.Id);
            }

            movie.Id = movieDetailsViewModel.Id;
            movie.Title = movieDetailsViewModel.Title;
            movie.ReleaseDate = movieDetailsViewModel.ReleaseDate;
            movie.CompanyId = movieDetailsViewModel.Company.Id;

            // Empty Actorlist for movie, add actors based on ActorsSelected
            movie.Actors.Clear();
            if (movieDetailsViewModel.Actors != null)
            {
                foreach (ActorDetailsViewModel actor in movieDetailsViewModel.Actors.Where(a => a.Selected))
                {
                    movie.Actors.Add(_movieContext.Actors.Find(actor.Id));
                }
            }

            // Empty Directorlist for movie, add directors based on DirectorsSelected
            movie.Directors.Clear();
            if (movieDetailsViewModel.Directors != null)
            {
                foreach (DirectorDetailsViewModel director in movieDetailsViewModel.Directors.Where(d => d.Selected))
                {
                    movie.Directors.Add(_movieContext.Directors.Find(director.Id));
                }
            }

            if (movieDetailsViewModel.Id == 0)
            {
                _movieContext.Movies.Add(movie);
            }
            else
            {
                _movieContext.Movies.Update(movie);
            }
            await _movieContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private MovieDetailsViewModel LoadDetails(int id)
        {
            var movies = _movieContext.Movies
                .Where(m => m.Id == id)
                .Select(m => new MovieDetailsViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    ReleaseDate = m.ReleaseDate,
                    Company = new CompanyDetailsViewModel
                    {
                        Id = m.CompanyId,
                        Name = m.Company.Name
                    },
                    Directors = m.Directors.Select(d => new DirectorDetailsViewModel
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        Selected = true
                    }).ToList(),
                    Actors = m.Actors.Select(d => new ActorDetailsViewModel
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        Selected = true
                    }).ToList(),
                    Ratings = m.Ratings.Select(r => new RatingDetailsViewModel
                    {
                        Id = r.Id,
                        Score = r.Score,
                        Review = r.Review,
                        UserName = $"{r.User.FirstName} {r.User.LastName}",
                    }).ToList(),
                })
                .FirstOrDefault();
            return movies;

        }

        private MovieDetailsViewModel LoadEditDetails(int id)
        {
            var movies = LoadDetails(id);
            LoadEditDetails(movies);

            return movies;
        }

        private void LoadEditDetails(MovieDetailsViewModel movies)
        {
            movies.Company.Companies = _movieContext.Companies
                                .OrderBy(c => c.Name)
                                .Select(c => new SelectListItem
                                {
                                    Value = c.Id.ToString(),
                                    Text = c.Name,
                                    Selected = movies.Company.Id == c.Id
                                }).ToList();

            movies.Actors = _movieContext.Actors
                    .OrderBy(a => a.LastName).ThenBy(a => a.FirstName)
                    .Select(a => new ActorDetailsViewModel
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Selected = movies.Actors.Select(x => x.Id).Contains(a.Id)
                    }).ToList();


            movies.Directors = _movieContext.Directors
                    .OrderBy(d => d.LastName).ThenBy(d => d.FirstName)
                    .Select(d => new DirectorDetailsViewModel
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        Selected = movies.Directors.Select(x => x.Id).Contains(d.Id)
                    }).ToList();
        }

        [HttpGet]
        public IActionResult DeleteConfirmation(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _movieContext.Movies.Remove(new Movie { Id = id });
            _movieContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
