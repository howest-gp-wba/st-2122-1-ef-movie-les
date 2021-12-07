using Labo.H05.RateAMovie.Core.Entities;
using Labo.H05.RateAMovie.Web.Data;
using Labo.H05.RateAMovie.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Details(int id)
        {
            return base.View(LoadDetails(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(LoadDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DirectorsDetailViewModel directorsDetailViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", directorsDetailViewModel);
            }

            Director director = new()
            {
                Id = directorsDetailViewModel.Id,
                FirstName = directorsDetailViewModel.FirstName,
                LastName = directorsDetailViewModel.LastName
            };

            _movieContext.Directors.Update(director);
            await _movieContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        private DirectorsDetailViewModel LoadDetails(int id)
        {
            return _movieContext.Directors
                            .Where(d => d.Id == id)
                            .Select(d => new DirectorsDetailViewModel
                            {
                                Id = d.Id,
                                FirstName = d.FirstName,
                                LastName = d.LastName
                            }).FirstOrDefault();
        }


    }
}
