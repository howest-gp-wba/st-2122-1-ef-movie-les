using Labo.H05.RateAMovie.Core.Entities;
using Labo.H05.RateAMovie.Web.Data;
using Labo.H05.RateAMovie.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Labo.H05.RateAMovie.Web.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly MovieContext _movieContext;
        public DirectorsController(MovieContext moviecontext)
        {
            _movieContext = moviecontext;
        }

        public IActionResult Index()
        {
            DirectorsIndexViewModel directorsIndexViewModel = new()
            {
                Directors = _movieContext.Directors
                    .OrderBy(d => d.LastName).ThenBy(d => d.FirstName)
                    .Select(d => new DirectorsDetailViewModel
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName
                    }).ToList(),
                //DirectorsCount = _movieContext.Directors.Count()
            };
            directorsIndexViewModel.DirectorsCount = directorsIndexViewModel.Directors.Count;
            return View(directorsIndexViewModel);
        }

        public IActionResult Edit(int id)
        {
            var director = _movieContext.Directors.FirstOrDefault(d => d.Id == id);
            DirectorsDetailViewModel directorsDetailViewModel = new DirectorsDetailViewModel
            {
                Id = director.Id,
                FirstName = director.FirstName,
                LastName = director.LastName
            };
            return View(directorsDetailViewModel);
        }
    }
}
