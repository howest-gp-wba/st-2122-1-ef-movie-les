using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labo.H05.RateAMovie.Core.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Actor> Actors { get; set; }
        public ICollection<Director> Directors { get; set; }
    }
}
