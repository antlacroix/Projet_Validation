using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;
using Xceed.Wpf.Toolkit;

namespace ModelCinema.Models.DataManager
{
    public class ManagerFilm
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<film> GetAllFilms()
        {
            return db.films.ToList();
        }

        public film GetFilm(int? id)
        {
            return db.films.Find(id);
        }

        public bool PostFilm(film film)
        {
            if (ValidatorFilm.IsValide(film) && !ValidatorFilm.IsTitleExist(film))
            {
                try
                {
                    db.films.Add(film);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (ValidatorFilm.IsTitleExist(film))
                throw new ExistingItemException("film");
            else
                throw new InvalidItemException("film");

        }

        public bool PutFilm(film film)
        {
            if (db.films.Find(film.Id) != null && ValidatorFilm.IsValide(film))
            {
                try
                {
                    db.Entry(film).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool DeleteFilm(int id)
        {
            if (db.films.Find(id) != null)
            {
                try
                {
                    film film = db.films.Find(id);
                    db.films.Remove(film);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
