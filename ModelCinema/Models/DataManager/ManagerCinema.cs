﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;

namespace ModelCinema.Models.DataManager
{
    public class ManagerCinema
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<cinema> GetAllCinema()
        {
            return db.cinemas.ToList();
        }

        public cinema GetCinema(int? id)
        {
            return db.cinemas.Find(id);
        }

        public bool PostCinema(cinema cinema)
        {
            if (!ValidatorCinema.IsCinemaExist(cinema))
            {
                try
                {
                    db.cinemas.Add(cinema);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new ExistingItemException("cinema");
            }
        }

        public bool PutCinema(cinema cinema)
        {
            if (ValidatorCinema.IsCinemaExist(cinema))
            {
                try
                {
                    db.Entry(cinema).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new ItemNotExistException("cinema");
            }
        }

        public bool DeleteCinema(int id)
        {
            if (db.cinemas.Find(id) != null)
            {
                try
                {
                    cinema cinema = db.cinemas.Find(id);
                    db.cinemas.Remove(cinema);
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
