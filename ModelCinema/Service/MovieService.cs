using CsvHelper;
using ModelCinema.Models;
using ModelCinema.Models.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace ModelCinema.Service
{
    public class MovieService
    {
        public MovieService() { }

        readonly UnitOfWork uow = new UnitOfWork(new cinema_dbEntities());

        public void ImportCSV(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    try
                    {
                        var movie = new film
                        {
                            Ranking = csv.GetField<int>("Rank"),
                            Title = csv.GetField<String>("Title"),
                            Description = csv.GetField("Description"),
                            Year = csv.GetField<int>("Year"),
                            Duration = csv.GetField<int>("Runtime (Minutes)"),
                            Rating = csv.GetField<float>("Rating"),
                            Votes = csv.GetField<int>("Votes"),
                            Revenue = csv.GetField("Revenue (Millions)") == "" ? null : csv.GetField<float?>("Revenue (Millions)"),
                            Metascore = csv.GetField("Metascore") == "" ? null : csv.GetField<int?>("Metascore")
                        };

                        uow.MovieRepo.InsertIfNotExists(movie);
                        InsertGenresIfNotExists(SplitFieldContent(csv.GetField("Genre")));
                        InsertParticipantIfNotExists(SplitFieldContent(csv.GetField("Director")));
                        InsertParticipantIfNotExists(SplitFieldContent(csv.GetField("Actors")));
                        InsertRoleIfNotExists("Director");
                        InsertRoleIfNotExists("Actor");

                        uow.Save();

                        var director = uow.RoleParticipantRepo.Find(new role_participant { Role = "Director" });
                        var actor = uow.RoleParticipantRepo.Find(new role_participant { Role = "Actor" });
                        InsertMovieGenresIfNotExists(SplitFieldContent(csv.GetField("Genre")), movie);
                        InsertParticipationIfNotExists(SplitFieldContent(csv.GetField("Director")), director, movie);
                        InsertParticipationIfNotExists(SplitFieldContent(csv.GetField("Actors")), actor, movie);

                        uow.Save();
                        //Debug.WriteLine(uow.MovieRepo.Find(movie).Title);
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                }
            }
        }

        public ICollection<string> SplitFieldContent(string field)
        {
            return field.Split(',').ToList();
        }

        //transformer en void pour un seul save, ensuite retrieve avec linq
        public void InsertGenresIfNotExists(ICollection<string> genreList)
        {
            foreach (var genre in genreList)
            {
                var obj = new genre { Genre = genre };
                uow.GenreRepo.InsertIfNotExists(obj);
            }
        }

        public void InsertMovieGenresIfNotExists(ICollection<string> genreList, film movie)
        {
            foreach (var genre in genreList)
            {
                var item = uow.GenreRepo.Find(new genre { Genre = genre });
                var obj = new genre_film { Genre = item, Movie = movie };
                uow.MovieGenreRepo.InsertIfNotExists(obj);
            }
        }

        public void InsertParticipantIfNotExists(ICollection<string> nameList)
        {
            foreach (var name in nameList)
            {
                var obj = new participant { Name = name };
                uow.ParticipantRepo.InsertIfNotExists(obj);
            }
        }

        public void InsertRoleIfNotExists(string role)
        {
            var obj = new role_participant { Role = role };
            uow.RoleParticipantRepo.InsertIfNotExists(obj);
        }

        public void InsertParticipationIfNotExists(ICollection<string> nameList, role_participant role, film movie)
        {
            foreach (var name in nameList)
            {
                var participant = uow.ParticipantRepo.Find(new participant { Name = name });
                var obj = new participation { Participant = participant, Role = role, Movie = movie };
                uow.ParticipationRepo.InsertIfNotExists(obj);
            }
        }

        public IEnumerable<film> GetMovies()
        {
            return uow.MovieRepo.GetAll();
        }

        //Pour flusher le contenu rapidement pendant les test, a enlever apres
        public void FlushMovies()
        {
            uow.FlushMovies();
        }
    }
}