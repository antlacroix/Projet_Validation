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
            try
            {
                return db.genre_film.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public genre_film GetGenreFilm(int? id)
        {
            try
            {
                return db.genre_film.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}