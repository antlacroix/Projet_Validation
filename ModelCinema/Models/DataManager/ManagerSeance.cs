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
    public class ManagerSeance
    {
        private cinema_dbEntities db = new cinema_dbEntities();

        public List<seance> GetAllSeance()
        {
            return db.seances.ToList();
        }

        public seance GetSeance(int? id)
        {
            return db.seances.Find(id);
        }

        public bool PostSeance(seance seance)
        {
            if (ValidatorSeance.IsValide(seance) && !ValidatorSeance.IsSeanceConflict(seance))
            {
                try
                {
                    db.seances.Add(seance);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (ValidatorSeance.IsSeanceConflict(seance))
                throw new ConflictiongSeanceException();
            else
                throw new InvalidItemException("seance");
        }

        public bool PutSeance(seance seance)
        {
            if (db.seances.Find(seance.id) != null && ValidatorSeance.IsValide(seance))
            {
                try
                {
                    db.Entry(seance).State = EntityState.Modified;
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

        public bool DeleteSeance(int id)
        {
            if (db.seances.Find(id) != null)
            {
                try
                {
                    seance seance = db.seances.Find(id);
                    db.seances.Remove(seance);
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
