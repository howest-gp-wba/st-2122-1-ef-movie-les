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
            var directors = _movieContext.Directors.ToList();
            DirectorsIndexViewModel directorsIndexViewModel = new();
            
            foreach(Director director in directors)
            {
                DirectorsDetailViewModel directorsDetailViewModel = new DirectorsDetailViewModel
                {
                    Id = director.Id,
                    FirstName = director.FirstName,
                    LastName = director.LastName
                };
                directorsIndexViewModel.Directors.Add(directorsDetailViewModel);
            }
            return View(directorsIndexViewModel);
        }
    }
}
