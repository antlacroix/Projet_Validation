using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.DataManager
{
    public class ManagerProgrammation
    {
        private cinema_dbEntities db;

        public ManagerProgrammation()
        {
            db = new cinema_dbEntities();
        }

        public ManagerProgrammation(cinema_dbEntities cinema_DbEntities)
        {
            db = cinema_DbEntities;
        }

        public List<programmation> GetAllprogramtionFromSeance(int idSeance)
        {
            try
            {
                return db.programmations.Where(p => p.id_seance == idSeance).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public programmation GetProgrammation(int? id)
        {
            try
            {
                return db.programmations.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PostProgrammation(programmation programmation)
        {
            try
            {
                if(new ManagerSeance().GetSeance(programmation.id_seance).programmations.Where(p => p.is_primary).ToList().Count() != 1 && 
                    (programmation.film.type_film.typage.ToUpper() == "STANDART" || programmation.film.type_film.typage.ToUpper() == "COURT METRAGE"))
                {
                    programmation.is_primary = true;
                }
                db.programmations.Add(programmation);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool PutProgrammation(programmation programmation)
        {
            try
            {
                if (new ManagerSeance().GetSeance(programmation.id_seance).programmations.Where(p => p.is_primary).ToList().Count() != 1 &&
                    (programmation.film.type_film.typage.ToUpper() == "STANDART" || programmation.film.type_film.typage.ToUpper() == "COURT METRAGE"))
                {
                    programmation.is_primary = true;
                }
                db.Entry(programmation).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteProgrammation(int id)
        {
            try
            {
                programmation programmation = db.programmations.Find(id);
                db.programmations.Remove(programmation);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
