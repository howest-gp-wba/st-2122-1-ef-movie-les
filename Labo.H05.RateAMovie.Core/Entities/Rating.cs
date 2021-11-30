using System;
using System.ComponentModel.DataAnnotations;

namespace Labo.H05.RateAMovie.Core.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        [Range(1,5)]
        public int Score { get; set; }

        public string Review { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
