using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labo.H05.RateAMovie.Web.ViewModels
{
    public class DirectorsIndexViewModel
    {
        public List<DirectorsDetailViewModel> Directors { get; set; } = new();
        
        [Display(Name = "Number of directors")]
        public int DirectorsCount { get; set; }
    }
}
