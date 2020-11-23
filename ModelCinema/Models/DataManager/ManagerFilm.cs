using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            try
            {
                if (ValidatorFilm.IsValide(film) && !ValidatorFilm.IsTitleExist(film, GetAllFilmsFrom(film.annee_parution)))
                {
                    db.films.Add(film);
                    db.SaveChanges();
                    return true;
                }
                else if (ValidatorFilm.IsTitleExist(film, GetAllFilmsFrom(film.annee_parution)))
                    throw new ExistingItemException("film");
                else
                    throw new InvalidItemException("film");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutFilm(film film)
        {
            try
            {
                if (!(ValidatorFilm.IsFilmExist(film, GetAllFilmsFrom(film.annee_parution))) && ValidatorFilm.IsValide(film))
                {
                    db.Set<film>().AddOrUpdate(film);
                    db.SaveChanges();
                    return true;
                }
                else if (!ValidatorFilm.IsFilmExist(film, GetAllFilmsFrom(film.annee_parution)))
                    throw new ItemNotExistException("film");
                else
                    throw new InvalidItemException("film");
            }
            catch (Exception e)
            {
                throw e;
            }
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

        public List<film> GetFilmFiltre(string titre, int? yearMin, int? yearMax, int? id_type)
        {
            if (yearMin == null && yearMax == null)
            {
                yearMin = DateTime.Now.Year - 10;
                yearMax = DateTime.Now.Year + 5;
            }
            else if (yearMin == null && yearMax != null)
            {
                yearMin = yearMax - 10;
            }
            else if (yearMin != null && yearMax == null)
            {
                yearMax = yearMin + 5;
            }

            if (titre != null && !String.Empty.Equals(titre))
            {
                try
                {
                    if (id_type != null)
                        return db.films.Where(f => f.titre.Contains(titre) && f.annee_parution >= yearMin && f.annee_parution <= yearMax && f.id_type == id_type).ToList();
                    else
                        return db.films.Where(f => f.annee_parution >= yearMin && f.annee_parution <= yearMax).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (titre == null)
            {
                try
                {
                    if(id_type != null)
                        return db.films.Where(f => f.annee_parution >= yearMin && f.annee_parution <= yearMax && f.id_type == id_type).ToList();
                    else
                        return db.films.Where(f => f.annee_parution >= yearMin && f.annee_parution <= yearMax).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return db.films.Where(f => f.annee_parution >= DateTime.Now.Year - 10).ToList();
            }
        }
    }
}



