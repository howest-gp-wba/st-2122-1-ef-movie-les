﻿using System;
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

    }
}
