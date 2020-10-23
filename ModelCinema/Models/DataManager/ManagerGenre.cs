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
            return db.genres.ToList();
        }

        public genre GetGenre(int? id)
        {
            return db.genres.Find(id);
        }

        public bool PostGenre(genre genre)
        {
            if (ValidatorGenre.IsValide(genre) && !ValidatorGenre.IsGenreExist(genre))
            {
                try
                {
                    db.genres.Add(genre);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (ValidatorGenre.IsGenreExist(genre))
                throw new ExistingItemException("genre");
            else
                throw new InvalidItemException("genre");
        }

        public bool PutGenre(genre genre)
        {
            if (ValidatorGenre.IsGenreExist(genre) && ValidatorGenre.IsValide(genre))
            {
                try
                {
                    db.Entry(genre).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (!ValidatorGenre.IsGenreExist(genre))
                throw new ItemNotExistException("genre");
            else
                throw new InvalidItemException("genre");
        }

        public bool DeleteGenre(int id)
        {
            if (db.genres.Find(id) != null)
            {
                try
                {
                    genre genre = db.genres.Find(id);
                    db.genres.Remove(genre);
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
