using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //if (true)
            //{
                try
                {
                    db.cinemas.Add(cinema);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            //}
            //else
            //{
            //    return false;
            //}
        }

        public bool PutCinema(cinema cinema)
        {
            if (db.cinemas.Find(cinema.id) != null)
            {
                try
                {
                    db.Entry(cinema).State = EntityState.Modified;
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
