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
            try
            {
                db = new cinema_dbEntities();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public ManagerSeance(cinema_dbEntities cinema_DbEntities)
        {
            try
            {
                db = cinema_DbEntities;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

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
            try
            {
                if (date == null)
                    date = DateTime.Now.AddDays(-10);
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
            try
            {
                if (date == null)
                    date = DateTime.Now.AddDays(-10);
                return db.seances.Where(s => s.salle_id == salleId && (s.date_debut >= date || s.date_fin >= date)).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<seance> GetAllSeanceFrom(DateTime? date)
        {
            try
            {
                if (date == null)
                    date = DateTime.Now.AddDays(-10);
                return db.seances.Where(s => s.date_debut >= date || s.date_fin >= date).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public seance GetSeance(int? id)
        {
            try
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PostSeance(seance seance)
        {
            try
            {
                if (ValidatorSeance.IsValide(seance) && !ValidatorSeance.IsSeanceConflict(seance, this.GetAllSeanceFromSalle(seance.salle_id, null)) && !ValidatorSeance.IsSeanceExiste(seance, this.GetAllSeanceFromSalle(seance.salle_id, null)))
                {
                    db.seances.Add(seance);
                    db.SaveChanges();
                    return true;
                }
                else if (ValidatorSeance.IsSeanceConflict(seance, this.GetAllSeanceFromSalle(seance.salle_id, null)))
                    throw new ConflictiongSeanceException();
                else if (ValidatorSeance.IsSeanceExiste(seance, this.GetAllSeanceFromSalle(seance.salle_id, null)))
                    throw new ExistingItemException("seance");
                else
                    throw new InvalidItemException("seance");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutSeance(seance seance)
        {
            try
            {
                if (ValidatorSeance.IsSeanceExiste(seance, this.GetAllSeanceFromSalle(seance.salle_id, null)) && ValidatorSeance.IsValide(seance) && !ValidatorSeance.IsSeanceConflict(seance, GetAllSeanceFromSalle(seance.salle_id, null)))
                {
                    db.Entry(seance).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else if (ValidatorSeance.IsSeanceConflict(seance, this.GetAllSeanceFromSalle(seance.salle_id, null)))
                    throw new ConflictiongSeanceException();
                else if (!ValidatorSeance.IsSeanceExiste(seance, this.GetAllSeanceFromSalle(seance.salle_id, null)))
                    throw new ItemNotExistException("seance");
                else
                    throw new InvalidItemException("seance");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteSeance(int id)
        {
            try
            {
                if (db.seances.Find(id) != null)
                {
                    seance seance = db.seances.Find(id);
                    db.seances.Remove(seance);
                    db.SaveChanges();
                    return true;
                }
                else
                    throw new InvalidItemException("seance");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
