using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Vidly.Models;

namespace Vidly.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Seed MembershipTypes
            context.MembershipTypes.AddOrUpdate(
                m => m.Name,
                new MembershipType { Name = "Pay as You Go", SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0 },
                new MembershipType { Name = "Monthly", SignUpFee = 30, DurationInMonths = 1, DiscountRate = 10 },
                new MembershipType { Name = "Quarterly", SignUpFee = 90, DurationInMonths = 3, DiscountRate = 15 },
                new MembershipType { Name = "Annual", SignUpFee = 300, DurationInMonths = 12, DiscountRate = 20 }
            );

            // Seed Genres
            context.Genres.AddOrUpdate(
                g => g.Name,
                new Genre { Name = "Action" },
                new Genre { Name = "Comedy" },
                new Genre { Name = "Drama" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Romance" },
                new Genre { Name = "Thriller" }
            );

            context.SaveChanges();

            // Seed Movies
            context.Movies.AddOrUpdate(
                m => m.Name,
                new Movie
                {
                    Name = "The Matrix",
                    GenreId = context.Genres.Single(g => g.Name == "Action").Id,
                    ReleaseDate = new DateTime(1999, 3, 31),
                    DateAdded = DateTime.Now,
                    NumberInStock = 5
                },
                new Movie
                {
                    Name = "The Hangover",
                    GenreId = context.Genres.Single(g => g.Name == "Comedy").Id,
                    ReleaseDate = new DateTime(2009, 6, 5),
                    DateAdded = DateTime.Now,
                    NumberInStock = 3
                },
                new Movie
                {
                    Name = "The Dark Knight",
                    GenreId = context.Genres.Single(g => g.Name == "Action").Id,
                    ReleaseDate = new DateTime(2008, 7, 18),
                    DateAdded = DateTime.Now,
                    NumberInStock = 7
                },
                new Movie
                {
                    Name = "The Notebook",
                    GenreId = context.Genres.Single(g => g.Name == "Romance").Id,
                    ReleaseDate = new DateTime(2004, 6, 25),
                    DateAdded = DateTime.Now,
                    NumberInStock = 4
                },
                new Movie
                {
                    Name = "The Shining",
                    GenreId = context.Genres.Single(g => g.Name == "Horror").Id,
                    ReleaseDate = new DateTime(1980, 5, 23),
                    DateAdded = DateTime.Now,
                    NumberInStock = 2
                }
            );

            // Seed Customers
            context.Customers.AddOrUpdate(
                c => c.Name,
                new Customer
                {
                    Name = "John Smith",
                    IsSubscribedToNewsletter = false,
                    MembershipTypeId = context.MembershipTypes.Single(m => m.Name == "Pay as You Go").Id,
                    Birthdate = new DateTime(1980, 1, 1)
                },
                new Customer
                {
                    Name = "Mary Williams",
                    IsSubscribedToNewsletter = true,
                    MembershipTypeId = context.MembershipTypes.Single(m => m.Name == "Monthly").Id,
                    Birthdate = new DateTime(1990, 5, 15)
                },
                new Customer
                {
                    Name = "Robert Johnson",
                    IsSubscribedToNewsletter = false,
                    MembershipTypeId = context.MembershipTypes.Single(m => m.Name == "Quarterly").Id,
                    Birthdate = new DateTime(1975, 8, 20)
                },
                new Customer
                {
                    Name = "Sarah Davis",
                    IsSubscribedToNewsletter = true,
                    MembershipTypeId = context.MembershipTypes.Single(m => m.Name == "Annual").Id,
                    Birthdate = new DateTime(1995, 12, 10)
                }
            );

            context.SaveChanges();
        }
    }
}
