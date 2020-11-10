using ModelCinema.ModelExeption;
using ModelCinema.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class ValidatorSeance
    {
        static public bool IsValide(seance seance)
        {
            try
            {
                if (
                    seance.date_debut < seance.date_fin &&
                    IsSeanceLongEnought(seance) &&
                    PropretyValidation.IsDateValide(seance.date_debut, seance.dateDebutMin, seance.dateDebutMax) &&
                    PropretyValidation.IsDateValide(seance.date_debut, seance.dateFinMin, seance.dateFinMax) &&
                    PropretyValidation.IsStringValide(seance.titre_seance, seance.titreMin, seance.titreMax)
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        static public bool IsSeanceLongEnought(seance candidate)
        {
            int time = 0;
            foreach (var item in candidate.programmations)
            {
                time += item.film.duree;
            }

            if (candidate.date_debut.AddMinutes(time) <= candidate.date_fin)
                return true;
            else
                throw new SeanceToShortException();
        }

        static public bool IsSeanceLongEnought(seance candidate, List<programmation> progs, int timeToAdd)
        {
            int time = timeToAdd;
            foreach (var item in candidate.programmations)
            {
                time += item.film.duree;
            }

            if (candidate.date_debut.AddMinutes(time) <= candidate.date_fin)
                return true;
            else
                throw new SeanceToShortException();
        }
        static public bool IsSeanceExiste(seance candidate, List<seance> seances)
        {
            List<seance> existingOne = seances.Where(o => o.id == candidate.id).ToList();

            if (existingOne.Count != 0)
            {
                return true;
            }
            else
                return false;
        }

        static public List<seance> IsSeanceConflict(seance candidate, List<seance> seances)
        {
            List<seance> conflitingOne = seances.Where(seance => 
                !(
                    (candidate.date_debut < seance.date_debut && candidate.date_fin <= seance.date_debut) || 
                    (candidate.date_debut >= seance.date_fin && candidate.date_fin > seance.date_fin)
                ) 
                && candidate.id != seance.id                
                ).ToList();

            return conflitingOne;
        }
    }
}
