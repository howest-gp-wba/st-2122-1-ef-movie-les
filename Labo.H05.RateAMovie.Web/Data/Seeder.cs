using Labo.H05.RateAMovie.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labo.H05.RateAMovie.Web.Data
{
    public class Seeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company {  Id = 1, Name = "The Wachowski Brothers" },
                new Company {  Id = 2, Name = "Newline Cinema"}
                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, CompanyId = 1, Title = "The Matrix"},
                new Movie { Id = 2, CompanyId = 2, Title = "The fellowship of the ring" }
                );

            modelBuilder.Entity<Director>().HasData(
                new Director { Id = 1, FirstName = "Lana", LastName = "Wachowski" },
                new Director { Id = 2, FirstName = "Lilly", LastName = "Wachowski" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Jef", Username = "jef" },
                new User { Id = 2, FirstName = "Pol", Username = "pol" }
                );

            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Keanu", LastName = "Reeves"},
                new Actor { Id = 2, FirstName = "Laurence", LastName = "Fishburne" },
                new Actor { Id = 3, FirstName = "Carrie-Anne", LastName = "Moss" },
                new Actor { Id = 4, FirstName = "Sean", LastName = "Bean" }
                );

            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, UserId = 1, MovieId = 1, Score = 3, Review="I think this movie is ok!" },
                new Rating { Id = 2, UserId = 1, MovieId = 2, Score = 4, Review = "I think this movie is superb!" }
                );



        }
    }
}
