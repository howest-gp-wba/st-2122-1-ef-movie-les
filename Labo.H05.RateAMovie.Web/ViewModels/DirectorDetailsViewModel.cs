using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labo.H05.RateAMovie.Web.ViewModels
{
    public class DirectorDetailsViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Last name")]
        public string LastName { get; set; }

        public bool Selected { get; set; }
    }
}
