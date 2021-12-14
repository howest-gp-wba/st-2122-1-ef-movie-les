using Labo.H05.RateAMovie.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labo.H05.RateAMovie.Web.ViewModels
{
    public class MovieDetailsViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public ICollection<RatingDetailsViewModel> Ratings { get; set; }


        // Property for one-to-many relationship
        public CompanyDetailsViewModel Company { get; set; }

        // Properties for many-to-many relations
        // ViewModel contains a property "Selected"
        // List needed for View: for-loop (indexed)
        public List<ActorDetailsViewModel> Actors { get; set; }

        public List<DirectorDetailsViewModel> Directors { get; set; }

    }
}
