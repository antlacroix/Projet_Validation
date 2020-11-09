using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
        private cinema_dbEntities db;

        public ManagerCinema()
        {
            db = new cinema_dbEntities();
        }

        public ManagerCinema(cinema_dbEntities cinema_DbEntities)
        {
            db = cinema_DbEntities;
        }

        public List<cinema> GetAllCinema()
        {
            try
            {
                return db.cinemas.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public cinema GetCinema(int? id)
        {
            try
            {

                if (id != null)
                {
                    cinema cinema = db.cinemas.Find(id);
                    if (cinema != null)
                        return cinema;
                    else
                        throw new ItemNotExistException("cinema");
                }
                else
                    throw new NullIdExecption("cinema");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PostCinema(cinema cinema)
        {
            try
            {
                if (!ValidatorCinema.IsCinemaExist(cinema, GetAllCinema()))
                {
                    db.cinemas.Add(cinema);
                    db.SaveChanges();
                    return true;
                }
                else
                    throw new ExistingItemException("cinema");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutCinema(cinema cinema)
        {
            try
            {
                if (ValidatorCinema.IsCinemaExist(cinema, GetAllCinema()))
                {
                    //db.Entry(cinema).State = EntityState.Modified;
                    db.Set<cinema>().AddOrUpdate(cinema);
                    db.SaveChanges();
                    return true;
                }
                else
                    throw new ItemNotExistException("cinema");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteCinema(int id)
        {
            try
            {
                if (db.cinemas.Find(id) != null)
                {
                    cinema cinema = db.cinemas.Find(id);
                    if (!ValidatorCinema.IsCinemaContainSalle(cinema))
                    {
                        cinema = db.cinemas.Find(id);
                        db.cinemas.Remove(cinema);
                        db.SaveChanges();
                        return true;
                    }
                    else
                        throw new CinemaHasSalleException();
                }
                else
                    throw new InvalidItemException("cinema");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
