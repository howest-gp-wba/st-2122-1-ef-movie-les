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
    }
}
