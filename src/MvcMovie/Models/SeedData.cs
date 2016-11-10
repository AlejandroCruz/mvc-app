using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The Fountain",
                         ReleaseDate = DateTime.Parse("2006-09-4"),
                         Genre = "Sci-Fi",
                         Rating = "R",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "Excalibur",
                         ReleaseDate = DateTime.Parse("1981-04-10"),
                         Genre = "Fantasy",
                         Rating = "R",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "The Matrix",
                         ReleaseDate = DateTime.Parse("1999-03-31"),
                         Genre = "Sci-Fi",
                         Rating = "R",
                         Price = 9.99M
                     },

                   new Movie
                   {
                       Title = "The Last of The Mohicans",
                       ReleaseDate = DateTime.Parse("1992-09-25"),
                       Genre = "Historical Drama",
                       Rating = "R",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}