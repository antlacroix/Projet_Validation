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
        private cinema_dbEntities db = new cinema_dbEntities();

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

        public salle GetSalle(int? id)
        {
            if (id != null)
            {
                salle salle = db.salles.Find(id);
                if (salle != null)
                    return salle;
                else
                    throw new ItemNotExistException("cinema");
            }
            else
                throw new NullIdExecption("cinema");
        }

        public bool PostSalle(salle salle)
        {
            if (salle.commentaire == null)
                salle.commentaire = "";
            if (ValidatorSalle.IsValide(salle) && !ValidatorSalle.IsSalleExist(salle))
            {
                try
                {
                    db.salles.Add(salle);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (ValidatorSalle.IsSalleExist(salle))
                throw new ExistingItemException("salle");
            else
                throw new InvalidItemException("salle");
        }

        public bool PutSalle(salle salle)
        {
            if (salle.commentaire == null)
                salle.commentaire = "";
            if (ValidatorSalle.IsSalleExist(salle) && ValidatorSalle.IsValide(salle) && !ValidatorSalle.IsSalleContainSeance(salle))
            {
                try
                {
                    db.Entry(salle).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (ValidatorSalle.IsSalleContainSeance(salle))
                throw new SalleHaveSeanceException();
            else if (!ValidatorSalle.IsSalleExist(salle))
                throw new ItemNotExistException("salle");
            else
                throw new InvalidItemException("salle");
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
