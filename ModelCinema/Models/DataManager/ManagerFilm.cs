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
        private cinema_dbEntities db;

        public ManagerFilm()
        {
            db = new cinema_dbEntities();
        }

        public ManagerFilm(cinema_dbEntities dbEntities)
        {
            db = dbEntities;
        }

        public List<film> GetAllFilms()
        {
            try
            {
                return db.films.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<film> GetAllFilmsFrom(int? year)
        {
            if (year == null)
                year = DateTime.Now.Year - 10;
            try
            {
                return db.films.Where(f => f.annee_parution >= year).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<film> GetAllFilmsFromTo(int? yearMin, int? yearMax)
        {
            if (yearMin == null)
                yearMin = DateTime.Now.Year - 10;
            if (yearMax == null)
                yearMax = DateTime.Now.Year + 10;

            try
            {
                return db.films.Where(f => f.annee_parution >= yearMin && f.annee_parution <= yearMax).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public film GetFilm(int? id)
        {
            if (id != null)
            {
                film film = db.films.Find(id);
                if (film != null)
                    return film;
                else
                    throw new ItemNotExistException("film");
            }
            else
                throw new NullIdExecption("cinema");
        }

        public bool PostFilm(film film)
        {
            if (ValidatorFilm.IsValide(film) && !ValidatorFilm.IsTitleExist(film, GetAllFilmsFrom(film.annee_parution)))
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
            else if (ValidatorFilm.IsTitleExist(film, GetAllFilmsFrom(film.annee_parution)))
                throw new ExistingItemException("film");
            else
                throw new InvalidItemException("film");
        }

        public bool PutFilm(film film)
        {
            if (ValidatorFilm.IsFilmExist(film, GetAllFilmsFrom(film.annee_parution)) && ValidatorFilm.IsValide(film))
            {
                try
                {
                    db.Entry(film).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (!ValidatorFilm.IsFilmExist(film, GetAllFilmsFrom(film.annee_parution)))
                throw new ItemNotExistException("film");
            else
                throw new InvalidItemException("film");
        }

        public bool DeleteFilm(int id)
        {
            try
            {
                if (db.films.Find(id) != null)
                {
                    film film = db.films.Find(id);
                    db.films.Remove(film);
                    db.SaveChanges();
                    return true;
                }
                else
                    throw new InvalidItemException("film");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
