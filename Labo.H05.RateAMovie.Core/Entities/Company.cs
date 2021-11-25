using System.ComponentModel.DataAnnotations;

namespace Labo.H05.RateAMovie.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
