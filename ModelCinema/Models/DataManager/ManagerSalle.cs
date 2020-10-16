using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
namespace ModelCinema.Models.DataManager
{
    class ManagerSalle
    {
        static private cinema_dbEntities db = new cinema_dbEntities();

        public List<salle> GetAllSalle()
        {
            return db.salles.ToList();
        }

        public salle GetSalle(int id)
        {
            return db.salles.Find(id);
        }

        public bool PostSalle(salle salle)
        {
            if (ValidatorSalle.IsValide(salle))
            {
                try
                {
                    db.salles.Add(salle);
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

        public bool PutSalle(salle salle)
        {
            if (db.salles.Find(salle.id) != null && ValidatorSalle.IsValide(salle))
            {
                try
                {
                    db.Entry(salle).State = EntityState.Modified;
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

        public bool DeleteSalles(int id)
        {
            if (db.salles.Find(id) != null)
            {
                try
                {
                    salle salle = db.salles.Find(id);
                    db.salles.Remove(salle);
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
