using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labo.H05.RateAMovie.Web.ViewModels
{
    public class MovieIndexViewModel
    {
        public List<MovieBasicViewModel> Movies { get; set; }
        
        [Display(Name = "Number of movies")]
        public int MoviesCount { get; set; }
    }
}
