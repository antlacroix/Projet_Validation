using ModelCinema.ModelExeption;
using ModelCinema.Models.ModelValidator;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
                List<seance> ConflictingSeances = ValidatorSeance.IsSeanceConflict(seance, this.GetAllSeanceFromSalle(seance.salle_id, null));
                if (ValidatorSeance.IsValide(seance) && ConflictingSeances.Count == 0 && !ValidatorSeance.IsSeanceExiste(seance, this.GetAllSeanceFromSalle(seance.salle_id, null)))
                {
                    db.seances.Add(seance);
                    db.SaveChanges();
                    return true;
                }
                else if (ConflictingSeances.Count != 0)
                    throw new ConflictiongSeanceException(ConflictingSeances);
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

        private Dictionary<seance, List<seance>> PostManySeance(List<seance> seances, List<programmation> progs, ref List<int> ids)
        {
            //cinema_dbEntities localdb = new cinema_dbEntities();
            Dictionary<seance, List<seance>> conflict = new Dictionary<seance, List<seance>>();
            using (cinema_dbEntities localdb = new cinema_dbEntities())
            {
                foreach (var item in seances)
                {
                    try
                    {
                        List<seance> ConflictingSeances = ValidatorSeance.IsSeanceConflict(item, this.GetAllSeanceFromSalle(item.salle_id, null));
                        if (ValidatorSeance.IsValide(item) && ConflictingSeances.Count == 0 && !ValidatorSeance.IsSeanceExiste(item, this.GetAllSeanceFromSalle(item.salle_id, null)))
                        {
                            localdb.seances.Add(item);
                        }
                        else if (ConflictingSeances.Count != 0)
                            throw new ConflictiongSeanceException(ConflictingSeances);
                        else if (ValidatorSeance.IsSeanceExiste(item, this.GetAllSeanceFromSalle(item.salle_id, null)))
                            throw new ExistingItemException("seance");
                        else
                            throw new InvalidItemException("seance");
                    }
                    catch (ConflictiongSeanceException e)
                    {
                        conflict[item] = (List<seance>)e.Data[0];
                    }
                }
                localdb.SaveChanges();
            }

            foreach (var item in seances)
            {
                ids.Add(db.seances.Where(s => s.date_debut == item.date_debut && s.date_fin == item.date_fin && s.salle_id == item.salle_id).ToList()[0].id);
            }
            return conflict;
        }

        public bool PutSeance(seance seance)
        {
            try
            {
                int cinemaId = new ManagerSalle().GetSalle(seance.salle_id, null, null).cinema_id;
                List<seance> ConflictingSeances = ValidatorSeance.IsSeanceConflict(seance, this.GetAllSeanceFromSalle(seance.salle_id, null));
                if (ValidatorSeance.IsSeanceExiste(seance, this.GetAllSeanceFromCinema(cinemaId)) && ValidatorSeance.IsValide(seance) && ConflictingSeances.Count == 0)
                {
                    db.Set<seance>().AddOrUpdate(seance);
                    db.SaveChanges();
                    return true;
                }
                else if (ConflictingSeances.Count != 0)
                    throw new ConflictiongSeanceException(ConflictingSeances);
                else if (!ValidatorSeance.IsSeanceExiste(seance, this.GetAllSeanceFromCinema(cinemaId)))
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
                    ManagerProgrammation managerProgs = new ManagerProgrammation();
                    List<programmation> progs = managerProgs.GetAllprogramtionFromSeance(id);
                    for (int i = 0; i < progs.Count; i++)
                    {
                        managerProgs.DeleteProgrammation(progs[i].id);
                    }
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

        public bool RecurranceSeances(int id, string recurrance, int nbrRecurrance, string[] days, ref List<int> ids)
        {

            ManagerProgrammation managerProg;
            Dictionary<seance, List<seance>> confictingSeance = new Dictionary<seance, List<seance>>();
            try
            {
                ids.Add(id);
                managerProg = new ManagerProgrammation();
                seance seance = db.seances.Find(id);
                List<seance> seancesToAdd = new List<seance>();
                List<programmation> progs = managerProg.GetAllprogramtionFromSeance(id);
                for (int i = 0; i < nbrRecurrance; i++)
                {
                    switch (recurrance)
                    {
                        case "Yearly":
                            seancesToAdd.Add(new seance()
                            {
                                date_debut = seance.date_debut.AddYears(i + 1),
                                date_fin = seance.date_fin.AddYears(i + 1),
                                salle_id = seance.salle_id,
                                titre_seance = seance.titre_seance
                            });
                            break;
                        case "Monthly":
                            seancesToAdd.Add(new seance()
                            {
                                date_debut = seance.date_debut.AddMonths(i + 1),
                                date_fin = seance.date_fin.AddMonths(i + 1),
                                salle_id = seance.salle_id,
                                titre_seance = seance.titre_seance
                            });
                            break;
                        case "Daily":
                            seancesToAdd.Add(new seance()
                            {
                                date_debut = seance.date_debut.AddDays(i + 1),
                                date_fin = seance.date_fin.AddDays(i + 1),
                                salle_id = seance.salle_id,
                                titre_seance = seance.titre_seance
                            });
                            break;
                        case "Weekly":
                            DateTime date = seance.date_debut;
                            DayOfWeek day = DayOfWeek.Monday;
                            int daysToNextMonday = ((int)day - (int)date.DayOfWeek + 7) % 7;

                            List<DateTime> daysToRepeat = new List<DateTime>();

                            for (int j = 0; j < days.Length; j++)
                            {

                                seancesToAdd.Add(new seance()
                                {
                                    date_debut = seance.date_debut.AddDays(daysToNextMonday + (i * 7) + DaystoAdd(days[j])),
                                    date_fin = seance.date_fin.AddDays(daysToNextMonday + (i * 7) + DaystoAdd(days[j])),
                                    salle_id = seance.salle_id,
                                    titre_seance = seance.titre_seance
                                });
                            }
                            break;
                        default:
                            break;
                    }
                }

                if (seancesToAdd.Count > 0)
                    progs = managerProg.GetAllprogramtionFromSeance(id);

                confictingSeance = PostManySeance(seancesToAdd, progs, ref ids);

                string conflictingString = RecuranceError(confictingSeance);

                if (conflictingString.Length > 0)
                    throw new Exception(conflictingString);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string RecuranceError(Dictionary<seance, List<seance>> confictingSeance)
        {
            string lines = "";

            foreach (var item in confictingSeance)
            {
                lines += ($"la seance du:{item.Key.date_debut} au:{item.Key.date_fin} n'a pas ete ajouter car elle conflict avec:\n");
                foreach (var items in item.Value)
                {
                    lines += ($"---la seance: {items.id}\n");
                }
            }
            return lines;
        }

        private int DaystoAdd(string day)
        {
            switch (day)
            {
                case "monday":
                    return 0;
                    break;
                case "tuesday":
                    return 1;
                    break;
                case "wednesday":
                    return 2;
                    break;
                case "thursday":
                    return 3;
                    break;
                case "friday":
                    return 4;
                    break;
                case "saturday":
                    return 5;
                    break;
                case "sunday":
                    return 6;
                    break;
                default:
                    break;
            }
            return -1;
        }
    }

}

