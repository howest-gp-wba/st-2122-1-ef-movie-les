using Labo.H05.RateAMovie.Web.Services;
using Labo.H05.RateAMovie.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Labo.H05.RateAMovie.Web.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly IDirectorService _directorService;
        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        public async Task<IActionResult> Index()
        {  
            return View(await _directorService.List());
        }

        public async Task<IActionResult> Details(int id)
        {
            return base.View(await LoadDetails(id));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Action = "Edit";
            return View(await LoadDetails(id));
        }

        public async Task<IActionResult> Add()
        {
            ViewBag.Action = "Add";    
            return View("Edit", await _directorService.New());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DirectorDetailsViewModel directorsDetailViewModel)
        {
            return await Save(directorsDetailViewModel);

        }

        public IActionResult DeleteConfirmation(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _directorService.Delete(id);
            return RedirectToAction("Index");
        }

        private async Task<IActionResult> Save(DirectorDetailsViewModel directorDetailsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", directorDetailsViewModel);
            }
            await _directorService.Save(directorDetailsViewModel);
            return RedirectToAction("Index");
        }

        private async Task<DirectorDetailsViewModel> LoadDetails(int id)
        {
            return await _directorService.Details(id);
        }
    }
}
