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
    public class ManagerGenre
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<genre> GetAllGenre()
        {
            try
            {
                return db.genres.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public genre GetGenre(int? id)
        {
            try
            {
                return db.genres.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PostGenre(genre genre)
        {
            try
            {
                if (ValidatorGenre.IsValide(genre) && !ValidatorGenre.IsGenreExist(genre, GetAllGenre()))
                {
                    db.genres.Add(genre);
                    db.SaveChanges();
                    return true;
                }
                else if (ValidatorGenre.IsGenreExist(genre, GetAllGenre()))
                    throw new ExistingItemException("genre");
                else
                    throw new InvalidItemException("genre");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutGenre(genre genre)
        {
            try
            {
                if (ValidatorGenre.IsGenreExist(genre, GetAllGenre()) && ValidatorGenre.IsValide(genre))
                {
                    db.Entry(genre).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else if (!ValidatorGenre.IsGenreExist(genre, GetAllGenre()))
                    throw new ItemNotExistException("genre");
                else
                    throw new InvalidItemException("genre");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteGenre(int id)
        {
            try
            {
                if (db.genres.Find(id) != null)
                {
                    genre genre = db.genres.Find(id);
                    db.genres.Remove(genre);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
