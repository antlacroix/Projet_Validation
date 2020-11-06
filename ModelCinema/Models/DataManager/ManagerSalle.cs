using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModelCinema.Models.DataManager
{
    public class ManagerSalle
    {
        private cinema_dbEntities db;

        public ManagerSalle()
        {
            db = new cinema_dbEntities();
        }

        public ManagerSalle(cinema_dbEntities cinema_Db)
        {
            db = cinema_Db;
        }


        public List<salle> GetAllSalle()
        {
            try
            {
                return db.salles.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<salle> GetAllSalleFromCinema(int id)
        {
            try
            {
                return db.salles.Where(s => s.cinema_id == id).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public salle GetSalle(int? id, DateTime? start, DateTime? end)
        {
            if (start == null && end == null)
            {
                start = DateTime.Now.AddDays(-10);
                end = DateTime.Now.AddDays(10);
            }
            else if (start == null && end != null)
            {
                start = end.Value.AddDays(-10);
            }
            else if (start != null && end == null)
            {
                end = start.Value.AddDays(10);
            }

            try
            {
                if (id != null)
                {
                    salle salle = db.salles.Find(id);
                    salle.seances = salle.seances.Where(x => x.date_debut > start && x.date_fin < end).ToList();

                    if (salle != null)
                        return salle;
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

        public bool PostSalle(salle salle)
        {
            try
            {
                if (salle.commentaire == null)
                    salle.commentaire = "";
                if (ValidatorSalle.IsValide(salle) && !ValidatorSalle.IsSalleExist(salle, GetAllSalleFromCinema(salle.cinema_id)))
                {
                    db.salles.Add(salle);
                    db.SaveChanges();
                    return true;
                }
                else if (ValidatorSalle.IsSalleExist(salle, GetAllSalleFromCinema(salle.cinema_id)))
                    throw new ExistingItemException("salle");
                else
                    throw new InvalidItemException("salle");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutSalle(salle salle)
        {
            try
            {
                if (salle.commentaire == null)
                    salle.commentaire = "";
                if (ValidatorSalle.IsSalleExist(salle, GetAllSalleFromCinema(salle.cinema_id)) && ValidatorSalle.IsValide(salle) && !ValidatorSalle.IsSalleContainSeance(salle))
                {
                    db.Entry(salle).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else if (ValidatorSalle.IsSalleContainSeance(salle))
                    throw new SalleHaveSeanceException();
                else if (!ValidatorSalle.IsSalleExist(salle, GetAllSalleFromCinema(salle.cinema_id)))
                    throw new ItemNotExistException("salle");
                else
                    throw new InvalidItemException("salle");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteSalles(int id)
        {
            try
            {
                if (db.salles.Find(id) != null)
                {
                    salle salle = db.salles.Find(id);
                    if (!ValidatorSalle.IsSalleActive(salle) && !ValidatorSalle.IsSalleContainSeance(salle))
                    {
                        db.salles.Remove(salle);
                        db.SaveChanges();
                        return true;
                    }
                    else if (ValidatorSalle.IsSalleActive(salle))
                        throw new SalleActiveException();
                    else
                        throw new SalleHaveSeanceException();
                }
                else
                    throw new InvalidItemException("salle");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
