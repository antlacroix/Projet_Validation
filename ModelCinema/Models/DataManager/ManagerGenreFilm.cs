using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModelCinema.Models.DataManager
    {
        public class ManagerGenreFilm
        {
            private cinema_dbEntities db = new cinema_dbEntities();

            public List<genre_film> GetAllGenreFilm()
            {
                return db.genre_film.ToList();
            }

            public genre_film GetGenreFilm(int? id)
            {
                return db.genre_film.Find(id);
            }
        }
    }