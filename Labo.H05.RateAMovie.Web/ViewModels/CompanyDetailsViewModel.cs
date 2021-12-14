
// unused in MovieDetails - using SelectListItem

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labo.H05.RateAMovie.Web.ViewModels
{
    public class CompanyDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Company")]
        public string Name { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
    }
}
