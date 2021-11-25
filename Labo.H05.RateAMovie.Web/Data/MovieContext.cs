using Labo.H05.RateAMovie.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labo.H05.RateAMovie.Web.Data
{
    public class MovieContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options): base(options)
        {

        }
    }
}
