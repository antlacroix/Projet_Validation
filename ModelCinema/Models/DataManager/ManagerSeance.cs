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

        public bool PutSeance(seance seance)
        {
            try
            {
                List<seance> ConflictingSeances = ValidatorSeance.IsSeanceConflict(seance, this.GetAllSeanceFromSalle(seance.salle_id, null));
                if (ValidatorSeance.IsSeanceExiste(seance, this.GetAllSeanceFromSalle(seance.salle_id, null)) && ValidatorSeance.IsValide(seance) && ConflictingSeances.Count == 0)
                {
                    db.Set<seance>().AddOrUpdate(seance);
                    db.SaveChanges();
                    return true;
                }
                else if (ConflictingSeances.Count == 0)
                    throw new ConflictiongSeanceException(ConflictingSeances);
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

        public bool RecurranceSeances(int id, string recurrance, int nbrRecurrance)
        {
            ManagerProgrammation managerProg;
            Dictionary<seance, List<seance>> confictingSeance = new Dictionary<seance, List<seance>>();
            try
            {
                managerProg = new ManagerProgrammation();
                seance seance = db.seances.Find(id);
                List<programmation> progs = managerProg.GetAllprogramtionFromSeance(id);
                for (int i = 0; i < nbrRecurrance; i++)
                {
                    seance seanceToAdd = null;
                    switch (recurrance)
                    {
                        case "Yearly":
                            seanceToAdd = new seance()
                            {
                                date_debut = seance.date_debut.AddYears(i+1),
                                date_fin = seance.date_fin.AddYears(i+1),
                                salle_id = seance.salle_id,
                                titre_seance = seance.titre_seance
                            };
                            break;
                        case "Monthly":
                            seanceToAdd = new seance()
                            {
                                date_debut = seance.date_debut.AddMonths(i+1),
                                date_fin = seance.date_fin.AddMonths(i+1),
                                salle_id = seance.salle_id,
                                titre_seance = seance.titre_seance
                            };
                            break;
                        case "Daily":
                            seanceToAdd = new seance()
                            {
                                date_debut = seance.date_debut.AddDays(i+1),
                                date_fin = seance.date_fin.AddDays(i + 1),
                                salle_id = seance.salle_id,
                                titre_seance = seance.titre_seance
                            };
                            break;
                        case "Weekly":
                            seanceToAdd = new seance()
                            {
                                date_debut = seance.date_debut.AddDays(7 * (i + 1)),
                                date_fin = seance.date_fin.AddDays(7 * (i + 1)),
                                salle_id = seance.salle_id,
                                titre_seance = seance.titre_seance
                            };
                            break;
                        default:
                            break;
                    }
                    if (seanceToAdd != null)
                        progs = managerProg.GetAllprogramtionFromSeance(id);
                    int addedSeanceId = 0;
                    try
                    {
                        if (PostSeance(seanceToAdd))
                            addedSeanceId = db.seances.Where(s => s.date_debut == seanceToAdd.date_debut && s.date_fin == seanceToAdd.date_fin && s.salle_id == seanceToAdd.salle_id).ToList()[0].id;
                    }
                    catch (ConflictiongSeanceException cse)
                    {
                        confictingSeance[seanceToAdd] = (List<seance>)cse.Data[0];
                    }
                    if (addedSeanceId != 0)
                    {
                        foreach (var item in progs)
                        {
                            item.id_seance = addedSeanceId;
                            managerProg.PostProgrammation(item);
                        }
                    }
                }

                string conflictingString = RecuranceError(confictingSeance);

                if (conflictingString.Length > 0)
                    throw new Exception(conflictingString);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            #region
            //if (recurrance == "Yearly")
            //    {
            //        seance seance = db.seances.Find(id);
            //        List<programmation> progs = managerProg.GetAllprogramtionFromSeance(id);
            //        int counter = nbrRecurrance;
            //        while (counter > 0)
            //        {
            //            seance seanceToAdd = new seance()
            //            {
            //                date_debut = seance.date_debut.AddYears(1),
            //                date_fin = seance.date_fin.AddYears(1),
            //                salle_id = seance.salle_id,
            //                titre_seance = seance.titre_seance
            //            };

            //            int addedSeanceId = 0;

            //            if (PostSeance(seanceToAdd))
            //                addedSeanceId = db.seances.Where(s => s.date_debut == seanceToAdd.date_debut && s.date_fin == seanceToAdd.date_fin && s.salle_id == seanceToAdd.salle_id).ToList()[0].id;

            //            foreach (var item in progs)
            //            {
            //                if (addedSeanceId != 0)
            //                {
            //                    item.id_seance = addedSeanceId;
            //                    managerProg.PostProgrammation(item);
            //                }
            //            }

            //            db.SaveChanges();
            //            counter--;
            //        }
            //        return true;
            //    }
            //    else if (recurrance == "Monthly")
            //    {
            //        seance seance = db.seances.Find(id);
            //        List<programmation> progs = managerProg.GetAllprogramtionFromSeance(id);
            //        int counter = nbrRecurrance;
            //        while (counter > 0)
            //        {
            //            seance seanceToAdd = new seance()
            //            {
            //                date_debut = seance.date_debut.AddMonths(1),
            //                date_fin = seance.date_fin.AddMonths(1),
            //                salle_id = seance.salle_id,
            //                titre_seance = seance.titre_seance
            //            };

            //            int addedSeanceId = 0;

            //            if (PostSeance(seanceToAdd))
            //                addedSeanceId = db.seances.Where(s => s.date_debut == seanceToAdd.date_debut && s.date_fin == seanceToAdd.date_fin && s.salle_id == seanceToAdd.salle_id).ToList()[0].id;

            //            foreach (var item in progs)
            //            {
            //                if (addedSeanceId != 0)
            //                {
            //                    item.id_seance = addedSeanceId;
            //                    managerProg.PostProgrammation(item);
            //                }
            //            }

            //            db.SaveChanges();
            //            counter--;
            //        }
            //        return true;
            //    }
            //    else if (recurrance == "Daily")
            //    {
            //        seance seance = db.seances.Find(id);
            //        List<programmation> progs = managerProg.GetAllprogramtionFromSeance(id);
            //        int counter = nbrRecurrance;
            //        while (counter > 0)
            //        {
            //            seance seanceToAdd = new seance()
            //            {
            //                date_debut = seance.date_debut.AddDays(1),
            //                date_fin = seance.date_fin.AddDays(1),
            //                salle_id = seance.salle_id,
            //                titre_seance = seance.titre_seance
            //            };
            //            int addedSeanceId = 0;

            //            if (PostSeance(seanceToAdd))
            //                addedSeanceId = db.seances.Where(s => s.date_debut == seanceToAdd.date_debut && s.date_fin == seanceToAdd.date_fin && s.salle_id == seanceToAdd.salle_id).ToList()[0].id;

            //            foreach (var item in progs)
            //            {
            //                if (addedSeanceId != 0)
            //                {
            //                    item.id_seance = addedSeanceId;
            //                    managerProg.PostProgrammation(item);
            //                }
            //            }

            //            db.SaveChanges();
            //            counter--;
            //        }
            //        return true;
            //    }
            //    else
            //    {
            //        seance seance = db.seances.Find(id);
            //        List<programmation> progs = managerProg.GetAllprogramtionFromSeance(id);
            //        for (int i = 0; i <= nbrRecurrance; i++)
            //        {
            //            seance seanceToAdd = new seance()
            //            {
            //                date_debut = seance.date_debut.AddDays(7 * (i + 1)),
            //                date_fin = seance.date_fin.AddDays(7 * (i + 1)),
            //                salle_id = seance.salle_id,
            //                titre_seance = seance.titre_seance
            //            };

            //            int addedSeanceId = 0;

            //            try
            //            {
            //                if (PostSeance(seanceToAdd))
            //                    addedSeanceId = db.seances.Where(s => s.date_debut == seanceToAdd.date_debut && s.date_fin == seanceToAdd.date_fin && s.salle_id == seanceToAdd.salle_id).ToList()[0].id;
            //            }
            //            catch (ConflictiongSeanceException cse)
            //            {
            //                seanceFailed.Add(seanceToAdd);
            //                confictingSeance[seanceToAdd.id] = (List<seance>)cse.Data[0];
            //            }
            //            if (addedSeanceId != 0)
            //            {
            //                foreach (var item in progs)
            //                {
            //                    item.id_seance = addedSeanceId;
            //                    managerProg.PostProgrammation(item);
            //                }
            //            }
            //        }
            //        return true;
            //    }
            #endregion
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
    }
}

