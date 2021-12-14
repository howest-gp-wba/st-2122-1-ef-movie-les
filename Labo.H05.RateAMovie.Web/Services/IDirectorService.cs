using Labo.H05.RateAMovie.Core.Entities;
using Labo.H05.RateAMovie.Web.ViewModels;
using System.Threading.Tasks;

namespace Labo.H05.RateAMovie.Web.Services
{
    public interface IDirectorService
    {
        public Task<DirectorIndexViewModel> List();

        public Task<DirectorDetailsViewModel> Details(int id);

        public Task Update(Director director);

        public Task Add(Director director);

        public Task Save(DirectorDetailsViewModel directorsDetailViewModel);

        public Task Delete(int id);

        public Task<DirectorDetailsViewModel> New()
        {
            return Task.FromResult(new DirectorDetailsViewModel());
        }
    }
}
