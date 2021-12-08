using Labo.H05.RateAMovie.Core.Entities;
using Labo.H05.RateAMovie.Web.Data;
using Labo.H05.RateAMovie.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Labo.H05.RateAMovie.Web.Services
{
    public class DirectorServiceEF : IDirectorService
    {
        private readonly MovieContext _movieContext;
        public DirectorServiceEF(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public Task<DirectorsIndexViewModel> List()
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

            return Task.FromResult(directorsIndexViewModel);
        }
        public Task<DirectorsDetailViewModel> Details(int id)
        {
            return Task.FromResult(_movieContext.Directors
                            .Where(d => d.Id == id)
                            .Select(d => new DirectorsDetailViewModel
                            {
                                Id = d.Id,
                                FirstName = d.FirstName,
                                LastName = d.LastName
                            }).FirstOrDefault());
        }


        public async Task Update(Director director)
        {
            _movieContext.Directors.Update(director);
            await _movieContext.SaveChangesAsync();
        }
        public async Task Add(Director director)
        {

            _movieContext.Directors.Add(director);
            await _movieContext.SaveChangesAsync();
        }

        public async Task Save(DirectorsDetailViewModel directorsDetailViewModel)
        {
            Director director = new()
            {
                Id = directorsDetailViewModel.Id,
                FirstName = directorsDetailViewModel.FirstName,
                LastName = directorsDetailViewModel.LastName
            };

            if (director.Id == 0)
            {
                await Add(director);
            }
            else
            {
                await Update(director);
            }
        }

        public async Task Delete(int id)
        {
            _movieContext.Directors.Remove(new Director { Id = id });
            await _movieContext.SaveChangesAsync();
        }
    }
}
