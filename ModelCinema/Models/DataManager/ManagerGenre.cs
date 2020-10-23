﻿using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.DataManager
{
    class ManagerGenre
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<genre> GetAllGenre()
        {
            return db.genres.ToList();
        }

        public genre GetGenre(int id)
        {
            return db.genres.Find(id);
        }

        public bool PostGenre(genre genre)
        {
            if (ValidatorGenre.IsValide(genre))
            {
                try
                {
                    db.genres.Add(genre);
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

        public bool PutGenre(genre genre)
        {
            if (db.genres.Find(genre.Id) != null && ValidatorGenre.IsValide(genre))
            {
                try
                {
                    db.Entry(genre).State = EntityState.Modified;
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
