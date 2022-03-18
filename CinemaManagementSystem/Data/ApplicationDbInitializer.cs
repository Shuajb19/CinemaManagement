using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using CinemaManagementSystem.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagementSystem.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "https://i.guim.co.uk/img/media/c86566efe952a725ed31c29834c245653dd7ef19/0_97_3363_2018/master/3363.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=0fe825d80a347f5287afe6fc17b54314"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Spider-Man: No Way Home",
                            Description = "This is the Spider-Man: No Way Home description",
                            Price = 39.50,
                            ImageURL = "https://www.themoviedb.org/t/p/original/9lnlNvYzQ5FnbZLXzYaYHyRCFWO.jpg",
                            TrailerURL = "https://www.youtube.com/embed/JfVOs4VSpmA",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now,
                            CinemaId = 3,
                            ProducerId = 3,
                            CategoryId = 2
                        },
                        new Movie()
                        {
                            Name = "The Batman",
                            Description = "This is the 'The Batman' description",
                            Price = 29.50,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BOGE2NWUwMDItMjA4Yi00N2Y3LWJjMzEtMDJjZTMzZTdlZGE5XkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_.jpg",
                            TrailerURL="https://www.youtube.com/embed/mqqft2x_Aa4",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            CategoryId = 1
                        },
                        new Movie()
                        {
                            Name = "Don't Look Up",
                            Description = "This is the Don't Look Up description",
                            Price = 39.50,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BNzk0OWQzMDQtODg1ZC00Yjg2LWJjYzAtNGRjMjE2M2FlYjZjXkEyXkFqcGdeQXVyMTMzNzIyNDc1._V1_.jpg",
                            TrailerURL = "https://www.youtube.com/embed/RbIxYm3mKzI",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            CategoryId = 4
                        },
                        new Movie()
                        {
                            Name = "Hive",
                            Description = "This is the Hive movie description",
                            Price = 39.50,
                            ImageURL = "https://www.crew-united.com/Media/Images/1262/1262669/1262669.entity.jpg",
                            TrailerURL ="https://www.youtube.com/embed/7wnrC671pZc",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            CategoryId = 3
                        },
                        new Movie()
                        {
                            Name = "No Time to Die",
                            Description = "This is the No Time to Die description",
                            Price = 39.50,
                            ImageURL = "https://cdn.europosters.eu/image/1300/posters/james-bond-no-time-to-die-profile-i114389.jpg",
                            TrailerURL = "https://www.youtube.com/embed/BIhNsAtPbPI",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            CategoryId = 2
                        },
                        new Movie()
                        {
                            Name = "Godzilla vs. Kong",
                            Description = "This is the Godzilla vs. Kong description",
                            Price = 39.50,
                            ImageURL = "https://www.themoviedb.org/t/p/original/51tAtnATqN9VizZDnCN0IdCQpXF.jpg",
                            TrailerURL = "https://www.youtube.com/embed/odM92ap8_c0",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            CategoryId = 1
                        }
                    });
                    context.SaveChanges();
                }
                ////Actors & Movies
                //if (!context.Actors_Movies.Any())
                //{
                //    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                //    {
                //        new Actor_Movie()
                //        {
                //            ActorId = 2,
                //            MovieId = 1
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 3,
                //            MovieId = 1
                //        },
                //         new Actor_Movie()
                //        {
                //            ActorId = 1,
                //            MovieId = 2
                //        },
                //         new Actor_Movie()
                //        {
                //            ActorId = 4,
                //            MovieId = 2
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 1,
                //            MovieId = 3
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 2,
                //            MovieId = 3
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 5,
                //            MovieId = 3
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 2,
                //            MovieId = 4
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 3,
                //            MovieId = 4
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 4,
                //            MovieId = 4
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 2,
                //            MovieId = 5
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 3,
                //            MovieId = 5
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 4,
                //            MovieId = 5
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 5,
                //            MovieId = 5
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 3,
                //            MovieId = 6
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 4,
                //            MovieId = 6
                //        },
                //        new Actor_Movie()
                //        {
                //            ActorId = 5,
                //            MovieId = 6
                //        }
                //    });
                //    context.SaveChanges();
                //}
            }

        }
    }
}