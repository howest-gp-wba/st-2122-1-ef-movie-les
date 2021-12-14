using Labo.H05.RateAMovie.Core.Entities;
using Labo.H05.RateAMovie.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labo.H05.RateAMovie.Web.Services
{
    public class DirectorServiceHardcoded : IDirectorService
    {
        public static List<Director> directors = new()
        {
            new Director() { Id = 1, LastName = "Spielberg", FirstName = "Steven" },
            new Director() { Id = 2, LastName = "Verheyen", FirstName = "Jan" },
            new Director() { Id = 3, LastName = "Coninckx", FirstName = "Stijn" },
        };

        public Task<DirectorIndexViewModel> List()
        {

            DirectorIndexViewModel directorsIndexViewModel = new()
            {
                Directors = directors
                    .OrderBy(d => d.LastName).ThenBy(d => d.FirstName)
                    .Select(d => new DirectorDetailsViewModel
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName
                    }).ToList(),
            };
            directorsIndexViewModel.DirectorsCount = directorsIndexViewModel.Directors.Count;

            return Task.FromResult(directorsIndexViewModel);
        }

        public Task<DirectorDetailsViewModel> Details(int id)
        {
            return Task.FromResult(directors
                            .Where(d => d.Id == id)
                            .Select(d => new DirectorDetailsViewModel
                            {
                                Id = d.Id,
                                FirstName = d.FirstName,
                                LastName = d.LastName
                            }).FirstOrDefault());
        }

        public Task Update(Director director)
        {
            Director d = directors.First(d => d.Id == director.Id);
            d.FirstName = director.FirstName;
            d.LastName = director.LastName;
            return Task.CompletedTask;
        }

        public async Task Add(Director director)
        {
            director.Id = directors.Count > 0 ? directors.Max(d => d.Id) + 1 : 1;
            directors.Add(director);
        }

        public async Task Delete(int id)
        {
            directors.Remove(directors.SingleOrDefault(d => d.Id == id));
        }

        public async Task Save(DirectorDetailsViewModel directorsDetailViewModel)
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
    }
}
