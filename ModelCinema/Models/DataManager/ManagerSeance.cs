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
        private cinema_dbEntities db;

        public ManagerSeance()
        {
            db = new cinema_dbEntities();
        }
        public ManagerSeance(cinema_dbEntities cinema_DbEntities)
        {
            db = cinema_DbEntities;
        }

        //public List<seance> GetAllSeance()
        //{
        //    try
        //    {
        //        return db.seances.ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public List<seance> GetAllSeanceFromCinema(int cinemaId)
        {
            try
            {
                return db.seances.Where(s => s.salle.cinema_id == cinemaId).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<seance> GetAllSeanceFromCinemaDate(int cinemaId, DateTime? date)
        {
            if (date == null)
                date = DateTime.Now.AddDays(-10);
            try
            {
                return db.seances.Where(s => 
                    s.salle.cinema_id == cinemaId &&
                    (
                        s.date_debut >= date ||
                        s.date_fin >= date
                    )).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<seance> GetAllSeanceFromSalle(int salleId, DateTime? date)
        {
            if (date == null)
                date = DateTime.Now.AddDays(-10);
            try
            {
                return db.seances.Where(s => s.salle_id == salleId && (s.date_debut >= date || s.date_fin >= date)).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public seance GetSeance(int? id)
        {
            if (id != null)
            {
                seance seance = db.seances.Find(id);
                if (seance != null)
                    return seance;
                else
                    throw new ItemNotExistException("seance");
            }
            else
                throw new NullIdExecption("seance");
        }

        public bool PostSeance(seance seance)
        {
            if (ValidatorSeance.IsValide(seance) && !ValidatorSeance.IsSeanceConflict(seance) && !ValidatorSeance.IsSeanceExiste(seance))
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
            else if (ValidatorSeance.IsSeanceExiste(seance))
                throw new ExistingItemException("seance");
            else
                throw new InvalidItemException("seance");
        }

        public bool PutSeance(seance seance)
        {
            if (ValidatorSeance.IsSeanceExiste(seance) && ValidatorSeance.IsValide(seance) && !ValidatorSeance.IsSeanceConflict(seance))
            {
                try
                {
                    db.Entry(seance).State = EntityState.Modified;
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
            else if (!ValidatorSeance.IsSeanceExiste(seance))
                throw new ItemNotExistException("seance");
            else
                throw new InvalidItemException("seance");
        }

        public bool DeleteSeance(int id)
        {

            if (db.seances.Find(id) != null)
            {
                seance seance = db.seances.Find(id);
                try
                {
                    db.seances.Remove(seance);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
                throw new InvalidItemException("seance");
        }
    }
}
