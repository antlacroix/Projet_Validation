using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;
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
                var seance = new ManagerSeance().GetSeance(programmation.id_seance);
                if (ValidatorSeance.IsSeanceLongEnought(seance, new ManagerProgrammation().GetAllprogramtionFromSeance(programmation.id_seance), new ManagerFilm().GetFilm(programmation.id_film).duree))
                {

                    ManagerSeance manager = new ManagerSeance();
                    List<programmation> programmations = manager.GetSeance(programmation.id_seance).programmations.ToList();
                    film f = new ManagerFilm().GetFilm(programmation.id_film);

                    if (programmations.Count() == 0 && (f.type_film.typage.ToUpper() == "STANDART" || f.type_film.typage.ToUpper() == "COURT METRAGE"))
                        programmation.is_primary = true;

                    else if (programmations.Where(p => p.is_primary).ToList().Count() != 1 &&
                        (f.type_film.typage.ToUpper() == "STANDART" || f.type_film.typage.ToUpper() == "COURT METRAGE"))
                    {
                        programmation.is_primary = true;
                    }
                    db.programmations.Add(programmation);
                    db.SaveChanges();
                    return true;
                }
                else
                    throw new SeanceToShortException();
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
                db.Entry(programmation).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool MakePrimary(int id)
        {
            try
            {
                programmation programmation = GetProgrammation(id);
                programmation.is_primary = true;

                ManagerSeance manager = new ManagerSeance();
                List<programmation> programmations = manager.GetSeance(programmation.id_seance).programmations.ToList();
                int i = programmations.Find(prog => prog.is_primary).id;
                programmation oldPrimary = GetProgrammation(i);
                oldPrimary.is_primary = false;
                PutProgrammation(oldPrimary);
                programmations.Find(prog => prog.id == programmation.id).is_primary = true;
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
